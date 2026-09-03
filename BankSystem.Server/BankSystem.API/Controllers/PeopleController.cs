using BankSystem.Business;
using BankSystem.DTOs.Clients;
using BankSystem.DTOs.People;
using BankSystem.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BankSystem.API.Controllers
{
    [Route("api/People")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        [HttpGet("All", Name = "GetAllPeople")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<PeopleViewDTO>> GetAllPeople()
        {
            List<PeopleView> people = clsPeople.GetAllPeople();
            if (people.Count == 0)
                return NotFound("No People Found");
            List<PeopleViewDTO> personDTO = people.Select(person => new PeopleViewDTO
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
        public ActionResult<GetPersonDTO> GetPersonByID(int id)
        {
            if (id < 1)
                return BadRequest("Invalid data");

            Person? person = clsPeople.GetPerson(id);

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
        public ActionResult<bool> IsPersonExist(int id)
        {
            if (id < 1)
                return BadRequest("Invalid data");
            if(!clsPeople.IsPersonExist(id))
                return NotFound(false);
            return Ok(true);
        }

        [HttpPost(Name = "AddNewPerson")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<PeopleDTO> AddNewPerson(CreatePersonDTO createPerson)
        {
            if (string.IsNullOrWhiteSpace(createPerson.firstName) || string.IsNullOrWhiteSpace(createPerson.lastName) || string.IsNullOrWhiteSpace(createPerson.secondName)
                || string.IsNullOrWhiteSpace(createPerson.phone) || string.IsNullOrWhiteSpace(createPerson.email))
                return BadRequest("Invalid data");

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

            if (!clsPeople.AddNewPerson(newPerson))
                return StatusCode(500, new { message = "Error Adding Person" });

            PeopleDTO person = new PeopleDTO
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

            return CreatedAtRoute("GetClientByID", new { id = newPerson.personId }, person);
        }

        [HttpPut("{id}", Name = "UpdatePerson")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<UpdatePersonDTO> UpdatePerson(int id, UpdatePersonDTO updatePerson)
        {
            if (id < 1 || string.IsNullOrWhiteSpace(updatePerson.firstName) || string.IsNullOrWhiteSpace(updatePerson.lastName) || string.IsNullOrWhiteSpace(updatePerson.secondName)
                || string.IsNullOrWhiteSpace(updatePerson.phone) || string.IsNullOrWhiteSpace(updatePerson.email))
                return BadRequest("Invalid data");

            Person? person = clsPeople.GetPerson(id);
            if (person == null) return NotFound($"There's no person with this Id: {id}");

            person.firstName = updatePerson.firstName;
            person.secondName = updatePerson.secondName;
            person.lastName = updatePerson.lastName;
            person.phone = updatePerson.phone;
            person.email = updatePerson.email;
            person.gender = updatePerson.gender;
            person.birthDate = updatePerson.birthDate;


            if (clsPeople.UpdatePerson(person)) return Ok(updatePerson);
            else return StatusCode(500, new { message = "Error Updating Person" });
        }

        [HttpDelete("{id}", Name = "DeletePerson")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult DeletePerson(int id)
        {
            if (id < 1)
                return BadRequest("Invalid data");
            bool person = clsPeople.IsPersonExist(id);
            if (!person) return NotFound($"There's no person with this Id: {id}");
            return clsPeople.DeletePerson(id) ? Ok($"Person With ID {id} has been deleted") : StatusCode(500, new { message = "Error Deleteing Person" });
        }
    }
}
