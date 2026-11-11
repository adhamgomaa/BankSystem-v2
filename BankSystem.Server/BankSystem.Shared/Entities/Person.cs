using System;

namespace BankSystem.Shared.Entities;

public partial class Person
{
    public int PersonID { get; set; }
    public required string FirstName { get; set; }
    public required string SecondName { get; set; }
    public required string LastName { get; set; }
    public required string Email { get; set; }
    public required string Phone { get; set; }
    public bool Gender { get; set; }
    public DateTime BirthDate { get; set; }
    public Client? Client { get; set; }
    public User? User { get; set; }
}
