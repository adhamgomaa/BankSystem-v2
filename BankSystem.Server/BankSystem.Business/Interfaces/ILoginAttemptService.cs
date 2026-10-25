using BankSystem.Shared;

namespace BankSystem.Business.Interfaces;

public interface ILoginAttemptService
{
    Task RecordAsync(
        int? userId,
        string attemptedUserName,
        bool succeeded,
        string? clientIpAddress,
        CancellationToken cancellationToken);

    Task<IReadOnlyList<LoginAttempt>> GetRecentAsync(
        int take,
        CancellationToken cancellationToken);
}
