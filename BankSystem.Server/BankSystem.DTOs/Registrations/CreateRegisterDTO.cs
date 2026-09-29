using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem.DTOs.Registerations
{
    public class CreateRegisterDTO
    {
        [Required]
        public int UserID { get; set; }
    }
}
