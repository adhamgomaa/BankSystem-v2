using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem.Shared
{
    public class Transfer
    {
        public int transferId {  get; set; }
        public DateTime transferDate { get; set; }
        public int senderAccount {  get; set; }
        public int receiverAccount { get; set; }
        public decimal amount { get; set; }
        public int userId { get; set; }

        public Transfer()
        {
            transferId = -1;
            transferDate = DateTime.Now;
            senderAccount = 0;
            receiverAccount = 0;
            amount = 0;
            userId = -1;
        }

        public Transfer(int transferId, DateTime transferDate, int senderAccount, int receiverAccount, decimal amount, int userId)
        {
            this.transferId = transferId;
            this.transferDate = transferDate;
            this.senderAccount = senderAccount;
            this.receiverAccount = receiverAccount;
            this.amount = amount;
            this.userId = userId;
        }
    }
}
