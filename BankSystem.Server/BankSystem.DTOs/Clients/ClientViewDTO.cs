using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem.DTOs.Clients
{
    public class ClientViewDTO
    {
        public int clientId { get; set; }
        public int accountNumber { get; set; }
        public string fullName { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public decimal balance { get; set; }
        public ClientViewDTO()
        {
            clientId = -1;
            accountNumber = 0;
            fullName = string.Empty;
            email = string.Empty;
            phone = string.Empty;
            balance = 0;
        }
    }
}
