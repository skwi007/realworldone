using Core.UsesCases.Login;
using Microsoft.AspNetCore.Mvc;
using Upside_downKittenGenerator.Authentification;
using Upside_downKittenGenerator.Dto;

namespace Upside_downKittenGenerator.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly JwtSettings jwtSettings;
        private readonly ILogin _login;
        public TokenController(JwtSettings jwtSettings)
        {
            this.jwtSettings = jwtSettings;
            _login = new Login();
        }

        /// <summary>
        /// To Get a token to be able to Authentificate, you need to login with a login and a password.
        /// </summary>
        /// <remarks>
        /// The password is case sensitive.
        /// </remarks>
        /// <param name="userLogins"></param>
        /// <returns>User Token</returns>
        [ProducesResponseType(typeof(UserTokens), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPost]
        public async Task<IActionResult> GetToken(UserLogins userLogins)
        {
            var user = await _login.GetUser(userLogins.Login);
            if (user != null)
            {

                var isValidPassword = _login.IsValidPassword(user.Password, userLogins.Password);
                if (isValidPassword)
                {
                    var token = Token.GenenarateTokenkey(new UserTokens()
                    {
                        Email = user.Email,
                        GuidId = Guid.NewGuid(),
                        Name = user.Name,
                        Id = user.GuidId,
                    }, jwtSettings);
                    return Ok(token);
                }
                return BadRequest("Bad password");
            }
            return NotFound("User does not exist");
        }
    }
}
