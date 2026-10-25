using BankSystem.Shared;

namespace BankSystem.Business.Interfaces;

public interface IPeopleService
{
    Task<bool> AddNewPersonAsync(Person newPerson, CancellationToken cancellationToken);
    Task<bool> UpdatePersonAsync(Person updatePerson, CancellationToken cancellationToken);
    Task<Person?> GetPersonAsync(int personId, CancellationToken cancellationToken);
    Task<bool> DeletePersonAsync(int personId, CancellationToken cancellationToken);
    Task<bool> IsPersonExistAsync(int personId, CancellationToken cancellationToken);
    Task<List<PersonView>> GetAllPeopleAsync(CancellationToken cancellationToken);
}
