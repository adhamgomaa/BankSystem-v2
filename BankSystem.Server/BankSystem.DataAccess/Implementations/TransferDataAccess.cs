using Microsoft.Data.SqlClient;
using BankSystem.Shared.Entities;
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
    public sealed class TransferDataAccess(BankDbContext context) : ITransferDataAccess
    {
        public async Task<List<Transfer>> GetAllTransferAsync(CancellationToken cancellationToken)
        {
            var transfers = await context.Transfers
                            .AsNoTracking()
                            .Select(t => new Transfer
                            {
                                TransferID = t.TransferID,
                                TransferDate = t.TransferDate,
                                SenderAcc = t.SenderAcc,
                                ReceiverAcc = t.ReceiverAcc,
                                Amount = t.Amount,
                                CreatedByUserID = t.CreatedByUserID
                            })
                            .OrderBy(t => t.TransferDate)
                            .ToListAsync(cancellationToken);
            return transfers;
        }

        public async Task<bool> AddNewTransferAsync(Transfer newTransfer, CancellationToken cancellationToken)
        {
            await using var transaction = await context.Database.BeginTransactionAsync(cancellationToken);
            try
            {
                var Sender = await context.Clients
                                .SingleOrDefaultAsync(c => c.AccountNumber == newTransfer.SenderAcc, cancellationToken);
                var Receiver = await context.Clients
                                .SingleOrDefaultAsync(c => c.AccountNumber == newTransfer.ReceiverAcc, cancellationToken);
                if (Sender is null || Receiver is null || Sender.Balance < newTransfer.Amount)
                    return false;

                Sender.Balance -= newTransfer.Amount;
                Receiver.Balance += newTransfer.Amount;
                context.Transfers.Add(newTransfer);
                await context.SaveChangesAsync(cancellationToken);
                await transaction.CommitAsync(cancellationToken);
                return newTransfer.TransferID != -1;
            } catch
            {
                await transaction.RollbackAsync(cancellationToken);
                return false;
            }
        }
    }
}
