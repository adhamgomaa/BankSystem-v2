using BankSystem.Business;
using BankSystem.DTOs.Registerations;
using BankSystem.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BankSystem.API.Controllers
{
    [Route("api/Registration")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        [HttpGet("All", Name = "GetAllRegistrations")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<RegistrationViewDTO>> GetAllRegistrations()
        {
            List<RegistrationView> registers = clsRegistration.GetAllRegisters();
            if (registers.Count == 0)
                return NotFound("No registers Found");
            var registerDTO = registers.Select(register => new RegistrationViewDTO
            {
                registerId = register.registerId,
                userId = register.userId,
                username = register.username,
                permissions = register.permissions,
                registerationDate = register.registerationDate
            });
            return Ok(registers);
        }

        [HttpPost(Name = "AddNewRegistration")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<bool> AddNewRegistration(CreateRegisterDTO createRegister)
        {
            if (!clsRegistration.AddNewRegister(createRegister.UserID))
                return StatusCode(500, "Error Adding Register");

            return Ok(true);
        }

    }
}
