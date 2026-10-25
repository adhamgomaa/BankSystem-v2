using BankSystem.Shared;

namespace BankSystem.Business.Interfaces;

public interface ITransferService
{
    Task<bool> AddNewTransferAsync(Transfer newTransfer, CancellationToken cancellationToken);
    Task<List<Transfer>> GetAllTransfersAsync(CancellationToken cancellationToken);
}
