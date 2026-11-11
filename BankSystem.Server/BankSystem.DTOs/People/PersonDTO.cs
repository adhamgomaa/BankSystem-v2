using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem.DTOs.People
{
    public class PersonDTO
    {
        public int PersonId { get; set; }
        public required string FirstName { private get; set; }
        public required string SecondName { private get; set; }
        public required string LastName { private get; set; }
        public string FullName => FirstName + ' ' + SecondName + ' ' + LastName; 
        public required string Email { get; set; }
        public required string Phone { get; set; }
        public bool Gen { private get; set; }
        public string Gender => Gen ? "Female" : "Male";
        public DateTime BirthDate { get; set; }
    }
}
