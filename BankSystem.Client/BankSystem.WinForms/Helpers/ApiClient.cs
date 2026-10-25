using System.Net.Http;

namespace BankSystem.WinForms.Helpers
{
    public static class ApiClient
    {
        internal static readonly HttpClient authHttpClient = new()
        {
            BaseAddress = new Uri(AppConfiguration.BaseApiUrl)
        };

        public static readonly HttpClient httpClient = new(new AuthTokenHandler(new HttpClientHandler()))
        {
            BaseAddress = new Uri(AppConfiguration.BaseApiUrl)
        };
    }
}
