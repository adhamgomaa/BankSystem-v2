using BankSystem.DataAccess;
using BankSystem.Shared;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem.Business
{
    public class clsPeople
    {
        public static bool AddNewPerson(Person newPerson)
        {
            newPerson.personId = clsPeopleData.AddNewPerson(newPerson);
            return newPerson.personId != -1;
        }
        public static bool UpdatePerson(Person updatePerson)
        {
            return clsPeopleData.UpdatePerson(updatePerson);
        }
        public static Person? GetPerson(int personId)
        {
            Person? person = clsPeopleData.GetPerson(personId);
            if (person != null)
                return person;
            return null;
        }

        public static bool DeletePerson(int personId)
        {
            return clsPeopleData.DeletePerson(personId);
        }

        public static bool IsPersonExist(int personId)
        {
            return clsPeopleData.IsPersonExist(personId);
        }

        public static List<PeopleView> GetAllPeople()
        {
            return clsPeopleData.GetAllPeople();
        }
    }
}
