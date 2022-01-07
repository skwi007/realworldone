using Core.Dto;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Upside_downKittenGenerator.Controllers;
using Xunit;

namespace Tests.ControllersTests
{
    public class UserControllerTests
    {
        private readonly UserController _userController;
        public UserControllerTests()
        {
            _userController = new UserController();
        }

        [Theory]
        [InlineData("test@test.com", "testPassword", "test")]
        public async Task GivenNewUser_WhenCalling_CreateNewUser_ReturnCreateObjectResult201(string email, string password, string name)
        {
            NewUser newUser = new()
            {
                Email = email,
                Password = password,
                Name = name
            };
            var result = await _userController.CreateNewUser(newUser);
            var status = Assert.IsType<StatusCodeResult>(result);
            Assert.Equal(201, status.StatusCode);
        }

        [Theory]
        [InlineData("test@realworldone.com", "testPassword", "test")]
        public async Task GivenAnExistingLogin_WhenCalling_CreateNewUser_ReturnBadRequestObjectResult(string email, string password, string name)
        {
            NewUser newUser = new()
            {
                Email = email,
                Password = password,
                Name = name
            };
            var result = await _userController.CreateNewUser(newUser);
            Assert.IsType<BadRequestObjectResult>(result);
        }
    }
}
