using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem.DTOs.People
{
    public class PeopleViewDTO
    {
        public int PersonId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public PeopleViewDTO()
        {
            PersonId = -1;
            FullName = string.Empty;
            Email = string.Empty;
            Phone = string.Empty;
            Gender = string.Empty;
            BirthDate = DateTime.Now;
        }
    }
}
