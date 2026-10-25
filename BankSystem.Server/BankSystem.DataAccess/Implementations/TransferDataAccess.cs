using Microsoft.Data.SqlClient;
using BankSystem.Shared;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankSystem.DataAccess.Interfaces;

namespace BankSystem.DataAccess.Implementations
{
    public sealed class TransferDataAccess(DataAccessSettings settings) : ITransferDataAccess
    {
        public async Task<List<Transfer>> GetAllTransferAsync(CancellationToken cancellationToken)
        {
            List<Transfer> list = new List<Transfer>();
            try
            {
                await using (SqlConnection connection = new SqlConnection(settings.ConnectionString))
                {
                    await using (SqlCommand command = new SqlCommand("SP_TransferLog", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        await connection.OpenAsync(cancellationToken);
                        await using (SqlDataReader reader = await command.ExecuteReaderAsync(cancellationToken))
                        {
                            while (await reader.ReadAsync(cancellationToken))
                            {
                                list.Add(new Transfer
                                (
                                    reader.GetInt32(reader.GetOrdinal("TransferID")),
                                    reader.GetDateTime(reader.GetOrdinal("TransferDate")),
                                    reader.GetInt32(reader.GetOrdinal("SenderAcc")),
                                    reader.GetInt32(reader.GetOrdinal("ReceiverAcc")),
                                    reader.GetDecimal(reader.GetOrdinal("Amount")),
                                    reader.GetInt32(reader.GetOrdinal("CreatedByUserID"))
                                ));
                            }
                        }
                    }
                }
            }
            catch (SqlException)
            {
                throw;
            }
            return list;
        }

        public async Task<bool> AddNewTransferAsync(Transfer newTransfer, CancellationToken cancellationToken)
        {
            int transferId = -1;
            try
            {
                await using (SqlConnection connection = new SqlConnection(settings.ConnectionString))
                {
                    await using (SqlCommand command = new SqlCommand("SP_Transfer", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@FromAccNum", newTransfer.senderAccount);
                        command.Parameters.AddWithValue("@ToAccNum", newTransfer.receiverAccount);
                        command.Parameters.AddWithValue("@amount", newTransfer.amount);
                        command.Parameters.AddWithValue("@userId", newTransfer.userId);
                        SqlParameter outputId = new SqlParameter("@transferId", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };
                        command.Parameters.Add(outputId);
                        await connection.OpenAsync(cancellationToken);
                        await command.ExecuteNonQueryAsync(cancellationToken);
                        transferId = (int)outputId.Value;
                    }
                }
            }
            catch (SqlException)
            {
                throw;
            }
            return transferId != -1;
        }
    }
}
