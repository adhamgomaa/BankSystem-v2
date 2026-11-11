namespace BankSystem.Shared.Entities;

public class ClientView
{
    public int ClientId { get; set; }
    public int AccountNumber { get; set; }
    public required string FullName { get; set; }
    public required string Email { get; set; }
    public required string Phone { get; set; }
    public decimal Balance { get; set; }
}

