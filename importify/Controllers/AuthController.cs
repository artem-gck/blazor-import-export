using Importify.Service;
using Importify.Service.Models;
using Importify.Service.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Importify.Controllers
{
    [Route("api/authentication")]
    [ApiController]
    public class AuthController : Controller
    {
        private readonly IAuthUsing _authService;
        private readonly ITokenUsing _tokenService;
        private readonly string _headerName;

        public AuthController(IAuthUsing authService, ITokenUsing tokenService, IConfiguration configuration)
            => (_authService, _tokenService, _headerName) = (authService, tokenService, configuration.GetSection("HeaderName").Value);

        [HttpPost("login")]
        public async Task<ActionResult<Tokens>> Login([FromBody] User loginModel)
        {
            var tokens = await _authService.LoginAsync(loginModel);

            if (tokens is null)
                return Unauthorized();

            return tokens;
        }

        [HttpGet]
        public async Task<ActionResult<List<User>>> GetUsersAsync()
        {
            if (await _tokenService.CheckAccessKey(Request.Headers[_headerName].ToString()))
                return await _authService.GetUsersAsync();
            else
                return Unauthorized();
        }

        [HttpPost]
        public async Task<ActionResult<int>> RegistrationAsync(User user)
            => await _authService.RegistrationAsync(user);

        [HttpPut]
        public async Task<ActionResult<int>> UpdateUserAsync(User user)
            => await _authService.UpdateUserAsync(user);

        [HttpDelete]
        public async Task<ActionResult<int>> DeleteUserAsync(User user)
            => await _authService.DeleteUserAsync(user);
    }
}
