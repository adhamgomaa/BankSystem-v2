using BankSystem.Business.Interfaces;
using BankSystem.DTOs.People;
using BankSystem.Shared.Entities;
using BankSystem.API.Authorization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BankSystem.API.Controllers
{
    [Route("api/People")]
    [ApiController]
    [Authorize(Policy = PermissionPolicies.People)]
    public class PeopleController(IPeopleService peopleService) : ControllerBase
    {
        [HttpGet("All", Name = "GetAllPeople")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<PersonViewDTO>>> GetAllPeople(CancellationToken cancellationToken)
        {
            List<PersonView> people = await peopleService.GetAllPeopleAsync(cancellationToken);
            if (people.Count == 0)
                return NotFound("No People Found");
            var personDTO = people.Select(person => new PersonViewDTO
            {
                PersonId = person.PersonId,
                FullName = person.FullName,
                Email = person.Email,
                Phone = person.Phone,
                Gender = person.Gender,
                BirthDate = person.BirthDate
            }).ToList();
            return Ok(personDTO);
        }

        [HttpGet("{id}", Name = "GetPersonByID")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<GetPersonDTO>> GetPersonByID(int id, CancellationToken cancellationToken)
        {
            if (id < 1)
                return BadRequest("Invalid data");

            Person? person = await peopleService.GetPersonAsync(id, cancellationToken);

            if (person == null) return NotFound($"There's no person with this Id: {id}");

            GetPersonDTO personDTO = new()
            {
                PersonId = person.PersonID,
                FirstName = person.FirstName,
                SecondName = person.SecondName,
                LastName = person.LastName,
                Email = person.Email,
                Phone = person.Phone,
                Gender = person.Gender ? "Female" : "Male",
                BirthDate = person.BirthDate
            };

            return Ok(personDTO);
        }

        [HttpGet("Exist/{id}", Name = "IsPersonExist")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<bool>> IsPersonExist(int id, CancellationToken cancellationToken)
        {
            if (id < 1)
                return BadRequest("Invalid data");
            if (!await peopleService.IsPersonExistAsync(id, cancellationToken))
                return NotFound(false);
            return Ok(true);
        }

        [HttpPost(Name = "AddNewPerson")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<PersonDTO>> AddNewPerson(
            CreatePersonDTO createPerson,
            CancellationToken cancellationToken)
        {
            Person newPerson = new()
            {
                FirstName = createPerson.FirstName,
                SecondName = createPerson.SecondName,
                LastName = createPerson.LastName,
                Phone = createPerson.Phone,
                Email = createPerson.Email,
                Gender = createPerson.Gender,
                BirthDate = createPerson.BirthDate
            };

            if (!await peopleService.AddNewPersonAsync(newPerson, cancellationToken))
                return StatusCode(500, new { message = "Error Adding Person" });

            PersonDTO person = new()
            {
                PersonId = newPerson.PersonID,
                FirstName = newPerson.FirstName,
                SecondName = newPerson.SecondName,
                LastName = newPerson.LastName,
                Email = newPerson.Email,
                Phone = newPerson.Phone,
                Gen = newPerson.Gender,
                BirthDate = newPerson.BirthDate
            };

            return CreatedAtRoute("GetPersonByID", new { id = newPerson.PersonID }, person);
        }

        [HttpPut("{id}", Name = "UpdatePerson")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<UpdatePersonDTO>> UpdatePerson(
            int id,
            UpdatePersonDTO updatePerson,
            CancellationToken cancellationToken)
        {
            if (id < 1)
                return BadRequest("Invalid data");

            Person? person = await peopleService.GetPersonAsync(id, cancellationToken);
            if (person == null) return NotFound($"There's no person with this Id: {id}");

            person.FirstName = updatePerson.FirstName;
            person.SecondName = updatePerson.SecondName;
            person.LastName = updatePerson.LastName;
            person.Phone = updatePerson.Phone;
            person.Email = updatePerson.Email;
            person.Gender = updatePerson.Gender;
            person.BirthDate = updatePerson.BirthDate;


            if (await peopleService.UpdatePersonAsync(person, cancellationToken)) return Ok(updatePerson);
            else return StatusCode(500, new { message = "Error Updating Person" });
        }

        [HttpDelete("{id}", Name = "DeletePerson")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> DeletePerson(int id, CancellationToken cancellationToken)
        {
            if (id < 1)
                return BadRequest("Invalid data");
            bool person = await peopleService.IsPersonExistAsync(id, cancellationToken);
            if (!person) return NotFound($"There's no person with this Id: {id}");
            return await peopleService.DeletePersonAsync(id, cancellationToken) ? Ok($"Person With ID {id} has been deleted") : StatusCode(500, new { message = "Error Deleting Person" });
        }
    }
}
