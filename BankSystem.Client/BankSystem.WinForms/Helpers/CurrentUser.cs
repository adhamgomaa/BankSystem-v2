using System.Text.Json;
using BankSystem.DTOs.Auth;
using BankSystem.DTOs.Users;
using BankSystem.WinForms.Services;

namespace BankSystem.WinForms.Helpers
{
    public static class CurrentUser
    {
        private static readonly SemaphoreSlim RefreshLock = new(1, 1);

        public static GetUserDTO? User { get; private set; }
        internal static string? AccessToken { get; private set; }
        internal static string? RefreshToken { get; private set; }

        internal static bool HasPermission(BankPermission permission)
        {
            int userPermissions = User?.permissions ?? 0;
            int requiredPermission = (int)permission;

            return userPermissions == (int)BankPermission.FullAccess ||
                (userPermissions >= 0 &&
                (userPermissions & requiredPermission) == requiredPermission);
        }

        public static void SignIn(LoginResponseDTO tokens, string username)
        {
            ArgumentNullException.ThrowIfNull(tokens);

            using JsonDocument payload = ReadTokenPayload(tokens.AccessToken);
            JsonElement claims = payload.RootElement;
            User = new GetUserDTO
            {
                userId = ReadIntClaim(claims, "nameid", "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier"),
                username = username,
                permissions = ReadIntClaim(claims, "permissions"),
                isActive = true
            };
            AccessToken = tokens.AccessToken;
            RefreshToken = tokens.RefreshToken;
        }

        internal static async Task<bool> RefreshIfUnchangedAsync(
            string accessTokenUsed,
            CancellationToken cancellationToken)
        {
            await RefreshLock.WaitAsync(cancellationToken);
            try
            {
                if (!string.Equals(AccessToken, accessTokenUsed, StringComparison.Ordinal))
                    return AccessToken is not null;

                if (RefreshToken is null)
                {
                    Clear();
                    return false;
                }

                LoginResponseDTO? tokens = await new AuthApiService().RefreshAsync(RefreshToken, cancellationToken);
                if (tokens is null)
                {
                    Clear();
                    return false;
                }

                string username = User?.username
                    ?? throw new InvalidOperationException("Cannot refresh an authentication session without a user.");
                SignIn(tokens, username);
                return true;
            }
            finally
            {
                RefreshLock.Release();
            }
        }

        public static void Clear()
        {
            User = null;
            AccessToken = null;
            RefreshToken = null;
        }

        private static JsonDocument ReadTokenPayload(string token)
        {
            string[] segments = token.Split('.');
            if (segments.Length != 3)
                throw new InvalidDataException("The authentication response contained an invalid access token.");

            string payload = segments[1].Replace('-', '+').Replace('_', '/');
            payload = payload.PadRight(payload.Length + (4 - payload.Length % 4) % 4, '=');
            return JsonDocument.Parse(Convert.FromBase64String(payload));
        }

        private static int ReadIntClaim(JsonElement claims, params string[] names)
        {
            foreach (string name in names)
            {
                if (!claims.TryGetProperty(name, out JsonElement value))
                    continue;

                if (value.ValueKind == JsonValueKind.Number && value.TryGetInt32(out int number))
                    return number;
                if (value.ValueKind == JsonValueKind.String &&
                    int.TryParse(value.GetString(), out number))
                    return number;
            }

            throw new InvalidDataException("The access token is missing a required user claim.");
        }
    }
}
