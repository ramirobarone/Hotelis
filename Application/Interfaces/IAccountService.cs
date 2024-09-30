using Application.Models.User;

namespace Application.Interfaces
{
    public interface IAccountService
    {
        Task<string> Authenticate(UserDto userDto);
    }
}