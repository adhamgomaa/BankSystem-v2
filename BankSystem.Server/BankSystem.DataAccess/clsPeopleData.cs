using BankSystem.Shared;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BankSystem.DataAccess
{
    public class clsPeopleData
    {
        public static Person? GetPerson(int id)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_FindPersonById", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@personId", id);
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new Person
                                (
                                    reader.GetInt32(reader.GetOrdinal("PersonID")),
                                    reader.GetString(reader.GetOrdinal("FirstName")),
                                    reader.GetString(reader.GetOrdinal("SecondName")),
                                    reader.GetString(reader.GetOrdinal("LastName")),
                                    reader.GetString(reader.GetOrdinal("Email")),
                                    reader.GetString(reader.GetOrdinal("Phone")),
                                    reader.GetByte(reader.GetOrdinal("Gender")),
                                    reader.GetDateTime(reader.GetOrdinal("BirthDate"))
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

        public static int AddNewPerson(Person newPerson)
        {
            int personId = -1;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_AddPerson", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@fname", newPerson.firstName);
                        command.Parameters.AddWithValue("@secname", newPerson.secondName);
                        command.Parameters.AddWithValue("@lname", newPerson.lastName);
                        command.Parameters.AddWithValue("@email", newPerson.email);
                        command.Parameters.AddWithValue("@phone", newPerson.phone);
                        command.Parameters.AddWithValue("@gender", newPerson.gender);
                        command.Parameters.AddWithValue("@date", newPerson.birthDate);
                        SqlParameter outputId = new SqlParameter("@personId", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };
                        command.Parameters.Add(outputId);
                        connection.Open();
                        command.ExecuteNonQuery();
                        personId = (int)outputId.Value;
                    }
                }
            }
            catch (SqlException)
            {
                personId = -1;
                //clsLogger.LoggingAllExepctions(ex.Message, System.Diagnostics.EventLogEntryType.Error);
            }
            return personId;
        }

        public static bool UpdatePerson(Person updatePerson)
        {
            int rowAffected = 0;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_UpdatePerson", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@fname", updatePerson.firstName);
                        command.Parameters.AddWithValue("@secname", updatePerson.secondName);
                        command.Parameters.AddWithValue("@lname", updatePerson.lastName);
                        command.Parameters.AddWithValue("@email", updatePerson.email);
                        command.Parameters.AddWithValue("@phone", updatePerson.phone);
                        command.Parameters.AddWithValue("@gender", updatePerson.gender);
                        command.Parameters.AddWithValue("@date", updatePerson.birthDate);
                        command.Parameters.AddWithValue("@personId", updatePerson.personId);
                        connection.Open();
                        rowAffected = command.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException)
            {
                //clsLogger.LoggingAllExepctions(ex.Message, System.Diagnostics.EventLogEntryType.Error);
            }
            return rowAffected > 0;
        }

        public static bool DeletePerson(int id)
        {
            int rowAffected = 0;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_DeletePerson", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@personId", id);
                        connection.Open();
                        rowAffected = command.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException)
            {
                //clsLogger.LoggingAllExepctions(ex.Message, System.Diagnostics.EventLogEntryType.Error);
            }
            return rowAffected > 0;
        }

        public static bool IsPersonExist(int id)
        {
            bool isFound = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_IsPersonExist", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@personId", id);
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                                isFound = true;
                        }
                    }
                }
            }
            catch (SqlException)
            {
                //clsLogger.LoggingAllExepctions(ex.Message, System.Diagnostics.EventLogEntryType.Error);
            }
            return isFound;
        }

        public static List<PeopleView> GetAllPeople()
        {
            List<PeopleView> list = new List<PeopleView>();
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_GetAllPeople", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                list.Add(new PeopleView
                                (
                                    reader.GetInt32(reader.GetOrdinal("PersonID")),
                                    reader.GetString(reader.GetOrdinal("FullName")),
                                    reader.GetString(reader.GetOrdinal("Email")),
                                    reader.GetString(reader.GetOrdinal("Phone")),
                                    reader.GetString(reader.GetOrdinal("Gender")),
                                    reader.GetDateTime(reader.GetOrdinal("BirthDate"))
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
    }
}
