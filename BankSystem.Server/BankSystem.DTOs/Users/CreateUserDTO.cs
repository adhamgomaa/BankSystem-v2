using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace BankSystem.DTOs.Users
{
    public class CreateUserDTO
    {
        [Required]
        public int personId { get; set; }
        [Required]
        public string username { get; set; }
        [Required]
        public string password { get; set; }
        [Required]
        public int permissions { get; set; }
        [Required]
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
