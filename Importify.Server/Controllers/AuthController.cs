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
        public async Task<ActionResult<Tokens>> Login([FromBody] LoginUser loginModel)
        {
            var users = await _authService.GetUsersAsync();
            var user = users.FirstOrDefault(us => us.Login == loginModel.Login);
            user.Password = loginModel.Password;
            var tokens = await _authService.LoginAsync(user);
            tokens.Login = loginModel.Login;
            tokens.Role = user.UserInfo.Role.Value;

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
        public async Task<ActionResult<int>> RegistrationAsync(RegistrationUser userView)
        {
            var role = new Role()
            {
                Value = userView.Role,
            };

            var userInfo = new UserInfo()
            {
                Email = userView.Email,
                Role = role,
            };

            var user = new User()
            {
                Login = userView.Login,
                Password = userView.Password
            };

            user.UserInfo = userInfo;

            return await _authService.RegistrationAsync(user);
        }

        [HttpPut]
        public async Task<ActionResult<int>> UpdateUserAsync(User user)
        {
            if (await _tokenService.CheckAccessKey(Request.Headers[_headerName].ToString()))
                return await _authService.UpdateUserAsync(user);
            else
                return Unauthorized();
        }

        [HttpDelete]
        public async Task<ActionResult<int>> DeleteUserAsync(User user)
        {
            if (await _tokenService.CheckAccessKey(Request.Headers[_headerName].ToString()))
                return await _authService.DeleteUserAsync(user);
            else
                return Unauthorized();
        }

        [HttpGet("user")]
        public async Task<ActionResult<User>> GetUser(string login)
        {
            if (await _tokenService.CheckAccessKey(Request.Headers[_headerName].ToString()))
                return await _authService.GetUser(login);
            else
                return Unauthorized();
        }
    }
}
