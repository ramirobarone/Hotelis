using Application.Interfaces;
using Application.Models.Options;
using Application.Models.User;
using Application.Models.Users;
using Infrastructure.Models;
using Infrastructure.Repository;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Application.Services.Account
{
    public class AccountService(IRepository<User> repositoryUser, IOptions<JwtOptions> jwtOptions) : IAccountService
    {
        private SymmetricSecurityKey? _key;
        public async Task<UserLoginDto> Authenticate(UserDto userDto)
        {
            //logger.LogInformation("User authenticat is {0}:", userDto.Email);

            User isValidUser = await IsUserAuthenticated(userDto.Email, userDto.Password);

            //logger.LogInformation("User authenticat is {0}: result is {1}", userDto.Email, isAuthenticate);

            if (isValidUser is not null && !string.IsNullOrEmpty(isValidUser.Email))
            {
                return new UserLoginDto(isValidUser.Name + " " + isValidUser.LastName, CreateToken(isValidUser.Email), 0, isValidUser.UserGuid);
            }

            throw new UnauthorizedAccessException("The user is not authorizated");
        }
        private async Task<User> IsUserAuthenticated(string email, string password) => await repositoryUser.GetByIdAsync(x => x.Email == email && x.Password == password);
        private string CreateToken(string userId)
        {
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions?.Value?.Key ?? throw new SecurityTokenNotYetValidException()));
            var claims = new List<Claim> {
                new  (JwtRegisteredClaimNames.Jti, Guid.NewGuid ().ToString ()),
                new  ("ID", userId),
            };

            var token = new JwtSecurityToken(
                jwtOptions.Value.Authority,
                jwtOptions.Value.Audience,
                claims,
                expires: DateTime.Now.AddMinutes(Convert.ToDouble(jwtOptions.Value.TokenDuration)),
                signingCredentials: new SigningCredentials(_key, SecurityAlgorithms.HmacSha256)
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<bool> CreateAccount(UserCreateDto userCreateDto)
        {
            if (userCreateDto is null)
                throw new ArgumentNullException(nameof(userCreateDto));

            if (await ExistAccount(userCreateDto))
                return false;

            var created = await repositoryUser.CreateAsync(userCreateDto);

            return created.Entity.Id > 0;
        }
        private async Task<bool> ExistAccount(UserCreateDto userCreateDto) => await repositoryUser.Exist(x => x.Email == userCreateDto.Email);
    }
}
