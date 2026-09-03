using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace BankSystem.WinForms.Helpers
{
    public static class AppConfiguration
    {
        public static IConfiguration Configuration { get; }

        static AppConfiguration()
        {
            Configuration = new ConfigurationBuilder().SetBasePath(AppContext.BaseDirectory).AddJsonFile("appsettings.json", optional: false).Build();
        }

        public static string BaseApiUrl => Configuration["ApiSettings:BaseUrl"]!;
    }
}
