using BankSystem.Business.Interfaces;
using BankSystem.DataAccess.Interfaces;
using BankSystem.Shared;

namespace BankSystem.Business.Implementations
{
    public sealed class UserService(IUserDataAccess userDataAccess) : IUserService
    {
        public async Task<bool> AddUserAsync(User newUser, CancellationToken cancellationToken)
        {
            if (await userDataAccess.UserIsExistAsync(newUser.username, cancellationToken))
                return false;
            newUser.password = PasswordHasher.HashPassword(newUser.password);
            newUser.userId = await userDataAccess.AddNewUserAsync(newUser, cancellationToken);
            return newUser.userId != -1;
        }

        public async Task<bool> UpdateUserAsync(User updatedUser, CancellationToken cancellationToken)
        {
            updatedUser.password = PasswordHasher.HashPassword(updatedUser.password);
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

        public async Task<int> UsersCountAsync(CancellationToken cancellationToken)
        {
            return (await GetAllUsersAsync(cancellationToken)).Count;
        }

        public Task<bool> IsUserExistAsync(int userId, CancellationToken cancellationToken) =>
            userDataAccess.UserIsExistAsync(userId, cancellationToken);

        public Task<bool> IsUserExistAsync(string username, CancellationToken cancellationToken) =>
            userDataAccess.UserIsExistAsync(username, cancellationToken);
    }
}
