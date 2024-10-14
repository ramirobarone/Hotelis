using Application.Models.User;
using Application.Models.Users;

namespace Application.Interfaces
{
    public interface IAccountService
    {
        Task<UserLoginDto> Authenticate(UserDto userDto);

        Task<bool> CreateAccount(UserCreateDto userCreateDto);
    }
}