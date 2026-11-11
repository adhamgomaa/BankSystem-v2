using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem.DTOs.Clients
{
    public class ClientViewDTO
    {
        public int ClientId { get; set; }
        public int AccountNumber { get; set; }
        public required string FullName { get; set; }
        public required string Email { get; set; }
        public required string Phone { get; set; }
        public decimal Balance { get; set; }
    }
}
