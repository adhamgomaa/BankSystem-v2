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
        public int AccountNumber { get; set; }
        [Required]
        public int PinCode { get; set; }
        [Required]
        public decimal Balance { get; set; }
    }
}
