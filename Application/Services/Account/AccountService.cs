using Application.Interfaces;
using Application.Models.Options;
using Application.Models.User;
using Infrastructure.Models;
using Infrastructure.Repository;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Application.Services.Account
{
    public class AccountService(IRepository<User> repositoryUser, IOptions<JwtOptions> jwtOptions) : IAccountService
    {
        private SymmetricSecurityKey _key;
        public async Task<string> Authenticate(UserDto userDto)
        {
            //logger.LogInformation("User authenticat is {0}:", userDto.Email);

            bool isAuthenticate = await IsUserAuthenticated(userDto.Email, userDto.Password);

            //logger.LogInformation("User authenticat is {0}: result is {1}", userDto.Email, isAuthenticate);

            if (isAuthenticate)
                return CreateToken(userDto.Email);

            throw new UnauthorizedAccessException("The user is not authorizated");
        }
        private async Task<bool> IsUserAuthenticated(string email, string password) => await repositoryUser.Exist(x => x.Email == email && x.Password == password);
        private string CreateToken(string userId)
        {
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions.Value.Key));
            var claims = new List<Claim> {
                new Claim (JwtRegisteredClaimNames.Jti, Guid.NewGuid ().ToString ()),
                new Claim ("ID", userId),
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
    }
}
