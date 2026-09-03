using BankSystem.Shared;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem.DataAccess
{
    public class clsClientData
    {

        public static Client? GetClient(int id)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_FindClientById", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@clientId", id);
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
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
                return null;
                //clsLogger.LoggingAllExepctions(ex.Message, System.Diagnostics.EventLogEntryType.Error);
            }
        }

        public static Client? GetClientByAccNum(int accountNumber)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_FindClientByAccNum", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@accNum", accountNumber);
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
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
                return null;
                //clsLogger.LoggingAllExepctions(ex.Message, System.Diagnostics.EventLogEntryType.Error);
            }
        }

        public static int AddNewClient(Client newClient)
        {
            int ClientID = -1;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_AddNewClient", connection))
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
                        connection.Open();
                        command.ExecuteNonQuery();
                        ClientID = (int)outputId.Value;
                    }
                }
            }
            catch (SqlException)
            {
                ClientID = -1;
                //clsLogger.LoggingAllExepctions(ex.Message, System.Diagnostics.EventLogEntryType.Error);
            }
            return ClientID;
        }
        public static bool UpdateClient(Client updatedClient)
        {
            int rowAffected = 0;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_UpdateClient", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@accNum", updatedClient.accountNumber);
                        command.Parameters.AddWithValue("@personId", updatedClient.personId);
                        command.Parameters.AddWithValue("@pinCode", updatedClient.pinCode);
                        command.Parameters.AddWithValue("@balance", updatedClient.balance);
                        command.Parameters.AddWithValue("@clientId", updatedClient.clientId);
                        connection.Open();
                        rowAffected = command.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException)
            {
                rowAffected = 0;
                //clsLogger.LoggingAllExepctions(ex.Message, System.Diagnostics.EventLogEntryType.Error);
            }
            return rowAffected > 0;
        }

        public static bool DeleteClient(int clientId)
        {
            int rowAffected = 0;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_DeleteClient", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@clientId", clientId);
                        connection.Open();
                        rowAffected = command.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException)
            {
                //clsLogger.LoggingAllExepctions(ex.Message, System.Diagnostics.EventLogEntryType.Error);
                return false;
            }
            return rowAffected > 0;
        }

        public static List<ClientView> GetAllClients()
        {
            List<ClientView> clients = new List<ClientView>();
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_GetAllClients", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
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
            }
            catch (Exception)
            {
                //clsLogger.LoggingAllExepctions(ex.Message, System.Diagnostics.EventLogEntryType.Error);
            }
            return clients;
        }
        public static bool ClientIsExist(int ClientId)
        {
            bool isExist = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_ClientIsExists", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@clientId", ClientId);
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                isExist = true;
                            }
                        }
                    }
                }
            }
            catch (SqlException)
            {
                isExist = false;
                //clsLogger.LoggingAllExepctions(ex.Message, System.Diagnostics.EventLogEntryType.Error);
            }
            return isExist;
        }
        public static decimal GetBalanceByAccountNumber(int accountNumber)
        {
            decimal balance = 0;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_GetClientBalance", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@accNum", accountNumber);
                        SqlParameter output = new SqlParameter("@balance", SqlDbType.Decimal)
                        {
                            Direction = ParameterDirection.Output
                        };
                        command.Parameters.Add(output);
                        connection.Open();
                        command.ExecuteNonQuery();
                        balance = (decimal)output.Value;
                    }
                }
            }
            catch (SqlException)
            {
                //clsLogger.LoggingAllExepctions(ex.Message, System.Diagnostics.EventLogEntryType.Error);
            }
            return balance;
        }
        public static decimal GetTotalBalances()
        {
            decimal balance = 0;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_GetTotalBalance", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        SqlParameter output = new SqlParameter("@totalBalance", SqlDbType.Decimal)
                        {
                            Direction = ParameterDirection.Output
                        };
                        command.Parameters.Add(output);
                        connection.Open();
                        command.ExecuteNonQuery();
                        balance = (decimal)output.Value;
                    }
                }
            }
            catch (SqlException)
            {
                //clsLogger.LoggingAllExepctions(ex.Message, System.Diagnostics.EventLogEntryType.Error);
            }
            return balance;
        }

        public static bool Deposit(int AccNum, decimal amount)
        {
            int rowAffected = 0;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_Deposit", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@accNum", AccNum);
                        command.Parameters.AddWithValue("@amount", amount);
                        connection.Open();
                        rowAffected = command.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException)
            {
                //clsLogger.LoggingAllExepctions(ex.Message, System.Diagnostics.EventLogEntryType.Error);
                return false;
            }
            return rowAffected > 0;
        }

        public static bool Withdrawal(int AccNum, decimal amount)
        {
            int rowAffected = 0;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_Withdrawal", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@accNum", AccNum);
                        command.Parameters.AddWithValue("@amount", amount);
                        connection.Open();
                        rowAffected = command.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException)
            {
                //clsLogger.LoggingAllExepctions(ex.Message, System.Diagnostics.EventLogEntryType.Error);
                return false;
            }
            return rowAffected > 0;
        }
    }
}
