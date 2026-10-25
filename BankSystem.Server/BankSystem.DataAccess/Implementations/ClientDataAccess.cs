using BankSystem.Shared;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankSystem.DataAccess.Interfaces;

namespace BankSystem.DataAccess.Implementations
{
    public sealed class ClientDataAccess(DataAccessSettings settings) : IClientDataAccess
    {
        public async Task<Client?> GetClientAsync(int id, CancellationToken cancellationToken)
        {
            try
            {
                await using (SqlConnection connection = new SqlConnection(settings.ConnectionString))
                {
                    await using (SqlCommand command = new SqlCommand("SP_FindClientById", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@clientId", id);
                        await connection.OpenAsync(cancellationToken);
                        await using (SqlDataReader reader = await command.ExecuteReaderAsync(cancellationToken))
                        {
                            if (await reader.ReadAsync(cancellationToken))
                            {
                                return new Client
                                (
                                    reader.GetInt32(reader.GetOrdinal("ClientID")),
                                    reader.GetInt32(reader.GetOrdinal("AccountNumber")),
                                    reader.GetInt32(reader.GetOrdinal("PersonID")),
                                    reader.GetInt32(reader.GetOrdinal("PinCode")),
                                    reader.GetDecimal(reader.GetOrdinal("Balance"))
                                );
                            }
                            else
                                return null;
                        }
                    }
                }
            }
            catch (SqlException)
            {
                throw;
            }
        }

        public async Task<Client?> GetClientByAccNumAsync(int accountNumber, CancellationToken cancellationToken)
        {
            try
            {
                await using (SqlConnection connection = new SqlConnection(settings.ConnectionString))
                {
                    await using (SqlCommand command = new SqlCommand("SP_FindClientByAccNum", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@accNum", accountNumber);
                        await connection.OpenAsync(cancellationToken);
                        await using (SqlDataReader reader = await command.ExecuteReaderAsync(cancellationToken))
                        {
                            if (await reader.ReadAsync(cancellationToken))
                            {
                                return new Client
                                (
                                    reader.GetInt32(reader.GetOrdinal("ClientID")),
                                    reader.GetInt32(reader.GetOrdinal("AccountNumber")),
                                    reader.GetInt32(reader.GetOrdinal("PersonID")),
                                    reader.GetInt32(reader.GetOrdinal("PinCode")),
                                    reader.GetDecimal(reader.GetOrdinal("Balance"))
                                );
                            }
                            else
                                return null;
                        }
                    }
                }
            }
            catch (SqlException)
            {
                throw;
            }
        }

        public async Task<int> AddNewClientAsync(Client newClient, CancellationToken cancellationToken)
        {
            int ClientID = -1;
            try
            {
                await using (SqlConnection connection = new SqlConnection(settings.ConnectionString))
                {
                    await using (SqlCommand command = new SqlCommand("SP_AddNewClient", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@accNum", newClient.accountNumber);
                        command.Parameters.AddWithValue("@personId", newClient.personId);
                        command.Parameters.AddWithValue("@pinCode", newClient.pinCode);
                        command.Parameters.AddWithValue("@balance", newClient.balance);
                        SqlParameter outputId = new SqlParameter("@clientId", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };
                        command.Parameters.Add(outputId);
                        await connection.OpenAsync(cancellationToken);
                        await command.ExecuteNonQueryAsync(cancellationToken);
                        ClientID = (int)outputId.Value;
                    }
                }
            }
            catch (SqlException)
            {
                throw;
            }
            return ClientID;
        }
        public async Task<bool> UpdateClientAsync(Client updatedClient, CancellationToken cancellationToken)
        {
            int rowAffected = 0;
            try
            {
                await using (SqlConnection connection = new SqlConnection(settings.ConnectionString))
                {
                    await using (SqlCommand command = new SqlCommand("SP_UpdateClient", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@accNum", updatedClient.accountNumber);
                        command.Parameters.AddWithValue("@personId", updatedClient.personId);
                        command.Parameters.AddWithValue("@pinCode", updatedClient.pinCode);
                        command.Parameters.AddWithValue("@balance", updatedClient.balance);
                        command.Parameters.AddWithValue("@clientId", updatedClient.clientId);
                        await connection.OpenAsync(cancellationToken);
                        rowAffected = await command.ExecuteNonQueryAsync(cancellationToken);
                    }
                }
            }
            catch (SqlException)
            {
                throw;
            }
            return rowAffected > 0;
        }

        public async Task<bool> DeleteClientAsync(int clientId, CancellationToken cancellationToken)
        {
            int rowAffected = 0;
            try
            {
                await using (SqlConnection connection = new SqlConnection(settings.ConnectionString))
                {
                    await using (SqlCommand command = new SqlCommand("SP_DeleteClient", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@clientId", clientId);
                        await connection.OpenAsync(cancellationToken);
                        rowAffected = await command.ExecuteNonQueryAsync(cancellationToken);
                    }
                }
            }
            catch (SqlException)
            {
                throw;
            }
            return rowAffected > 0;
        }

        public async Task<List<ClientView>> GetAllClientsAsync(CancellationToken cancellationToken)
        {
            List<ClientView> clients = new List<ClientView>();
            await using (SqlConnection connection = new SqlConnection(settings.ConnectionString))
            {
                await using (SqlCommand command = new SqlCommand("SP_GetAllClients", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    await connection.OpenAsync(cancellationToken);
                    await using (SqlDataReader reader = await command.ExecuteReaderAsync(cancellationToken))
                    {
                        while (await reader.ReadAsync(cancellationToken))
                        {
                            clients.Add(new ClientView
                            (
                                reader.GetInt32(reader.GetOrdinal("ClientID")),
                                reader.GetInt32(reader.GetOrdinal("AccountNumber")),
                                reader.GetString(reader.GetOrdinal("FullName")),
                                reader.GetString(reader.GetOrdinal("Email")),
                                reader.GetString(reader.GetOrdinal("Phone")),
                                reader.GetDecimal(reader.GetOrdinal("Balance"))
                            ));
                        }
                    }
                }
            }
            return clients;
        }
        public async Task<bool> ClientIsExistAsync(int ClientId, CancellationToken cancellationToken)
        {
            bool isExist = false;
            try
            {
                await using (SqlConnection connection = new SqlConnection(settings.ConnectionString))
                {
                    await using (SqlCommand command = new SqlCommand("SP_ClientIsExists", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@clientId", ClientId);
                        await connection.OpenAsync(cancellationToken);
                        await using (SqlDataReader reader = await command.ExecuteReaderAsync(cancellationToken))
                        {
                            if (await reader.ReadAsync(cancellationToken))
                            {
                                isExist = true;
                            }
                        }
                    }
                }
            }
            catch (SqlException)
            {
                throw;
            }
            return isExist;
        }
        public async Task<decimal> GetBalanceByAccountNumberAsync(int accountNumber, CancellationToken cancellationToken)
        {
            decimal balance = 0;
            try
            {
                await using (SqlConnection connection = new SqlConnection(settings.ConnectionString))
                {
                    await using (SqlCommand command = new SqlCommand("SP_GetClientBalance", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@accNum", accountNumber);
                        SqlParameter output = new SqlParameter("@balance", SqlDbType.Decimal)
                        {
                            Direction = ParameterDirection.Output
                        };
                        command.Parameters.Add(output);
                        await connection.OpenAsync(cancellationToken);
                        await command.ExecuteNonQueryAsync(cancellationToken);
                        balance = (decimal)output.Value;
                    }
                }
            }
            catch (SqlException)
            {
                throw;
            }
            return balance;
        }
        public async Task<decimal> GetTotalBalancesAsync(CancellationToken cancellationToken)
        {
            decimal balance = 0;
            try
            {
                await using (SqlConnection connection = new SqlConnection(settings.ConnectionString))
                {
                    await using (SqlCommand command = new SqlCommand("SP_GetTotalBalance", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        SqlParameter output = new SqlParameter("@totalBalance", SqlDbType.Decimal)
                        {
                            Direction = ParameterDirection.Output
                        };
                        command.Parameters.Add(output);
                        await connection.OpenAsync(cancellationToken);
                        await command.ExecuteNonQueryAsync(cancellationToken);
                        balance = (decimal)output.Value;
                    }
                }
            }
            catch (SqlException)
            {
                throw;
            }
            return balance;
        }

        public async Task<bool> DepositAsync(int AccNum, decimal amount, CancellationToken cancellationToken)
        {
            int rowAffected = 0;
            try
            {
                await using (SqlConnection connection = new SqlConnection(settings.ConnectionString))
                {
                    await using (SqlCommand command = new SqlCommand("SP_Deposit", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@accNum", AccNum);
                        command.Parameters.AddWithValue("@amount", amount);
                        await connection.OpenAsync(cancellationToken);
                        rowAffected = await command.ExecuteNonQueryAsync(cancellationToken);
                    }
                }
            }
            catch (SqlException)
            {
                throw;
            }
            return rowAffected > 0;
        }

        public async Task<bool> WithdrawalAsync(int AccNum, decimal amount, CancellationToken cancellationToken)
        {
            int rowAffected = 0;
            try
            {
                await using (SqlConnection connection = new SqlConnection(settings.ConnectionString))
                {
                    await using (SqlCommand command = new SqlCommand("SP_Withdrawal", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@accNum", AccNum);
                        command.Parameters.AddWithValue("@amount", amount);
                        await connection.OpenAsync(cancellationToken);
                        rowAffected = await command.ExecuteNonQueryAsync(cancellationToken);
                    }
                }
            }
            catch (SqlException)
            {
                throw;
            }
            return rowAffected > 0;
        }
    }
}
