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
