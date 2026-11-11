using BankSystem.Business.Interfaces;
using BankSystem.DataAccess.Interfaces;
using BankSystem.Shared.Entities;

namespace BankSystem.Business.Implementations
{
    public sealed class UserService(IUserDataAccess userDataAccess) : IUserService
    {
        public async Task<bool> AddUserAsync(User newUser, CancellationToken cancellationToken)
        {
            if (await userDataAccess.UserIsExistAsync(newUser.UserName, cancellationToken))
                return false;
            newUser.Password = PasswordHasher.HashPassword(newUser.Password);
            await userDataAccess.AddNewUserAsync(newUser, cancellationToken);
            return newUser.UserID != -1;
        }

        public async Task<bool> UpdateUserAsync(User updatedUser, CancellationToken cancellationToken)
        {
            updatedUser.Password = PasswordHasher.HashPassword(updatedUser.Password);
            return await userDataAccess.UpdateUserAsync(updatedUser, cancellationToken);
        }

        public Task<User?> FindUserAsync(int userId, CancellationToken cancellationToken) =>
            userDataAccess.GetUserAsync(userId, cancellationToken);

        public Task<User?> FindUserAsync(string username, CancellationToken cancellationToken) =>
            userDataAccess.GetUserAsync(username, cancellationToken);

        public Task<bool> DeleteUserAsync(int userId, CancellationToken cancellationToken) =>
            userDataAccess.DeleteUserAsync(userId, cancellationToken);

        public Task<List<UserView>> GetAllUsersAsync(CancellationToken cancellationToken) =>
            userDataAccess.GetAllUsersAsync(cancellationToken);

        public Task<int> UsersCountAsync(CancellationToken cancellationToken) =>
            userDataAccess.GetCount(cancellationToken);

        public Task<bool> IsUserExistAsync(int userId, CancellationToken cancellationToken) =>
            userDataAccess.UserIsExistAsync(userId, cancellationToken);

        public Task<bool> IsUserExistAsync(string username, CancellationToken cancellationToken) =>
            userDataAccess.UserIsExistAsync(username, cancellationToken);
    }
}
