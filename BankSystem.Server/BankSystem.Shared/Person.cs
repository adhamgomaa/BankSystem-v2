using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem.Shared
{
    public class Person
    {
        public int personId { get; set; }
        public string firstName { get; set; }
        public string secondName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public byte gender { get; set; }
        public DateTime birthDate { get; set; }
        public Person()
        {
            personId = -1;
            firstName = string.Empty;
            secondName = string.Empty;
            lastName = string.Empty;
            email = string.Empty;
            phone = string.Empty;
            gender = 0;
            birthDate = DateTime.Now;
        }

        public Person(int personId, string firstName, string secondName, string lastName, string email, string phone, byte gender, DateTime date)
        {
            this.personId = personId;
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
