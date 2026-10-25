using BankSystem.Shared;

namespace BankSystem.Business.Interfaces;

public interface IUserService
{
    Task<bool> AddUserAsync(User newUser, CancellationToken cancellationToken);
    Task<bool> UpdateUserAsync(User updatedUser, CancellationToken cancellationToken);
    Task<User?> FindUserAsync(int userId, CancellationToken cancellationToken);
    Task<User?> FindUserAsync(string username, CancellationToken cancellationToken);
    Task<bool> DeleteUserAsync(int userId, CancellationToken cancellationToken);
    Task<List<UserView>> GetAllUsersAsync(CancellationToken cancellationToken);
    Task<int> UsersCountAsync(CancellationToken cancellationToken);
    Task<bool> IsUserExistAsync(int userId, CancellationToken cancellationToken);
    Task<bool> IsUserExistAsync(string username, CancellationToken cancellationToken);
}
