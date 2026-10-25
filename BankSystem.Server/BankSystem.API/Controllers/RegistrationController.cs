using BankSystem.Business.Interfaces;
using BankSystem.DTOs.Auth;
using BankSystem.Shared;
using BankSystem.API.Authorization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BankSystem.API.Controllers
{
    [Route("api/Registration")]
    [ApiController]
    [Authorize(Policy = PermissionPolicies.Registration)]
    public class RegistrationController(ILoginAttemptService loginAttemptService) : ControllerBase
    {
        [HttpGet("LoginAttempts", Name = "GetRecentLoginAttempts")]
        [Authorize(Policy = PermissionPolicies.FullAccess)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IReadOnlyList<LoginAttemptDTO>>> GetRecentLoginAttempts(
            CancellationToken cancellationToken,
            [FromQuery] int take = 50)
        {
            if (take is < 1 or > 100)
                return BadRequest("The take parameter must be between 1 and 100.");

            var attempts = await loginAttemptService.GetRecentAsync(take, cancellationToken);
            var responses = attempts.Select(attempt => new LoginAttemptDTO(
                attempt.LoginAttemptId,
                attempt.UserId,
                attempt.AttemptedUserName,
                attempt.Succeeded,
                attempt.AttemptedAtUtc,
                attempt.ClientIpAddress)).ToList();

            return Ok(responses);
        }

    }
}
