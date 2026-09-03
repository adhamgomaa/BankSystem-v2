using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem.DTOs.People
{
    public class CreatePersonDTO
    {
        public string firstName { get; set; }
        public string secondName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public byte gender { get; set; }
        public DateTime birthDate { get; set; }
        public CreatePersonDTO()
        {
            firstName = string.Empty;
            secondName = string.Empty;
            lastName = string.Empty;
            email = string.Empty;
            phone = string.Empty;
            gender = 0;
            birthDate = DateTime.Now;
        }

        public CreatePersonDTO(string firstName, string secondName, string lastName, string email, string phone, byte gender, DateTime date)
        {
            this.firstName = firstName;
            this.secondName = secondName;
            this.lastName = lastName;
            this.email = email;
            this.phone = phone;
            this.gender = gender;
            this.birthDate = date;
        }
    }
}
