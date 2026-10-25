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
    public sealed class UserDataAccess(DataAccessSettings settings) : IUserDataAccess
    {
        public async Task<User?> GetUserAsync(int id, CancellationToken cancellationToken)
        {
            try
            {
                await using (SqlConnection connection = new SqlConnection(settings.ConnectionString))
                {
                    await using (SqlCommand command = new SqlCommand("SP_FindUserById", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@userId", id);
                        await connection.OpenAsync(cancellationToken);
                        await using (SqlDataReader reader = await command.ExecuteReaderAsync(cancellationToken))
                        {
                            if (await reader.ReadAsync(cancellationToken))
                            {
                                return new User
                                (
                                    reader.GetInt32(reader.GetOrdinal("UserID")),
                                    reader.GetInt32(reader.GetOrdinal("PersonID")),
                                    reader.GetString(reader.GetOrdinal("UserName")),
                                    reader.GetString(reader.GetOrdinal("Password")),
                                    reader.GetInt32(reader.GetOrdinal("Permissions")),
                                    reader.GetBoolean(reader.GetOrdinal("isActive"))
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
        public async Task<User?> GetUserAsync(string username, CancellationToken cancellationToken)
        {
            try
            {
                await using (SqlConnection connection = new SqlConnection(settings.ConnectionString))
                {
                    await using (SqlCommand command = new SqlCommand("SP_FindUserByUsername", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@username", username);
                        await connection.OpenAsync(cancellationToken);
                        await using (SqlDataReader reader = await command.ExecuteReaderAsync(cancellationToken))
                        {
                            if (await reader.ReadAsync(cancellationToken))
                            {
                                return new User
                                (
                                    reader.GetInt32(reader.GetOrdinal("UserID")),
                                    reader.GetInt32(reader.GetOrdinal("PersonID")),
                                    reader.GetString(reader.GetOrdinal("UserName")),
                                    reader.GetString(reader.GetOrdinal("Password")),
                                    reader.GetInt32(reader.GetOrdinal("Permissions")),
                                    reader.GetBoolean(reader.GetOrdinal("isActive"))
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
        public async Task<int> AddNewUserAsync(User newUser, CancellationToken cancellationToken)
        {
            int userId = -1;
            try
            {
                await using (SqlConnection connection = new SqlConnection(settings.ConnectionString))
                {
                    await using (SqlCommand command = new SqlCommand("SP_AddNewUser", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@personId", newUser.personId);
                        command.Parameters.AddWithValue("@username", newUser.username);
                        command.Parameters.AddWithValue("@password", newUser.password);
                        command.Parameters.AddWithValue("@permission", newUser.permissions);
                        command.Parameters.AddWithValue("@isActive", newUser.isActive);
                        SqlParameter outputId = new SqlParameter("@userId", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };
                        command.Parameters.Add(outputId);
                        await connection.OpenAsync(cancellationToken);
                        await command.ExecuteNonQueryAsync(cancellationToken);
                        userId = (int)outputId.Value;
                    }
                }
            }
            catch (SqlException)
            {
                throw;
            }
            return userId;
        }
        public async Task<bool> UpdateUserAsync(User updateUser, CancellationToken cancellationToken)
        {
            int rowAffected = 0;
            try
            {
                await using (SqlConnection connection = new SqlConnection(settings.ConnectionString))
                {
                    await using (SqlCommand command = new SqlCommand("SP_UpdateUser", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@personId", updateUser.personId);
                        command.Parameters.AddWithValue("@username", updateUser.username);
                        command.Parameters.AddWithValue("@password", updateUser.password);
                        command.Parameters.AddWithValue("@permission", updateUser.permissions);
                        command.Parameters.AddWithValue("@isActive", updateUser.isActive);
                        command.Parameters.AddWithValue("@userId", updateUser.userId);
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
        public async Task<bool> DeleteUserAsync(int userId, CancellationToken cancellationToken)
        {
            int rowAffected = 0;
            try
            {
                await using (SqlConnection connection = new SqlConnection(settings.ConnectionString))
                {
                    await using (SqlCommand command = new SqlCommand("SP_DeleteUser", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@userId", userId);
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
        public async Task<List<UserView>> GetAllUsersAsync(CancellationToken cancellationToken)
        {
            List<UserView> users = new List<UserView>();
            try
            {
                await using (SqlConnection connection = new SqlConnection(settings.ConnectionString))
                {
                    await using (SqlCommand command = new SqlCommand("SP_GetAllUsers", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        await connection.OpenAsync(cancellationToken);
                        await using (SqlDataReader reader = await command.ExecuteReaderAsync(cancellationToken))
                        {
                            while (await reader.ReadAsync(cancellationToken))
                            {
                                users.Add(new UserView
                                (
                                    reader.GetInt32(reader.GetOrdinal("UserID")),
                                    reader.GetInt32(reader.GetOrdinal("PersonID")),
                                    reader.GetString(reader.GetOrdinal("UserName")),
                                    reader.GetString(reader.GetOrdinal("Full Name")),
                                    reader.GetString(reader.GetOrdinal("Email")),
                                    reader.GetString(reader.GetOrdinal("Phone")),
                                    reader.GetInt32(reader.GetOrdinal("Permissions")),
                                    reader.GetBoolean(reader.GetOrdinal("isActive"))
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
            return users;
        }
        public async Task<bool> UserIsExistAsync(int userId, CancellationToken cancellationToken)
        {
            bool isExist = false;
            try
            {
                await using (SqlConnection connection = new SqlConnection(settings.ConnectionString))
                {
                    await using (SqlCommand command = new SqlCommand("SP_IsUserExist", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@userId", userId);
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

        public async Task<bool> UserIsExistAsync(string username, CancellationToken cancellationToken)
        {
            bool isExist = false;
            try
            {
                await using SqlConnection connection = new(settings.ConnectionString);
                await using SqlCommand command = new("SP_User_IsUsernameExist", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@username", username);
                await connection.OpenAsync(cancellationToken);
                await using SqlDataReader reader = await command.ExecuteReaderAsync(cancellationToken);
                    if (await reader.ReadAsync(cancellationToken))
                        isExist = true;
            }
            catch (SqlException)
            {
                throw;
            }
            return isExist;
        }
    }
}
