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
using BankSystem.DataAccess.Interfaces;

namespace BankSystem.DataAccess.Implementations
{
    public sealed class PeopleDataAccess(DataAccessSettings settings) : IPeopleDataAccess
    {
        public async Task<Person?> GetPersonAsync(int id, CancellationToken cancellationToken)
        {
            try
            {
                await using (SqlConnection connection = new SqlConnection(settings.ConnectionString))
                {
                    await using (SqlCommand command = new SqlCommand("SP_FindPersonById", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@personId", id);
                        await connection.OpenAsync(cancellationToken);
                        await using (SqlDataReader reader = await command.ExecuteReaderAsync(cancellationToken))
                        {
                            if (await reader.ReadAsync(cancellationToken))
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
                throw;
            }
        }

        public async Task<int> AddNewPersonAsync(Person newPerson, CancellationToken cancellationToken)
        {
            int personId = -1;
            try
            {
                await using (SqlConnection connection = new SqlConnection(settings.ConnectionString))
                {
                    await using (SqlCommand command = new SqlCommand("SP_AddPerson", connection))
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
                        await connection.OpenAsync(cancellationToken);
                        await command.ExecuteNonQueryAsync(cancellationToken);
                        personId = (int)outputId.Value;
                    }
                }
            }
            catch (SqlException)
            {
                throw;
            }
            return personId;
        }

        public async Task<bool> UpdatePersonAsync(Person updatePerson, CancellationToken cancellationToken)
        {
            int rowAffected = 0;
            try
            {
                await using (SqlConnection connection = new SqlConnection(settings.ConnectionString))
                {
                    await using (SqlCommand command = new SqlCommand("SP_UpdatePerson", connection))
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

        public async Task<bool> DeletePersonAsync(int id, CancellationToken cancellationToken)
        {
            int rowAffected = 0;
            try
            {
                await using (SqlConnection connection = new SqlConnection(settings.ConnectionString))
                {
                    await using (SqlCommand command = new SqlCommand("SP_DeletePerson", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@personId", id);
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

        public async Task<bool> IsPersonExistAsync(int id, CancellationToken cancellationToken)
        {
            bool isFound = false;
            try
            {
                await using (SqlConnection connection = new SqlConnection(settings.ConnectionString))
                {
                    await using (SqlCommand command = new SqlCommand("SP_IsPersonExist", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@personId", id);
                        await connection.OpenAsync(cancellationToken);
                        await using (SqlDataReader reader = await command.ExecuteReaderAsync(cancellationToken))
                        {
                            if (await reader.ReadAsync(cancellationToken))
                                isFound = true;
                        }
                    }
                }
            }
            catch (SqlException)
            {
                throw;
            }
            return isFound;
        }

        public async Task<List<PersonView>> GetAllPeopleAsync(CancellationToken cancellationToken)
        {
            List<PersonView> list = new List<PersonView>();
            try
            {
                await using (SqlConnection connection = new SqlConnection(settings.ConnectionString))
                {
                    await using (SqlCommand command = new SqlCommand("SP_GetAllPeople", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        await connection.OpenAsync(cancellationToken);
                        await using (SqlDataReader reader = await command.ExecuteReaderAsync(cancellationToken))
                        {
                            while (await reader.ReadAsync(cancellationToken))
                            {
                                list.Add(new PersonView
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
                throw;
            }
            return list;
        }
    }
}
