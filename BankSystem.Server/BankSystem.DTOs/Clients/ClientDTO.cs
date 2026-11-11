using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem.DTOs.Clients
{
    public class ClientDTO
    {
        public int ClientId { get; set; }
        public int AccountNumber { get; set; }
        public int PersonId { get; set; }
        public decimal Balance { get; set; }
    }
}
