using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem.DTOs.Clients
{
    public class UpdateClientDTO
    {
        [Required]
        public int accountNumber { get; set; }
        [Required]
        public int pinCode { get; set; }
        [Required]
        public decimal balance { get; set; }
        public UpdateClientDTO()
        {
            accountNumber = 0;
            pinCode = 0;
            balance = 0;
        }
    }
}
