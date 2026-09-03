using BankSystem.DTOs.People;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem.DTOs.Users
{
    public class UserDTO
    {
        public int userId { get; set; }
        public int personId { get; set; }
        public string username { get; set; }
        public int permissions { get; set; } 
        public bool isActive { get; set; }

        public UserDTO()
        {
            userId = -1;
            personId = -1;
            username = string.Empty;
            permissions = 0;
            isActive = false;
        }
    }
}
