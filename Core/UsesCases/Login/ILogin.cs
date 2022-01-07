using Infrastructure.Models;

namespace Core.UsesCases.Login
{
    public interface ILogin
    {
        Task<User?> GetUser(string login);
        bool IsValidPassword(string password, string passwordToVerity);
    }
}
