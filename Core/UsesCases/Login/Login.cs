using Infrastructure;
using Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace Core.UsesCases.Login
{
    public class Login : ILogin
    {
        public Task<User?> GetUser(string login)
        {
            var options = new DbContextOptionsBuilder<DbTestMemory>()
           .UseInMemoryDatabase(databaseName: "Test")
           .Options;

            using var context = new DbTestMemory(options);
            return context.Users.FirstOrDefaultAsync(x => x.Email.Equals(login, StringComparison.OrdinalIgnoreCase));
        }

        public bool IsValidPassword(string password, string passwordToVerity)
        {
            return passwordToVerity.Equals(password, StringComparison.Ordinal);
        }
    }
}
