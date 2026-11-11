using BankSystem.Shared.Entities;
using Microsoft.Data.SqlClient;
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
    public sealed class UserDataAccess(BankDbContext context) : IUserDataAccess
    {
        public async Task<User?> GetUserAsync(int id, CancellationToken cancellationToken)
        {
            var user = await context.Users.FindAsync([id], cancellationToken: cancellationToken);
            return user;
        }     
        public async Task<User?> GetUserAsync(string username, CancellationToken cancellationToken)
        {
            var user = await context.Users.AsNoTracking().SingleOrDefaultAsync(u => u.UserName == username, cancellationToken);
            return user;
        } 
        public async Task<int> AddNewUserAsync(User newUser, CancellationToken cancellationToken)
        {
            context.Users.Add(newUser);
            await context.SaveChangesAsync(cancellationToken);
            return newUser.UserID;
        }
        public async Task<bool> UpdateUserAsync(User updateUser, CancellationToken cancellationToken)
        {
            var user = await context.Users.FindAsync([updateUser.UserID], cancellationToken);
            if(user is null)
                return false;
            user.UserName = updateUser.UserName;
            user.Password = updateUser.Password;
            user.Permissions = updateUser.Permissions;
            user.PersonID = updateUser.PersonID;
            user.IsActive = updateUser.IsActive;
            return await context.SaveChangesAsync(cancellationToken) > 0;
        }
        public async Task<bool> DeleteUserAsync(int userId, CancellationToken cancellationToken)
        {
            var user = await context.Users.FindAsync([userId], cancellationToken);
            if(user is null)
                return false;
            context.Users.Remove(user);
            return await context.SaveChangesAsync(cancellationToken) > 0;
        }
        public async Task<List<UserView>> GetAllUsersAsync(CancellationToken cancellationToken)
        {
            var users = await context.Users
                        .AsNoTracking()
                        .Select(u => new UserView
                        {
                            UserId = u.UserID,
                            PersonId = u.PersonID,
                            Username = u.UserName,
                            FullName = u.Person.FirstName + " " + u.Person.SecondName + " " + u.Person.LastName,
                            Phone = u.Person.Phone,
                            Email = u.Person.Email,
                            Permissions = u.Permissions,
                            IsActive = u.IsActive
                        })
                        .OrderBy(u => u.UserId)
                        .ToListAsync(cancellationToken);
            return users;
        }

        public async Task<int> GetCount(CancellationToken cancellationToken)
        {
            int count = await context.Users.AsNoTracking().CountAsync(cancellationToken);
            return count;
        }
        public async Task<bool> UserIsExistAsync(int userId, CancellationToken cancellationToken)
        {
            bool isExist = await context.Users.AsNoTracking().AnyAsync(u => u.UserID == userId, cancellationToken);
            return isExist;
        }

        public async Task<bool> UserIsExistAsync(string username, CancellationToken cancellationToken)
        {
            bool isExist = await context.Users.AsNoTracking().AnyAsync(u => u.UserName == username, cancellationToken);
            return isExist;
        }
    }
}
