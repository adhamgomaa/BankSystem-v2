using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem.DTOs.Users
{
    public class UpdateUserDTO
    {
        public int personId { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public int permissions { get; set; }
        public bool isActive { get; set; }

        public UpdateUserDTO()
        {
            personId = -1;
            username = string.Empty;
            password = string.Empty;
            permissions = 0;
            isActive = false;
        }
    }
}
