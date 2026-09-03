using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem.DTOs.Transfer
{
    public class CreateTransferDTO
    {
        public int senderAccount { get; set; }
        public int receiverAccount { get; set; }
        public decimal amount { get; set; }
        public int userId { get; set; }

        public CreateTransferDTO()
        {
            senderAccount = 0;
            receiverAccount = 0;
            amount = 0;
            userId = -1;
        }

        public CreateTransferDTO(int senderAccount, int receiverAccount, decimal amount, int userId)
        {
            this.senderAccount = senderAccount;
            this.receiverAccount = receiverAccount;
            this.amount = amount;
            this.userId = userId;
        }
    }
}
