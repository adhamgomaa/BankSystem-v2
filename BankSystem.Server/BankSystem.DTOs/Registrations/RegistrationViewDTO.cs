using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem.DTOs.Registerations
{
    public class RegistrationViewDTO
    {
        public int registerId { get; set; }
        public int userId { get; set; }
        public string username { get; set; }
        public int permissions { get; set; }
        public DateTime registerationDate { get; set; }

        public RegistrationViewDTO()
        {
            registerId = -1;
            userId = -1;
            username = string.Empty;
            permissions = 0;
            registerationDate = DateTime.Now;
        }
    }
}
