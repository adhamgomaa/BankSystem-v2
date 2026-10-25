using BankSystem.Business.Interfaces;
using BankSystem.DataAccess.Interfaces;
using BankSystem.Shared;

namespace BankSystem.Business.Implementations
{
    public sealed class PeopleService(IPeopleDataAccess peopleDataAccess) : IPeopleService
    {
        public async Task<bool> AddNewPersonAsync(Person newPerson, CancellationToken cancellationToken)
        {
            newPerson.personId = await peopleDataAccess.AddNewPersonAsync(newPerson, cancellationToken);
            return newPerson.personId != -1;
        }
        public Task<bool> UpdatePersonAsync(Person updatePerson, CancellationToken cancellationToken) =>
            peopleDataAccess.UpdatePersonAsync(updatePerson, cancellationToken);
        public Task<Person?> GetPersonAsync(int personId, CancellationToken cancellationToken) =>
            peopleDataAccess.GetPersonAsync(personId, cancellationToken);

        public Task<bool> DeletePersonAsync(int personId, CancellationToken cancellationToken) =>
            peopleDataAccess.DeletePersonAsync(personId, cancellationToken);

        public Task<bool> IsPersonExistAsync(int personId, CancellationToken cancellationToken) =>
            peopleDataAccess.IsPersonExistAsync(personId, cancellationToken);

        public Task<List<PersonView>> GetAllPeopleAsync(CancellationToken cancellationToken) =>
            peopleDataAccess.GetAllPeopleAsync(cancellationToken);
    }
}
