using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem.DTOs.Users
{
    public class UpdateUserDTO
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
