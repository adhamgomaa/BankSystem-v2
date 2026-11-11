using BankSystem.Shared.Entities;

namespace BankSystem.Business.Interfaces;

public interface ILoginAttemptService
{
    Task RecordAsync(
        LoginAttempt newLogin,
        CancellationToken cancellationToken);

    Task<IReadOnlyList<LoginAttempt>> GetRecentAsync(
        int take,
        CancellationToken cancellationToken);
}
