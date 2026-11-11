using System;

namespace BankSystem.Shared.Entities;

public partial class Client
{
    public int ClientID { get; set; }
    public int AccountNumber { get; set; }
    public int PersonID { get; set; }
    public int PinCode { get; set; }
    public decimal Balance { get; set; }
    public Person Person { get; set; } = null!;
}
