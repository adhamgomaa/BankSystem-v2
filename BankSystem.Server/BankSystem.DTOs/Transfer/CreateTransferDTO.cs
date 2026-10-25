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
        public int senderAccount { get; set; }
        [Required]
        public int receiverAccount { get; set; }
        [Required]
        public decimal amount { get; set; }
        [Required]
        public int userId { get; set; }

        public CreateTransferDTO()
        {
            senderAccount = 0;
            receiverAccount = 0;
            amount = 0;
            userId = -1;
        }
    }
}
