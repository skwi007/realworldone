using Core.UsesCases.Login;
using Core.UsesCases.UserService;
using Microsoft.AspNetCore.Mvc;
using Core.Dto;
using Infrastructure.Models;

namespace Upside_downKittenGenerator.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ILogin _login;
        public UserController()
        {
            _userService = new UserService();
            _login = new Login();
        }

        /// <summary>
        /// Create a new user.
        /// </summary>
        /// <remarks>
        /// If the login (email) already exists you will get a bad request.
        /// </remarks>
        /// <param name="user"></param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost("CreateUser")]
        public async Task<IActionResult> CreateNewUser(NewUser user)
        {
            var doesUserExist = await _login.GetUser(user.Email);
            if (doesUserExist != null)
                return BadRequest("User does already exist");

            await _userService.CreateNewUser(user);

            return StatusCode(201);
        }

        /// <summary>
        /// Get user information by login.
        /// </summary>
        /// <remarks>
        /// Here for the demo I left access to the password which allows you to easily change users because it is just for the test
        /// If your are not connected you will get a Unauthorized request
        /// </remarks>
        /// <param name="user"></param>
        /// <returns>user information</returns>
        [ProducesResponseType(typeof(User), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPost("GetUserInformation")]
        public async Task<ActionResult<User>> GetUserInformation(string email)
        {
            var user = await _login.GetUser(email);
            if (user == null)
                return NotFound("User does not exist");

            return Ok(user);
        }
    }
}
