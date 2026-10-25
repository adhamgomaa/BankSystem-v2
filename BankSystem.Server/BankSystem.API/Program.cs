using BankSystem.DataAccess;
using BankSystem.Business;
using BankSystem.API.Configuration;
using BankSystem.API.Authorization;
using BankSystem.API.Interfaces;
using BankSystem.API.Implementations;
using BankSystem.Business.Interfaces;
using BankSystem.Business.Implementations;
using BankSystem.DataAccess.Interfaces;
using BankSystem.DataAccess.Implementations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.RateLimiting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi;
using System.Globalization;
using System.Text;
using System.Threading.RateLimiting;


var builder = WebApplication.CreateBuilder(args);

string connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
    ?? throw new InvalidOperationException("Connection string 'DefaultConnection' is not configured.");

string? jwtSigningKey = builder.Configuration["Jwt:SigningKey"];
if (string.IsNullOrWhiteSpace(jwtSigningKey) || Encoding.UTF8.GetByteCount(jwtSigningKey) < 32)
{
    throw new InvalidOperationException(
        "JWT signing key is missing or too short. Configure Jwt:SigningKey with a random secret of at least 32 UTF-8 bytes, for example using the Jwt__SigningKey environment variable.");
}

var jwtSettings = new JwtTokenSettings(
    Issuer: builder.Configuration["Jwt:Issuer"] ?? "BankSystemAPI",
    Audience: builder.Configuration["Jwt:Audience"] ?? "BankSystemClient",
    SigningKey: jwtSigningKey,
    AccessTokenMinutes: builder.Configuration.GetValue<int?>("Jwt:AccessTokenMinutes") ?? 30,
    RefreshTokenDays: builder.Configuration.GetValue<int?>("Jwt:RefreshTokenDays") ?? 7);

if (jwtSettings.AccessTokenMinutes <= 0 || jwtSettings.RefreshTokenDays <= 0)
{
    throw new InvalidOperationException("Jwt:AccessTokenMinutes and Jwt:RefreshTokenDays must be greater than zero.");
}

builder.Services.AddSingleton(jwtSettings);
builder.Services.AddSingleton(new DataAccessSettings(connectionString));
builder.Services.AddScoped<IUserDataAccess, UserDataAccess>();
builder.Services.AddScoped<IPeopleDataAccess, PeopleDataAccess>();
builder.Services.AddScoped<IClientDataAccess, ClientDataAccess>();
builder.Services.AddScoped<ITransferDataAccess, TransferDataAccess>();
builder.Services.AddScoped<IRefreshTokenData, RefreshTokenData>();
builder.Services.AddScoped<ILoginAttemptData, LoginAttemptData>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IPeopleService, PeopleService>();
builder.Services.AddScoped<IClientService, ClientService>();
builder.Services.AddScoped<ITransferService, TransferService>();
builder.Services.AddScoped<IRefreshTokenService, RefreshTokenService>();
builder.Services.AddScoped<ILoginAttemptService, LoginAttemptService>();
builder.Services.AddScoped<IAuthService, AuthService>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            RequireExpirationTime = true,
            RequireSignedTokens = true,
            ClockSkew = TimeSpan.Zero,
            ValidAlgorithms = [SecurityAlgorithms.HmacSha256],
            ValidIssuer = jwtSettings.Issuer,
            ValidAudience = jwtSettings.Audience,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.SigningKey))
        };
    });

builder.Services.AddSingleton<IAuthorizationHandler, PermissionAuthorizationHandler>();
builder.Services.AddAuthorization(options =>
{
    options.FallbackPolicy = options.DefaultPolicy;
    options.AddPolicy(PermissionPolicies.Client, policy =>
        policy.RequireAuthenticatedUser()
            .AddRequirements(new PermissionRequirement((int)BankPermission.Client)));
    options.AddPolicy(PermissionPolicies.People, policy =>
        policy.RequireAuthenticatedUser()
            .AddRequirements(new PermissionRequirement((int)BankPermission.People)));
    options.AddPolicy(PermissionPolicies.Transfer, policy =>
        policy.RequireAuthenticatedUser()
            .AddRequirements(new PermissionRequirement((int)BankPermission.Transfer)));
    options.AddPolicy(PermissionPolicies.Registration, policy =>
        policy.RequireAuthenticatedUser()
            .AddRequirements(new PermissionRequirement((int)BankPermission.Registration)));
    options.AddPolicy(PermissionPolicies.User, policy =>
        policy.RequireAuthenticatedUser()
            .AddRequirements(new PermissionRequirement((int)BankPermission.User)));
    options.AddPolicy(PermissionPolicies.FullAccess, policy =>
        policy.RequireAuthenticatedUser()
            .AddRequirements(new PermissionRequirement((int)BankPermission.FullAccess)));
});

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Description = "Enter a valid access token from POST /api/Auth/login. Paste the token only; Swagger adds the Bearer prefix.",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT"
    });
    options.OperationFilter<AuthorizeOperationFilter>();
});

builder.Services.AddRateLimiter(options =>
{
    options.RejectionStatusCode = StatusCodes.Status429TooManyRequests;
    options.OnRejected = async (context, cancellationToken) =>
    {
        context.HttpContext.Response.ContentType = "application/problem+json";
        context.HttpContext.Response.Headers.RetryAfter = context.Lease.TryGetMetadata(
            MetadataName.RetryAfter,
            out var retryAfter)
            ? Math.Max(1, (int)Math.Ceiling(retryAfter.TotalSeconds)).ToString(CultureInfo.InvariantCulture)
            : "60";

        await context.HttpContext.Response.WriteAsJsonAsync(
            new ProblemDetails
            {
                Status = StatusCodes.Status429TooManyRequests,
                Title = "Too many requests",
                Detail = "Request rate limit exceeded. Retry after the indicated delay."
            },
            cancellationToken);
    };

    options.GlobalLimiter = PartitionedRateLimiter.Create<HttpContext, string>(context =>
        RateLimitPartition.GetFixedWindowLimiter(
            GetClientPartitionKey(context),
            _ => new FixedWindowRateLimiterOptions
            {
                PermitLimit = 120,
                Window = TimeSpan.FromMinutes(1),
                QueueLimit = 0,
                AutoReplenishment = true
            }));

    options.AddPolicy(RateLimitPolicies.Login, context =>
        CreateFixedWindowLimiter(GetClientPartitionKey(context), 5, TimeSpan.FromMinutes(5)));
    options.AddPolicy(RateLimitPolicies.Refresh, context =>
        CreateFixedWindowLimiter(GetClientPartitionKey(context), 10, TimeSpan.FromMinutes(1)));
    options.AddPolicy(RateLimitPolicies.UserWrites, context =>
        CreateFixedWindowLimiter(GetClientPartitionKey(context), 10, TimeSpan.FromMinutes(1)));
});

var allowedOrigins = builder.Configuration
    .GetSection("Cors:AllowedOrigins")
    .Get<string[]>() ?? [];

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy
            .WithOrigins(allowedOrigins)
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
} else
{
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseCors();

app.UseRateLimiter();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

static string GetClientPartitionKey(HttpContext context) =>
    context.Connection.RemoteIpAddress?.MapToIPv6().ToString() ?? "unknown-client";

static RateLimitPartition<string> CreateFixedWindowLimiter(
    string partitionKey,
    int permitLimit,
    TimeSpan window) =>
    RateLimitPartition.GetFixedWindowLimiter(
        partitionKey,
        _ => new FixedWindowRateLimiterOptions
        {
            PermitLimit = permitLimit,
            Window = window,
            QueueLimit = 0,
            AutoReplenishment = true
        });
