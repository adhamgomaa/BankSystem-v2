using BankSystem.Business;
using BankSystem.Business.Interfaces;
using BankSystem.DTOs.Clients;
using BankSystem.DTOs.People;
using BankSystem.Shared;
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
            List<PersonViewDTO> personDTO = people.Select(person => new PersonViewDTO
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

            GetPersonDTO personDTO = new GetPersonDTO
            {
                PersonId = person.personId,
                FirstName = person.firstName,
                SecondName = person.secondName,
                LastName = person.lastName,
                Email = person.email,
                Phone = person.phone,
                Gender = person.gender,
                BirthDate = person.birthDate
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
            Person newPerson = new Person
            {
                firstName = createPerson.firstName,
                secondName = createPerson.secondName,
                lastName = createPerson.lastName,
                phone = createPerson.phone,
                email = createPerson.email,
                gender = createPerson.gender,
                birthDate = createPerson.birthDate
            };

            if (!await peopleService.AddNewPersonAsync(newPerson, cancellationToken))
                return StatusCode(500, new { message = "Error Adding Person" });

            PersonDTO person = new PersonDTO
            {
                PersonId = newPerson.personId,
                FirstName = newPerson.firstName,
                SecondName = newPerson.secondName,
                LastName = newPerson.lastName,
                Email = newPerson.email,
                Phone = newPerson.phone,
                GenderByte = newPerson.gender,
                BirthDate = newPerson.birthDate
            };

            return CreatedAtRoute("GetPersonByID", new { id = newPerson.personId }, person);
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

            person.firstName = updatePerson.firstName;
            person.secondName = updatePerson.secondName;
            person.lastName = updatePerson.lastName;
            person.phone = updatePerson.phone;
            person.email = updatePerson.email;
            person.gender = updatePerson.gender;
            person.birthDate = updatePerson.birthDate;


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
