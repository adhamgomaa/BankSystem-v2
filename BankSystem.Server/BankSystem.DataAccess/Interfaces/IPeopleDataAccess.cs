using BankSystem.Shared;

namespace BankSystem.DataAccess.Interfaces;

public interface IPeopleDataAccess
{
    Task<Person?> GetPersonAsync(int id, CancellationToken cancellationToken);
    Task<int> AddNewPersonAsync(Person newPerson, CancellationToken cancellationToken);
    Task<bool> UpdatePersonAsync(Person updatePerson, CancellationToken cancellationToken);
    Task<bool> DeletePersonAsync(int id, CancellationToken cancellationToken);
    Task<bool> IsPersonExistAsync(int id, CancellationToken cancellationToken);
    Task<List<PersonView>> GetAllPeopleAsync(CancellationToken cancellationToken);
}
