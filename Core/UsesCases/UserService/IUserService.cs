using Core.Dto;

namespace Core.UsesCases.UserService
{
    public interface IUserService
    {
        Task CreateNewUser(NewUser user);
    }
}
