using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem.DTOs.People
{
    public class PeopleDTO
    {
        public int PersonId { get; set; }
        public string FirstName { private get; set; }
        public string SecondName { private get; set; }
        public string LastName { private get; set; }
        public string FullName => FirstName + ' ' + SecondName + ' ' + LastName; 
        public string Email { get; set; }
        public string Phone { get; set; }
        public byte GenderByte { private get; set; }
        public string Gender => GenderByte == 0 ? "Male" : "Female";
        public DateTime BirthDate { get; set; }
        public PeopleDTO()
        {
            PersonId = -1;
            FirstName = string.Empty;
            SecondName = string.Empty;
            LastName = string.Empty;
            Email = string.Empty;
            Phone = string.Empty;
            GenderByte = 0;
            BirthDate = DateTime.Now;
        }
    }
}
