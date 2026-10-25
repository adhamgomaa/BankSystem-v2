using BankSystem.Business;
using BankSystem.Business.Interfaces;
using BankSystem.DTOs.Users;
using BankSystem.Shared;
using BankSystem.API.Authorization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.RateLimiting;
using BankSystem.API.Configuration;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BankSystem.API.Controllers
{
    [Route("api/User")]
    [ApiController]
    [Authorize(Policy = PermissionPolicies.User)]
    public class UserController(IUserService userService) : ControllerBase
    {
        [HttpGet("All", Name = "GetAllUsers")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<UserViewDTO>>> GetAllUsers(CancellationToken cancellationToken)
        {
            List<UserView> users = await userService.GetAllUsersAsync(cancellationToken);
            if (users.Count == 0)
                return NotFound("No Users Found");
            var usersDTO = users.Select(user => new UserViewDTO
            {
                userId = user.userId,
                personId = user.personId,
                username = user.username,
                fullName = user.fullName,
                email = user.email,
                phone = user.phone,
                permissions = user.permissions,
                isActive = user.isActive
            });
            return Ok(usersDTO);
        }

        [HttpGet("{id}", Name = "GetUserByID")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<GetUserDTO>> GetUserByID(int id, CancellationToken cancellationToken)
        {
            if (id < 1)
                return BadRequest("Invalid data");

            User? user = await userService.FindUserAsync(id, cancellationToken);

            if (user == null) return NotFound($"There's no user with this Id: {id}");

            GetUserDTO userDTO = new GetUserDTO
            {
                userId = user.userId,
                personId = user.personId,
                username = user.username,
                permissions = user.permissions,
                isActive = user.isActive
            };

            return Ok(userDTO);
        }

        [HttpGet("username/{username}", Name = "GetUserByUsername")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<UserDTO>> GetUserByUsername(string username, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(username))
                return BadRequest("Invalid data");

            User? user = await userService.FindUserAsync(username, cancellationToken);

            if (user == null) return NotFound($"There's no user with this username: {username}");

            UserDTO userDTO = new UserDTO
            {
                userId = user.userId,
                personId = user.personId,
                username = user.username,
                permissions = user.permissions,
                isActive = user.isActive
            };

            return Ok(userDTO);
        }

        [HttpGet("Exist/{id}", Name = "IsUserExist")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<bool>> IsUserExist(int id, CancellationToken cancellationToken)
        {
            if (id < 1)
                return BadRequest("Invalid data");
            if (!await userService.IsUserExistAsync(id, cancellationToken))
                return NotFound(false);
            return Ok(true);
        }

        [HttpGet("Count", Name = "GetCountUsers")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<int>> GetCountUsers(CancellationToken cancellationToken)
        {
            int count = await userService.UsersCountAsync(cancellationToken);

            if (count == 0)
                return NotFound("No Users Found");
            return Ok(count);
        }


        [HttpPost(Name = "AddNewUser")]
        [Authorize(Policy = PermissionPolicies.FullAccess)]
        [EnableRateLimiting(RateLimitPolicies.UserWrites)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status429TooManyRequests)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<UserDTO>> AddNewUser(CreateUserDTO createUser, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(createUser.username) || createUser.password.Length < 6)
                return BadRequest("Invalid Data");
                
            User newUser = new User
            {
                personId = createUser.personId,
                username = createUser.username,
                password = createUser.password,
                permissions = createUser.permissions,
                isActive = createUser.isActive
            };

            if (!await userService.AddUserAsync(newUser, cancellationToken))
                return StatusCode(500, "Error Adding User");

            UserDTO user = new UserDTO
            {
                userId = newUser.userId,
                personId = newUser.personId,
                username = newUser.username,
                permissions = newUser.permissions,
                isActive = newUser.isActive
            };

            return CreatedAtRoute("GetUserByID", new { id = newUser.userId }, user);
        }

        [HttpPut("{id}", Name = "UpdateUser")]
        [Authorize(Policy = PermissionPolicies.FullAccess)]
        [EnableRateLimiting(RateLimitPolicies.UserWrites)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status429TooManyRequests)]
        public async Task<ActionResult<UpdateUserDTO>> UpdateUser(
            int id,
            UpdateUserDTO updateUser,
            CancellationToken cancellationToken)
        {
            if (id < 1 || updateUser.password.Length < 6)
                return BadRequest("Invalid data");

            User? user = await userService.FindUserAsync(id, cancellationToken);
            if (user == null) return NotFound($"There's no user with this Id: {id}");

            user.personId = updateUser.personId;
            user.username = updateUser.username;
            user.password = updateUser.password;
            user.permissions = updateUser.permissions;
            user.isActive = updateUser.isActive;


            if (await userService.UpdateUserAsync(user, cancellationToken)) return Ok(updateUser);
            else return StatusCode(500, new { message = "Error Updating User" });
        }

        [HttpDelete("{id}", Name = "DeleteUser")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> DeleteUser(int id, CancellationToken cancellationToken)
        {
            if (id < 1)
                return BadRequest("Invalid data");
            bool isExist = await userService.IsUserExistAsync(id, cancellationToken);
            if (!isExist) return NotFound($"There's no user with this Id: {id}");
            return await userService.DeleteUserAsync(id, cancellationToken) ? Ok($"User With ID {id} has been deleted") : StatusCode(500, new { message = "Error Deleting User" });
        }
    }
}
