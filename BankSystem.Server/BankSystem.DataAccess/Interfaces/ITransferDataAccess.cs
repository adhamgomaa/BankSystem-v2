using BankSystem.Shared;

namespace BankSystem.DataAccess.Interfaces;

public interface ITransferDataAccess
{
    Task<List<Transfer>> GetAllTransferAsync(CancellationToken cancellationToken);
    Task<bool> AddNewTransferAsync(Transfer newTransfer, CancellationToken cancellationToken);
}
