using BankSystem.Shared;

namespace BankSystem.DataAccess.Interfaces;

public interface IClientDataAccess
{
    Task<Client?> GetClientAsync(int id, CancellationToken cancellationToken);
    Task<Client?> GetClientByAccNumAsync(int accountNumber, CancellationToken cancellationToken);
    Task<int> AddNewClientAsync(Client newClient, CancellationToken cancellationToken);
    Task<bool> UpdateClientAsync(Client updatedClient, CancellationToken cancellationToken);
    Task<bool> DeleteClientAsync(int clientId, CancellationToken cancellationToken);
    Task<List<ClientView>> GetAllClientsAsync(CancellationToken cancellationToken);
    Task<bool> ClientIsExistAsync(int clientId, CancellationToken cancellationToken);
    Task<decimal> GetBalanceByAccountNumberAsync(int accountNumber, CancellationToken cancellationToken);
    Task<decimal> GetTotalBalancesAsync(CancellationToken cancellationToken);
    Task<bool> DepositAsync(int accountNumber, decimal amount, CancellationToken cancellationToken);
    Task<bool> WithdrawalAsync(int accountNumber, decimal amount, CancellationToken cancellationToken);
}
