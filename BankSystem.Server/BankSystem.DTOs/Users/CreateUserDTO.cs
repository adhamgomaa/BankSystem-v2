using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem.DTOs.Users
{
    public class CreateUserDTO
    {
        public int personId { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public int permissions { get; set; }
        public bool isActive { get; set; }

        public CreateUserDTO()
        {
            personId = -1;
            username = string.Empty;
            password = string.Empty;
            permissions = 0;
            isActive = false;
        }

        public CreateUserDTO(int personId, string username, string password, int permissions, bool isActive)
        {
            this.personId = personId;
            this.username = username;
            this.password = password;
            this.permissions = permissions;
            this.isActive = isActive;
        }
    }
}
