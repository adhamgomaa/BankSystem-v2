using BankSystem.Business;
using BankSystem.DTOs.Users;
using BankSystem.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BankSystem.API.Controllers
{
    [Route("api/User")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpGet("All", Name = "GetAllUsers")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<UserViewDTO>> GetAllUsers()
        {
            List<UserView> users = clsUser.GetAllUsers();
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
            return Ok(users);
        }

        [HttpPost("Login", Name = "LoginUser")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public ActionResult<LoginUserDTO> LoginUser(LoginRequestDTO loginRequest)
        {
            if (string.IsNullOrWhiteSpace(loginRequest.UserName) || string.IsNullOrWhiteSpace(loginRequest.Password))
                return BadRequest("Invalid data");

            User? current = clsUser.FindUser(loginRequest.UserName, loginRequest.Password);
            if (current == null) return Unauthorized("Invalid username or password");

            LoginUserDTO currentDTO = new LoginUserDTO
            {
                userId = current.userId,
                personId = current.personId,
                username = loginRequest.UserName,
                password = loginRequest.Password,
                permissions = current.permissions,
                isActive = current.isActive
            };
            return Ok(currentDTO);
        }

        [HttpGet("{id}", Name = "GetUserByID")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<GetUserDTO> GetUserByID(int id)
        {
            if (id < 1)
                return BadRequest("Invalid data");

            User? user = clsUser.FindUser(id);

            if (user == null) return NotFound($"There's no user with this Id: {id}");

            GetUserDTO userDTO = new GetUserDTO
            {
                userId = user.userId,
                personId = user.personId,
                username = user.username,
                password = user.password,
                permissions = user.permissions,
                isActive = user.isActive
            };

            return Ok(userDTO);
        }

        [HttpGet("username/{username}", Name = "GetUserByUsername")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<UserDTO> GetUserByUsername(string username)
        {
            if (string.IsNullOrEmpty(username))
                return BadRequest("Invalid data");

            User? user = clsUser.FindUser(username);

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
        public ActionResult<bool> IsUserExist(int id)
        {
            if (id < 1)
                return BadRequest("Invalid data");
            if (!clsUser.IsUserExist(id))
                return NotFound(false);
            return Ok(true);
        }

        [HttpGet("Count", Name = "GetCountUsers")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<int> GetCountUsers()
        {
            int count = clsUser.UsersCount();

            if (count == 0)
                return NotFound("No Users Found");
            return Ok(count);
        }


        [HttpPost(Name = "AddNewUser")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<UserDTO> AddNewUser(CreateUserDTO createUser)
        {
            User newUser = new User
            {
                personId = createUser.personId,
                username = createUser.username,
                password = createUser.password,
                permissions = createUser.permissions,
                isActive = createUser.isActive
            };

            if (!clsUser.AddUser(newUser))
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
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<UpdateUserDTO> UpdateUser(int id, UpdateUserDTO updateUser)
        {
            if (id < 1 || string.IsNullOrEmpty(updateUser.username) || updateUser.password.Length < 6)
                return BadRequest("Invalid data");

            User? user = clsUser.FindUser(id);
            if (user == null) return NotFound($"There's no user with this Id: {id}");

            user.personId = updateUser.personId;
            user.username = updateUser.username;
            user.password = updateUser.password;
            user.permissions = updateUser.permissions;
            user.isActive = updateUser.isActive;


            if (clsUser.UpdateUser(user)) return Ok(updateUser);
            else return StatusCode(500, new { message = "Error Updating User" });
        }

        [HttpDelete("{id}", Name = "DeleteUser")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult DeleteUser(int id)
        {
            if (id < 1)
                return BadRequest("Invalid data");
            bool IsExist = clsUser.IsUserExist(id);
            if (!IsExist) return NotFound($"There's no user with this Id: {id}");
            return clsUser.DeleteUser(id) ? Ok($"User With ID {id} has been deleted") : StatusCode(500, new { message = "Error Deleteing User" });
        }

    }
}
