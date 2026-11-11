namespace BankSystem.Shared.Entities;

public partial class LoginAttempt
{
    public long LoginAttemptId { get; set; }
    public int? UserId { get; set; }
    public required string AttemptedUserName { get; set; }
    public bool Succeeded { get; set; }
    public DateTime AttemptedAtUtc { get; set; } = DateTime.UtcNow;
    public string? ClientIpAddress { get; set; }
}
