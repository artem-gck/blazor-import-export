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
        private readonly IAuthUsing _service;

        public AuthController(IAuthUsing service)
            => _service = service;

        [HttpPost, Route("login")]
        public async Task<ActionResult<Tokens>> Login([FromBody] User loginModel)
        {
            if (loginModel == null)
                return BadRequest("Invalid client request");

            var tokens = await _service.Login(loginModel);

            if (tokens is null)
                return Unauthorized();

            return tokens;
        }
    }
}
