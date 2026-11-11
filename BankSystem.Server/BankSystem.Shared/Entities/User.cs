using System;

namespace BankSystem.Shared.Entities;

public partial class User
{
    public int UserID { get; set; }
    public int PersonID { get; set; }
    public required string UserName { get; set; }
    public required string Password { get; set; }
    public int Permissions { get; set; }
    public bool IsActive { get; set; }
    public Person Person { get; set; } = null!;
    public ICollection<Transfer> Transfers { get; set; } = new List<Transfer>();
    public ICollection<RefreshToken> RefreshTokens { get; set; } = new List<RefreshToken>();
}
