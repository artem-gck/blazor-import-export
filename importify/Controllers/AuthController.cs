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
            if (loginModel == null)
                return BadRequest("Invalid client request");

            var tokens = await _authService.LoginAsync(loginModel);

            if (tokens is null)
                return Unauthorized();

            return tokens;
        }

        [HttpGet("users")]
        public async Task<ActionResult<List<User>>> GetUsersAsync()
        {
            if (await _tokenService.CheckAccessKey(Request.Headers[_headerName].ToString()))
                return await _authService.GetUsersAsync();
            else
                return Unauthorized();
        }
    }
}
