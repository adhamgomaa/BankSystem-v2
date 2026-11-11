using BankSystem.Shared.Entities;

namespace BankSystem.DataAccess.Interfaces;

public interface IRefreshTokenData
{
    Task<int> AddAsync(
        RefreshToken newToken,
        CancellationToken cancellationToken);

    Task<RefreshToken?> GetByHashAsync(string tokenHash, CancellationToken cancellationToken);

    Task RevokeAsync(string tokenHash, CancellationToken cancellationToken);

    Task RevokeFamilyAsync(int userId, Guid tokenFamilyId, CancellationToken cancellationToken);

    Task<int> RotateAsync(
        int oldRefreshTokenId,
        string oldTokenHash,
        string newTokenHash,
        DateTime newExpiresAt,
        CancellationToken cancellationToken);
}
