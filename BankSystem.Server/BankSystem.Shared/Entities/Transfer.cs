using System;

namespace BankSystem.Shared.Entities;

public class Transfer
{
    public int TransferID { get; set; }
    public DateTime TransferDate { get; set; } = DateTime.UtcNow;
    public int SenderAcc { get; set; }
    public int ReceiverAcc { get; set; }
    public decimal Amount { get; set; }
    public int CreatedByUserID { get; set; }
    public User User { get; set; } = null!;
}
