using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem.DTOs.Users
{
    public class GetUserDTO
    {
        public int UserId { get; set; }
        public int PersonId { get; set; }
        public required string Username { get; set; }
        public int Permissions { get; set; }
        public bool IsActive { get; set; }
    }
}
