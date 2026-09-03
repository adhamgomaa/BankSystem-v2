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
    public class clsRegistrationData
    {
        public static List<RegistrationView> GetAllRegisters()
        {
            List<RegistrationView> registers = new List<RegistrationView>();
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_GetAllRegisters", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                registers.Add(new RegistrationView
                                (
                                    reader.GetInt32(reader.GetOrdinal("RegisterID")),
                                    reader.GetInt32(reader.GetOrdinal("UserID")),
                                    reader.GetString(reader.GetOrdinal("UserName")),
                                    reader.GetInt32(reader.GetOrdinal("Permissions")),
                                    reader.GetDateTime(reader.GetOrdinal("RegisterationDate"))
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
            return registers;
        }
        public static int AddNewRegister(int userId)
        {
            int registerId = -1;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_LoginLog", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@userId", userId);
                        SqlParameter outputId = new SqlParameter("@registerId", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };
                        command.Parameters.Add(outputId);
                        connection.Open();
                        command.ExecuteNonQuery();
                        registerId = (int)outputId.Value;
                    }
                }
            }
            catch (SqlException)
            {
                //clsLogger.LoggingAllExepctions(ex.Message, System.Diagnostics.EventLogEntryType.Error);
            }
            return registerId;
        }
    }
}
