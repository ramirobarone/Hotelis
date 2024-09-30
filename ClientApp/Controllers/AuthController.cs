using Application.Interfaces;
using Application.Models.User;
using Application.Models.User.User;
using Application.Services.Account;
using Microsoft.AspNetCore.Mvc;

namespace ClientApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(IAccountService accountService) : ControllerBase
    {
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [HttpPost(nameof(Authenticat))]
        public async Task<IActionResult> Authenticat(UserDto userDto)
        {
            string token = await accountService.Authenticate(userDto);

            if (string.IsNullOrEmpty(token))
                return Unauthorized();

            return Ok(token);
        }
        public async Task<IActionResult> CreateAccount(UserCreateDto userCreateDto)
        {
            return Created("", null);

        }
    }
}
