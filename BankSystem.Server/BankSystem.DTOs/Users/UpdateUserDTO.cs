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
        public int PersonId { get; set; }
        [Required]
        public required string Username { get; set; }
        [Required]
        public required string Password { get; set; }
        [Required]
        public int Permissions { get; set; }
        [Required]
        public bool IsActive { get; set; }
    }
}
