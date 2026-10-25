using BankSystem.Shared;

namespace BankSystem.DataAccess.Interfaces;

public interface IUserDataAccess
{
    Task<User?> GetUserAsync(int id, CancellationToken cancellationToken);
    Task<User?> GetUserAsync(string username, CancellationToken cancellationToken);
    Task<int> AddNewUserAsync(User newUser, CancellationToken cancellationToken);
    Task<bool> UpdateUserAsync(User updateUser, CancellationToken cancellationToken);
    Task<bool> DeleteUserAsync(int userId, CancellationToken cancellationToken);
    Task<List<UserView>> GetAllUsersAsync(CancellationToken cancellationToken);
    Task<bool> UserIsExistAsync(int userId, CancellationToken cancellationToken);
    Task<bool> UserIsExistAsync(string username, CancellationToken cancellationToken);
}
