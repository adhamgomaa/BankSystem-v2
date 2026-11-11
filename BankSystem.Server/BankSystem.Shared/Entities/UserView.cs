namespace BankSystem.Shared.Entities;

public class UserView
{
    public int UserId { get; set; }
    public int PersonId { get; set; }
    public required string Username { get; set; }
    public required string FullName { get; set; }
    public required string Email { get; set; }
    public required string Phone { get; set; }
    public int Permissions { get; set; }
    public bool IsActive { get; set; }
}
