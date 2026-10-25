using BankSystem.Shared;

namespace BankSystem.Business.Interfaces;

public interface IClientService
{
    Task<bool> AddNewClientAsync(Client newClient, CancellationToken cancellationToken);
    Task<bool> UpdateClientAsync(Client updatedClient, CancellationToken cancellationToken);
    Task<Client?> GetClientByIDAsync(int clientId, CancellationToken cancellationToken);
    Task<Client?> GetClientByAccNumAsync(int accNum, CancellationToken cancellationToken);
    Task<bool> DeleteClientAsync(int clientId, CancellationToken cancellationToken);
    Task<List<ClientView>> GetAllClientsAsync(CancellationToken cancellationToken);
    Task<int> GetAllClientsCountAsync(CancellationToken cancellationToken);
    Task<bool> IsClientExistAsync(int clientId, CancellationToken cancellationToken);
    Task<decimal> GetBalanceByAccNumAsync(int accNum, CancellationToken cancellationToken);
    Task<decimal> GetTotalBalancesAsync(CancellationToken cancellationToken);
    Task<bool> DepositAsync(int accNum, decimal amount, CancellationToken cancellationToken);
    Task<bool> WithdrawalAsync(int accNum, decimal amount, CancellationToken cancellationToken);
}
