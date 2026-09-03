using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem.WinForms.Helpers
{
    public static class ApiClient
    {
        public static readonly HttpClient httpClient = new HttpClient
        {
            BaseAddress = new Uri(AppConfiguration.BaseApiUrl)
        };
    }
}
