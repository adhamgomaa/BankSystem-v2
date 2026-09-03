using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem.DTOs.Clients
{
    public class ClientDTO
    {
        public int clientId { get; set; }
        public int accountNumber { get; set; }
        public int pinCode { get; set; }
        public int personId { get; set; }
        public decimal balance { get; set; }
        public ClientDTO()
        {
            clientId = -1;
            accountNumber = 0;
            pinCode = 0;
            personId = -1;
            balance = 0;
        }
    }
}
