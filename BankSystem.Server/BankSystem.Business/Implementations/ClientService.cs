using BankSystem.Business.Interfaces;
using BankSystem.DataAccess.Interfaces;
using BankSystem.Shared;

namespace BankSystem.Business.Implementations
{
    public sealed class ClientService(IClientDataAccess clientDataAccess) : IClientService
    {
        public async Task<bool> AddNewClientAsync(Client newClient, CancellationToken cancellationToken)
        {
            newClient.clientId = await clientDataAccess.AddNewClientAsync(newClient, cancellationToken);
            return newClient.clientId != -1;
        }

        public Task<bool> UpdateClientAsync(Client updatedClient, CancellationToken cancellationToken) =>
            clientDataAccess.UpdateClientAsync(updatedClient, cancellationToken);

        public Task<Client?> GetClientByIDAsync(int clientId, CancellationToken cancellationToken) =>
            clientDataAccess.GetClientAsync(clientId, cancellationToken);
        public Task<Client?> GetClientByAccNumAsync(int accNum, CancellationToken cancellationToken) =>
            clientDataAccess.GetClientByAccNumAsync(accNum, cancellationToken);

        public Task<bool> DeleteClientAsync(int clientId, CancellationToken cancellationToken) =>
            clientDataAccess.DeleteClientAsync(clientId, cancellationToken);

        public Task<List<ClientView>> GetAllClientsAsync(CancellationToken cancellationToken) =>
            clientDataAccess.GetAllClientsAsync(cancellationToken);

        public async Task<int> GetAllClientsCountAsync(CancellationToken cancellationToken)
        {
            return (await GetAllClientsAsync(cancellationToken)).Count;
        }

        public Task<bool> IsClientExistAsync(int clientId, CancellationToken cancellationToken) =>
            clientDataAccess.ClientIsExistAsync(clientId, cancellationToken);

        public Task<decimal> GetBalanceByAccNumAsync(int accNum, CancellationToken cancellationToken) =>
            clientDataAccess.GetBalanceByAccountNumberAsync(accNum, cancellationToken);

        public Task<decimal> GetTotalBalancesAsync(CancellationToken cancellationToken) =>
            clientDataAccess.GetTotalBalancesAsync(cancellationToken);

        public Task<bool> DepositAsync(int accNum, decimal amount, CancellationToken cancellationToken) =>
            clientDataAccess.DepositAsync(accNum, amount, cancellationToken);

        public Task<bool> WithdrawalAsync(int accNum, decimal amount, CancellationToken cancellationToken) =>
            clientDataAccess.WithdrawalAsync(accNum, amount, cancellationToken);
    }
}
