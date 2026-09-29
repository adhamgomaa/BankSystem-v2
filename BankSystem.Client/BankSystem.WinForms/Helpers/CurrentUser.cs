using BankSystem.DTOs.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem.WinForms.Helpers
{
    public static class CurrentUser
    {
        public static LoginUserDTO? User { get; set; }
    }
}
