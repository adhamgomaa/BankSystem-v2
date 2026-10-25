namespace BankSystem.Shared;

public sealed class RefreshToken
{
    public int RefreshTokenId { get; init; }
    public int UserId { get; init; }
    public string TokenHash { get; init; } = string.Empty;
    public DateTime CreatedAt { get; init; }
    public DateTime ExpiresAt { get; init; }
    public DateTime? RevokedAt { get; init; }
    public int? ReplacedByTokenId { get; init; }
    public Guid TokenFamilyId { get; init; }
}
