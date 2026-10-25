using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem.DTOs.People
{
    public class GetPersonDTO
    {
        public int PersonId { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public byte Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public GetPersonDTO()
        {
            PersonId = -1;
            FirstName = string.Empty;
            SecondName = string.Empty;
            LastName = string.Empty;
            Email = string.Empty;
            Phone = string.Empty;
            Gender = 0;
            BirthDate = DateTime.Now;
        }
    }
}
