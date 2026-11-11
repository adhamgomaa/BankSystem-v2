using BankSystem.Shared.Entities;
using System.Data;
using BankSystem.DataAccess.Interfaces;
using BankSystem.DataAccess.Data;
using Microsoft.EntityFrameworkCore;

namespace BankSystem.DataAccess.Implementations
{
    public sealed class PeopleDataAccess(BankDbContext context) : IPeopleDataAccess
    {
        public async Task<Person?> GetPersonAsync(int id, CancellationToken cancellationToken)
        {
            var student = await context.People.FindAsync([id], cancellationToken: cancellationToken);
            return student;
        }

        public async Task<int> AddNewPersonAsync(Person newPerson, CancellationToken cancellationToken)
        {
            context.People.Add(newPerson);
            await context.SaveChangesAsync(cancellationToken);
            return newPerson.PersonID;
        }

        public async Task<bool> UpdatePersonAsync(Person updatePerson, CancellationToken cancellationToken)
        {
            var person = await context.People.FindAsync([updatePerson.PersonID], cancellationToken: cancellationToken);
            if (person is null)
                return false;
            person.FirstName = updatePerson.FirstName;
            person.SecondName = updatePerson.SecondName;
            person.LastName = updatePerson.LastName;
            person.Email = updatePerson.Email;
            person.Phone = updatePerson.Phone;
            person.Gender = updatePerson.Gender;
            person.BirthDate = updatePerson.BirthDate;
            return await context.SaveChangesAsync(cancellationToken) > 0;
        }

        public async Task<bool> DeletePersonAsync(int id, CancellationToken cancellationToken)
        {
            var person = await context.People.FindAsync([id], cancellationToken: cancellationToken);
            if (person is null)
                return false;
            context.People.Remove(person);
            return await context.SaveChangesAsync(cancellationToken) > 0;
        }

        public async Task<bool> IsPersonExistAsync(int id, CancellationToken cancellationToken)
        {
            bool isExist = await context.People.AnyAsync(p => p.PersonID == id, cancellationToken);
            return isExist;
        }

        public async Task<List<PersonView>> GetAllPeopleAsync(CancellationToken cancellationToken)
        {
            var people = await context.People
                    .AsNoTracking()
                    .Select(p => new PersonView
                    {
                        PersonId = p.PersonID,
                        FullName = p.FirstName + " " + p.SecondName + " " + p.LastName,
                        Email = p.Email,
                        Phone = p.Phone,
                        Gender = p.Gender ? "Female" : "Male",
                        BirthDate = p.BirthDate
                    })
                    .OrderBy(p => p.PersonId)
                    .ToListAsync(cancellationToken);
            return people;
        }
    }
}
