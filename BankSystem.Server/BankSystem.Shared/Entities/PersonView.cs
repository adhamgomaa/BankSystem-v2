using System;

namespace BankSystem.Shared.Entities;

public class PersonView
{
    public int PersonId { get; set; }
    public required string FullName { get; set; }
    public required string Email { get; set; }
    public required string Phone { get; set; }
    public required string Gender { get; set; }
    public DateTime BirthDate { get; set; }
}
