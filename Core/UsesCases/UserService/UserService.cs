using Core.Dto;
using Infrastructure;
using Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace Core.UsesCases.UserService
{
    public class UserService : IUserService
    {
        public async Task CreateNewUser(NewUser newUser)
        {
            var options = new DbContextOptionsBuilder<DbTestMemory>()
           .UseInMemoryDatabase(databaseName: "Test")
           .Options;


            using (var context = new DbTestMemory(options))
            {
                var user = new User()
                {
                    Email = newUser.Email,
                    GuidId = new Guid(),
                    Name = newUser.Name,
                    Password = newUser.Password
                };
                await context.CreateUser(user);
                
            }
        }
    }
}
