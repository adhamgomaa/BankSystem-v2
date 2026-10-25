using System.Net;
using System.Net.Http.Json;
using BankSystem.DTOs.Auth;
using BankSystem.WinForms.Helpers;

namespace BankSystem.WinForms.Services;

public class AuthApiService
{
    private readonly HttpClient _httpClient = ApiClient.authHttpClient;

    public async Task<LoginResponseDTO?> LoginAsync(
        LoginRequestDTO request,
        CancellationToken cancellationToken = default)
    {
        using HttpResponseMessage response = await _httpClient.PostAsJsonAsync(
            ApiRoutes.Auth.Login,
            request,
            cancellationToken);

        if (response.StatusCode == HttpStatusCode.Unauthorized)
            return null;

        if (response.StatusCode == HttpStatusCode.TooManyRequests)
        {
            string retryAfter = response.Headers.RetryAfter?.Delta is TimeSpan delay
                ? $" Try again in {Math.Ceiling(delay.TotalSeconds)} seconds."
                : string.Empty;
            throw new HttpRequestException(
                $"Too many login attempts.{retryAfter}",
                null,
                response.StatusCode);
        }

        if (!response.IsSuccessStatusCode)
            throw new HttpRequestException(
                await response.Content.ReadAsStringAsync(cancellationToken),
                null,
                response.StatusCode);

        return await response.Content.ReadFromJsonAsync<LoginResponseDTO>(
            cancellationToken: cancellationToken)
            ?? throw new InvalidDataException("The authentication response was empty.");
    }

    public async Task<LoginResponseDTO?> RefreshAsync(
        string refreshToken,
        CancellationToken cancellationToken = default)
    {
        using HttpResponseMessage response = await _httpClient.PostAsJsonAsync(
            ApiRoutes.Auth.Refresh,
            new RefreshTokenRequestDTO { RefreshToken = refreshToken },
            cancellationToken);

        if (response.StatusCode == HttpStatusCode.Unauthorized)
            return null;

        if (!response.IsSuccessStatusCode)
            throw new HttpRequestException(
                await response.Content.ReadAsStringAsync(cancellationToken),
                null,
                response.StatusCode);

        return await response.Content.ReadFromJsonAsync<LoginResponseDTO>(
            cancellationToken: cancellationToken)
            ?? throw new InvalidDataException("The token refresh response was empty.");
    }

    public async Task LogoutAsync(CancellationToken cancellationToken = default)
    {
        string? refreshToken = CurrentUser.RefreshToken;
        if (refreshToken is null)
            return;

        using HttpResponseMessage response = await _httpClient.PostAsJsonAsync(
            ApiRoutes.Auth.Logout,
            new RefreshTokenRequestDTO { RefreshToken = refreshToken },
            cancellationToken);

        if (!response.IsSuccessStatusCode)
            throw new HttpRequestException(
                await response.Content.ReadAsStringAsync(cancellationToken),
                null,
                response.StatusCode);
    }
}
