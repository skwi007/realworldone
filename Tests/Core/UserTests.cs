using Core.Dto;
using Core.UsesCases.Login;
using Core.UsesCases.UserService;
using System.Threading.Tasks;
using Xunit;

namespace Tests.Core
{
    public class UserServiceTests
    {
        private readonly IUserService _userService;
        private readonly ILogin _login;
        public UserServiceTests()
        {
            _userService = new UserService();
            _login = new Login();
        }

        [Fact]
        public async Task GivenNewUser_WhenCalling_CreateNewUser_ShouldCreateTheNewUser()
        {
            var user = new NewUser
            {
                Name = "NameTest",
                Email = "email@test.com",
                Password = "passwordTest"
            };
            await _userService.CreateNewUser(user);
            var result = await _login.GetUser("email@test.com");
            Assert.Equal("passwordTest", result.Password);
            Assert.Equal("email@test.com", result.Email);
            Assert.Equal("NameTest", result.Name);
        }
    }
}
