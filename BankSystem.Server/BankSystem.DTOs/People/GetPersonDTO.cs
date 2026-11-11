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
        public required string FirstName { get; set; }
        public required string SecondName { get; set; }
        public required string LastName { get; set; }
        public required string Email { get; set; }
        public required string Phone { get; set; }
        public required string Gender { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
