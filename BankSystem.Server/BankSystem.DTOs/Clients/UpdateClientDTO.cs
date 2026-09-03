using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem.DTOs.Clients
{
    public class UpdateClientDTO
    {
        public int accountNumber { get; set; }
        public int pinCode { get; set; }
        public decimal balance { get; set; }
        public UpdateClientDTO()
        {
            accountNumber = 0;
            pinCode = 0;
            balance = 0;
        }
    }
}
