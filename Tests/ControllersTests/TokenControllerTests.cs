using Core.UsesCases.Login;
using Microsoft.AspNetCore.Mvc;
using Upside_downKittenGenerator.Controllers;
using Upside_downKittenGenerator.Dto;
using Xunit;

namespace Tests.ControllersTests
{
    public class TokenControllerTests
    {
        private readonly JwtSettings _jwtSettings;
        private TokenController _tokenController;
        private readonly ILogin _login;
        public TokenControllerTests()
        {
            _login = new Login();
            _jwtSettings = new JwtSettings()
            {
                IssuerSigningKey = "64A63153-11C1-4919-9133-EFAF99A9B456",
                RequireExpirationTime = true,
                ValidateAudience = true,
                ValidateIssuer = true,
                ValidateIssuerSigningKey = true,
                ValidAudience = "https://localhost:7191",
                ValidIssuer = "https://localhost:7191"
            };
            _tokenController = new TokenController(_jwtSettings);
        }

        [Theory]
        [InlineData("laurent.petitdemange0@gmail.com", "VerySecurePassword")]
        [InlineData("test@realworldone.com", "Hey$")]
        public async void GivenGoodLoginAndPassword_WhenCallingGetToken_ThenReturnToken(string login, string password)
        {
            var user = await _login.GetUser(login);

            UserLogins userLogins = new()
            {
                Login = login,
                Password = password
            };
            var result = await _tokenController.GetToken(userLogins);
            var resultObj = Assert.IsType<OkObjectResult>(result);
            var userTokens = Assert.IsType<UserTokens>(resultObj.Value);
            Assert.NotNull(userTokens.Token);
        }

        [Theory]
        [InlineData("laurent.petitdemange@gmail.com", "VerySecurePassword")]
        public async void GivenWrongLogin_WhenCallingGetToken_ThenReturnNotFoundResult(string login, string password)
        {
            UserLogins userLogins = new()
            {
                Login = login,
                Password = password
            };
            var result = await _tokenController.GetToken(userLogins);
            Assert.IsType<NotFoundObjectResult>(result);
        }

        [Theory]
        [InlineData("laurent.petitdemange0@gmail.com", "verySecurePassword")]
        public async void GivenGoodLoginWrongPassword_WhenCallingGetToken_ThenReturnBadRequestObjectResult(string login, string password)
        {
            UserLogins userLogins = new()
            {
                Login = login,
                Password = password
            };
            var result = await _tokenController.GetToken(userLogins);
            Assert.IsType<BadRequestObjectResult>(result);
        }
    }
}
