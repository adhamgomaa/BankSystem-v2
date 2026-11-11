using BankSystem.Business.Interfaces;
using BankSystem.DTOs.Users;
using BankSystem.Shared.Entities;
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
                UserId = user.UserId,
                PersonId = user.PersonId,
                Username = user.Username,
                FullName = user.FullName,
                Email = user.Email,
                Phone = user.Phone,
                Permissions = user.Permissions,
                IsActive = user.IsActive
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

            GetUserDTO userDTO = new()
            {
                UserId = user.UserID,
                PersonId = user.PersonID,
                Username = user.UserName,
                Permissions = user.Permissions,
                IsActive = user.IsActive
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
                UserId = user.UserID,
                PersonId = user.PersonID,
                Username = user.UserName,
                Permissions = user.Permissions,
                IsActive = user.IsActive
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
            if (string.IsNullOrEmpty(createUser.Username) || createUser.Password.Length < 6)
                return BadRequest("Invalid Data");
                
            User newUser = new User
            {
                PersonID = createUser.PersonId,
                UserName = createUser.Username,
                Password = createUser.Password,
                Permissions = createUser.Permissions,
                IsActive = createUser.IsActive
            };

            if (!await userService.AddUserAsync(newUser, cancellationToken))
                return StatusCode(500, "Error Adding User");

            UserDTO user = new()
            {
                UserId = newUser.UserID,
                PersonId = newUser.PersonID,
                Username = newUser.UserName,
                Permissions = newUser.Permissions,
                IsActive = newUser.IsActive
            };

            return CreatedAtRoute("GetUserByID", new { id = newUser.UserID }, user);
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
            if (id < 1 || updateUser.Password.Length < 6)
                return BadRequest("Invalid data");

            User? user = await userService.FindUserAsync(id, cancellationToken);
            if (user == null) return NotFound($"There's no user with this Id: {id}");

            user.PersonID = updateUser.PersonId;
            user.UserName = updateUser.Username;
            user.Password = updateUser.Password;
            user.Permissions = updateUser.Permissions;
            user.IsActive = updateUser.IsActive;

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
