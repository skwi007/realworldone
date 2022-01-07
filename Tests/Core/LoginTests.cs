using Core.UsesCases.Login;
using System.Threading.Tasks;
using Xunit;

namespace Tests.Core
{
    public class LoginTests
    {
        private readonly ILogin _login;
        public LoginTests()
        {
            _login = new Login();
        }
        #region GetUser
        [Theory]
        [InlineData("laurent.petitdemange0@gmail.com")]
        [InlineData("test@realworldone.com")]
        [InlineData("TEST@realworldone.com")]
        public async Task GivenGoodLogin_WhenCalling_GetUser_ReturnGoodEmail(string login)
        {
            var result = await _login.GetUser(login);
            Assert.Equal(login.ToLower(), result.Email);
        }

        [Theory]
        [InlineData("laurent.petitdemange0@gmail.com")]
        public async Task GivenGoodLogin_WhenCalling_GetUser_ReturnGoodName(string login)
        {
            var result = await _login.GetUser(login);
            Assert.Equal("Laurent", result.Name);
        }

        [Theory]
        [InlineData("laurent.petitdemange0@gmail.com")]
        public async Task GivenGoodLogin_WhenCalling_GetUser_ReturnGoodPassword(string login)
        {
            var result = await _login.GetUser(login);
            Assert.Equal("VerySecurePassword", result.Password);
        }

        /// I am following the principe that typographie, space and so on are checked by front end
        [Theory]
        [InlineData("laurent.petitdemange@gmail.com")]
        [InlineData("")]
        [InlineData("la")]
        public async Task GivenBadLogin_WhenCalling_GetUser_ReturnNull(string login)
        {
            var result = await _login.GetUser(login);
            Assert.Null(result);
        }

        #endregion GetUser

        #region IsValidPassword
        [Theory]
        [InlineData("laurent.petitdemange0@gmail.com", "VerySecurePassword")]
        public async Task GivenGoodPassword_WhenCalling_IsValidPassword_ReturnTrue(string login, string password)
        {
            var user = await _login.GetUser(login);
            var result = _login.IsValidPassword(user.Password, password);
            Assert.True(result);
        }

        [Theory]
        [InlineData("laurent.petitdemange0@gmail.com", "VerysecurePassword")]
        [InlineData("laurent.petitdemange0@gmail.com", "Hey$")]
        [InlineData("laurent.petitdemange0@gmail.com", "")]
        public async Task GivenWrongPassword_WhenCalling_IsValidUser_ReturnFalse(string login, string password)
        {
            var user = await _login.GetUser(login);
            var result = _login.IsValidPassword(user.Password, password);
            Assert.False(result);
        }

        #endregion IsValidPassword
    }
}

