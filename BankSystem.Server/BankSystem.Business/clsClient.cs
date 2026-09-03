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
    public class clsClient
    {
        public static bool AddNewClient(Client newClient)
        {
            newClient.clientId = clsClientData.AddNewClient(newClient);
            return newClient.clientId != -1;
        }

        public static bool UpdateClient(Client updatedClient)
        {
            return clsClientData.UpdateClient(updatedClient);
        }

        public static Client? GetClientByID(int clientId)
        {
            Client? client = clsClientData.GetClient(clientId);
            if (client != null)
                return client;
            return null;
        }
        public static Client? GetClientByAccNum(int accNum)
        {
            Client? client = clsClientData.GetClientByAccNum(accNum);
            if (client != null)
                return client;
            return null;
        }

        public static bool DeleteClient(int clientId)
        {
            return clsClientData.DeleteClient(clientId);
        }

        public static List<ClientView> GetAllClients()
        {
            return clsClientData.GetAllClients();
        }

        public static int GetAllClientsCount()
        {
            return GetAllClients().Count;
        }

        public static bool IsClientExist(int ClientId)
        {
            return clsClientData.ClientIsExist(ClientId);
        }

        public static decimal GetBalanceByAccNum(int accNum)
        {
            return clsClientData.GetBalanceByAccountNumber(accNum);
        }

        public static decimal GetTotalBalances()
        {
            return clsClientData.GetTotalBalances();
        }

        public static bool Deposit(int accNum, decimal amount)
        {
            return clsClientData.Deposit(accNum, amount);
        }

        public static bool Withdrawal(int accNum, decimal amount)
        {
            return clsClientData.Withdrawal(accNum, amount);
        }
    }
}
