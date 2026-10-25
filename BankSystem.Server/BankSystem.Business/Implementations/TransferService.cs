using BankSystem.Business.Interfaces;
using BankSystem.DataAccess.Interfaces;
using BankSystem.Shared;

namespace BankSystem.Business.Implementations
{
    public sealed class TransferService(ITransferDataAccess transferDataAccess) : ITransferService
    {
        public Task<bool> AddNewTransferAsync(Transfer newTransfer, CancellationToken cancellationToken) =>
            transferDataAccess.AddNewTransferAsync(newTransfer, cancellationToken);

        public Task<List<Transfer>> GetAllTransfersAsync(CancellationToken cancellationToken) =>
            transferDataAccess.GetAllTransferAsync(cancellationToken);
    }
}
