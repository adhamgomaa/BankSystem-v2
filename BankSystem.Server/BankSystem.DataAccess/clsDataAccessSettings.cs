using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Microsoft.Extensions.Configuration;

namespace BankSystem.DataAccess
{
    public class clsDataAccessSettings
    {
        public static string ConnectionString { get; set; } = string.Empty;
    }
}
