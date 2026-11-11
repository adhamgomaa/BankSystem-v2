using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem.DTOs.Transfer
{
    public class TransferDTO
    {
        public int TransferId { get; set; }
        public DateTime TransferDate { get; set; }
        public int SenderAccount { get; set; }
        public int ReceiverAccount { get; set; }
        public decimal Amount { get; set; }
        public int UserId { get; set; }
    }
}
