using System.Net;
using System.Net.Http.Headers;

namespace BankSystem.WinForms.Helpers;

internal sealed class AuthTokenHandler(HttpMessageHandler innerHandler) : DelegatingHandler(innerHandler)
{
    protected override async Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage request,
        CancellationToken cancellationToken)
    {
        string? accessToken = CurrentUser.AccessToken;
        HttpRequestMessage? retryRequest = accessToken is null
            ? null
            : await CloneRequestAsync(request, cancellationToken);

        if (accessToken is not null)
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

        try
        {
            HttpResponseMessage response = await base.SendAsync(request, cancellationToken);
            if (response.StatusCode != HttpStatusCode.Unauthorized || accessToken is null)
                return response;

            bool refreshed;
            try
            {
                refreshed = await CurrentUser.RefreshIfUnchangedAsync(accessToken, cancellationToken);
            }
            catch
            {
                response.Dispose();
                throw;
            }

            if (!refreshed)
                return response;

            response.Dispose();
            string refreshedAccessToken = CurrentUser.AccessToken
                ?? throw new InvalidOperationException("The refreshed session has no access token.");
            retryRequest!.Headers.Authorization =
                new AuthenticationHeaderValue("Bearer", refreshedAccessToken);

            HttpResponseMessage retryResponse = await base.SendAsync(retryRequest, cancellationToken);
            if (retryResponse.StatusCode == HttpStatusCode.Unauthorized)
                CurrentUser.Clear();

            return retryResponse;
        }
        finally
        {
            retryRequest?.Dispose();
        }
    }

    private static async Task<HttpRequestMessage> CloneRequestAsync(
        HttpRequestMessage request,
        CancellationToken cancellationToken)
    {
        HttpRequestMessage clone = new(request.Method, request.RequestUri)
        {
            Version = request.Version,
            VersionPolicy = request.VersionPolicy
        };

        foreach (KeyValuePair<string, IEnumerable<string>> header in request.Headers)
        {
            if (!string.Equals(header.Key, "Authorization", StringComparison.OrdinalIgnoreCase))
                clone.Headers.TryAddWithoutValidation(header.Key, header.Value);
        }

        if (request.Content is not null)
        {
            byte[] content = await request.Content.ReadAsByteArrayAsync(cancellationToken);
            clone.Content = new ByteArrayContent(content);
            foreach (KeyValuePair<string, IEnumerable<string>> header in request.Content.Headers)
                clone.Content.Headers.TryAddWithoutValidation(header.Key, header.Value);
        }

        return clone;
    }
}
