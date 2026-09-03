using Microsoft.Data.SqlClient;
using BankSystem.Shared;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem.DataAccess
{
    public class clsTransferData
    {
        public static List<Transfer> GetAllTransfer()
        {
           List<Transfer> list = new List<Transfer>();
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_TransferLog", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
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
                //clsLogger.LoggingAllExepctions(ex.Message, System.Diagnostics.EventLogEntryType.Error);
            }
            return list;
        }

        public static bool AddNewTransfer(Transfer newTransfer)
        {
            int transferId = -1;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_Transfer", connection))
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
                        connection.Open();
                        command.ExecuteNonQuery();
                        transferId = (int)outputId.Value;
                    }
                }
            }
            catch (SqlException)
            {
                transferId = -1;
                //clsLogger.LoggingAllExepctions(ex.Message, System.Diagnostics.EventLogEntryType.Error);
            }
            return transferId != -1;
        }
    }
}
