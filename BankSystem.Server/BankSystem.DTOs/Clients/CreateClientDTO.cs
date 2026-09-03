using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem.DTOs.Clients
{
    public class CreateClientDTO
    {
        public int accountNumber { get; set; }
        public int personId { get; set; }
        public int pinCode { get; set; }
        public decimal balance { get; set; }
        public CreateClientDTO()
        {
            accountNumber = 0;
            personId = -1;
            pinCode = 0;
            balance = 0;
        }

        public CreateClientDTO(int accountNumber, int personId, int pinCode, decimal balance)
        {
            this.accountNumber = accountNumber;
            this.personId = personId;
            this.pinCode = pinCode;
            this.balance = balance;
        }
    }
}
