using Application.Interfaces;
using Application.Models.User;
using Application.Models.Users;
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
            UserLoginDto loginUser = await accountService.Authenticate(userDto);

            if (loginUser is null)
                return Unauthorized();

            return Ok(loginUser);
        }
        [HttpPost(nameof(CreateAccount))]

        [ProducesResponseType(typeof(bool), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(bool), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateAccount(UserCreateDto userCreateDto)
        {
            if (!ModelState.IsValid)
                return BadRequest("Error controler");

            bool accountCreated = await accountService.CreateAccount(userCreateDto);

            if (accountCreated)
                return Created("/home", accountCreated);

            return Ok(accountCreated);

        }
    }
}
