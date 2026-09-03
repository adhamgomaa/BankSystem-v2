using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem.WinForms.Helpers
{
    public static class ApiRoutes
    {
        public static class Client
        {
            public const string GetAll = "Client/All";
            public const string GetId = "Client/{0}";
            public const string Update = "Client/{0}";
            public const string Delete = "Client/{0}";
            public const string GetAccNum = "Client/AccountNumber/{0}";
            public const string IsExist = "Client/Exist/{0}";
            public const string GetBalance = "Client/Balance/{0}";
            public const string GetTotalBalances = "Client/TotalBalances";
            public const string Deposit = "Client/Deposit";
            public const string Withdraw = "Client/Withdrawal";
            public const string Add = "Client";
        }

        public static class People
        {
            public const string GetAll = "People/All";
            public const string GetId = "People/{0}";
            public const string Update = "People/{0}";
            public const string Delete = "People/{0}";
            public const string IsExist = "People/Exist/{0}";
            public const string Add = "People";
        }

        public static class Registration
        {
            public const string GetAll = "Registeration/All";
            public const string Add = "Registeration";
        }

        public static class Transfer
        {
            public const string GetAll = "Transfer/All";
            public const string Add = "Transfer";
        }

        public static class User
        {
            public const string GetAll = "User/All";
            public const string Login = "User/Login";
            public const string GetId = "User/{0}";
            public const string Update = "User/{0}";
            public const string Delete = "User/{0}";
            public const string GetUsername = "User/username/{0}";
            public const string IsExist = "User/Exist/{0}";
            public const string Add = "User";
        }
    }
}
