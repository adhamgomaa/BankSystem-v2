using BankSystem.Shared.Entities;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankSystem.DataAccess.Interfaces;
using BankSystem.DataAccess.Data;
using Microsoft.EntityFrameworkCore;

namespace BankSystem.DataAccess.Implementations
{
    public sealed class ClientDataAccess(BankDbContext context) : IClientDataAccess
    {
        public async Task<Client?> GetClientAsync(int id, CancellationToken cancellationToken)
        {
            var client = await context.Clients.FindAsync([id], cancellationToken);
            return client;
        }

        public async Task<Client?> GetClientByAccNumAsync(int accountNumber, CancellationToken cancellationToken)
        {
            var client = await context.Clients
                        .AsNoTracking()
                        .SingleOrDefaultAsync(c => c.AccountNumber == accountNumber, cancellationToken);
            return client;
        }

        public async Task<int> AddNewClientAsync(Client newClient, CancellationToken cancellationToken)
        {
            context.Clients.Add(newClient);
            await context.SaveChangesAsync(cancellationToken);
            return newClient.ClientID;
        }
        public async Task<bool> UpdateClientAsync(Client updatedClient, CancellationToken cancellationToken)
        {
            var client = await context.Clients.FindAsync([updatedClient.ClientID], cancellationToken);
            if(client is null)
                return false;
            client.AccountNumber = updatedClient.AccountNumber;
            client.Balance = updatedClient.Balance;
            client.PinCode = updatedClient.PinCode;
            client.PersonID = updatedClient.PersonID;

            return await context.SaveChangesAsync(cancellationToken) > 0;
        }

        public async Task<bool> DeleteClientAsync(int clientId, CancellationToken cancellationToken)
        {
            var client = await context.Clients.FindAsync([clientId], cancellationToken);
            if(client is null)
                return false;
            context.Clients.Remove(client);
            return await context.SaveChangesAsync(cancellationToken) > 0;
        }

        public async Task<List<ClientView>> GetAllClientsAsync(CancellationToken cancellationToken)
        {
            var clients = await context.Clients
                            .AsNoTracking()
                            .Select(c => new ClientView
                            {
                                ClientId = c.ClientID,
                                AccountNumber = c.AccountNumber,
                                FullName = c.Person.FirstName + " " + c.Person.SecondName + " " + c.Person.LastName,
                                Phone = c.Person.Phone,
                                Email = c.Person.Email,
                                Balance = c.Balance
                            })
                            .OrderBy(c => c.ClientId)
                            .ToListAsync(cancellationToken);
            return clients;
        }

        public async Task<int> GetCountAsync(CancellationToken cancellationToken)
        {
            int count = await context.Clients.AsNoTracking().CountAsync(cancellationToken);
            return count;
        }

        public async Task<bool> ClientIsExistAsync(int ClientId, CancellationToken cancellationToken)
        {
            bool isExist = await context.Clients.AsNoTracking().AnyAsync(c => c.ClientID == ClientId, cancellationToken);
            return isExist;
        }
        public async Task<decimal> GetBalanceByAccountNumberAsync(int accountNumber, CancellationToken cancellationToken)
        {
            var client = await context.Clients
                            .AsNoTracking()
                            .SingleOrDefaultAsync(c => c.AccountNumber == accountNumber, cancellationToken);
            if(client is not null)
                return client.Balance;
            return -1;
        }
        public async Task<decimal> GetTotalBalancesAsync(CancellationToken cancellationToken)
        {
            decimal balances = await context.Clients.AsNoTracking().SumAsync(c => c.Balance, cancellationToken);
            return balances;
        }

        public async Task<bool> DepositAsync(int AccNum, decimal amount, CancellationToken cancellationToken)
        {
            var client = await context.Clients.SingleOrDefaultAsync(c => c.AccountNumber == AccNum, cancellationToken);
            if(client is null)
                return false;
            client.Balance += amount;
            return await context.SaveChangesAsync(cancellationToken) > 0;
        }

        public async Task<bool> WithdrawalAsync(int AccNum, decimal amount, CancellationToken cancellationToken)
        {
            var client = await context.Clients.SingleOrDefaultAsync(c => c.AccountNumber == AccNum, cancellationToken);
            if (client is null || client.Balance < amount)
                return false;
            client.Balance -= amount;
            return await context.SaveChangesAsync(cancellationToken) > 0;
        }
    }
}
