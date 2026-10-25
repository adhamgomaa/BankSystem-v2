using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem.Shared
{
    public class ClientView
    {
        public int clientId { get; set; }
        public int accountNumber { get; set; }
        public string fullName { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public decimal balance { get; set; }
        public ClientView()
        {
            clientId = -1;
            accountNumber = 0;
            fullName = string.Empty;
            email = string.Empty;
            phone = string.Empty;
            balance = 0;
        }

        public ClientView(int clientId, int accountNumber, string fullName, string email, string phone, decimal balance)
        {
            this.clientId = clientId;
            this.accountNumber = accountNumber;
            this.fullName = fullName;
            this.email = email;
            this.phone = phone;
            this.balance = balance;
        }
    }
}
