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
        //public static int UserId { get; set; }
        //public static int PersonId { get; set; }
        //public static string Username { get; set; } = string.Empty;
        //public static string Password { get; set; } = string.Empty;
        //public static int Permissions { get; set; }
        //public static bool IsActive { get; set; }
    }
}
