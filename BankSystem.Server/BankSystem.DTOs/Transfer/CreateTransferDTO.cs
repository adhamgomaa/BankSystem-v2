using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem.DTOs.Transfer
{
    public class CreateTransferDTO
    {
        [Required]
        public int SenderAccount { get; set; }
        [Required]
        public int ReceiverAccount { get; set; }
        [Required]
        public decimal Amount { get; set; }
        [Required]
        public int UserId { get; set; }
    }
}
