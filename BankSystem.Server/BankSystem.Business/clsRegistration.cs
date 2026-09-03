using BankSystem.DataAccess;
using BankSystem.Shared;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem.Business
{
    public class clsRegistration
    {
        public static bool AddNewRegister(int userId)
        {
            return clsRegistrationData.AddNewRegister(userId) != -1;
        }

        public static List<RegistrationView> GetAllRegisters()
        {
            return clsRegistrationData.GetAllRegisters();
        }
    }
}
