using Importify.Service;
using Importify.Service.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Importify.Controllers
{
    [Route("api/token")]
    [ApiController]
    public class TokenController : Controller
    {
        private readonly ITokenUsing _tokenService;

        public TokenController(ITokenUsing tokenService)
            => _tokenService = tokenService;

        [HttpPost]
        [Route("refresh")]
        public async Task<ActionResult<Tokens>> Refresh(Tokens tokenApiModel)
        {
            if (tokenApiModel is null)
                return BadRequest("Invalid client request");

            var newTokens = await _tokenService.Refresh(tokenApiModel);

            return newTokens is not null ? newTokens : NotFound();
        }
    }
}
