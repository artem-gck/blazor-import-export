using Importify.Service;
using Importify.Service.Models;
using Microsoft.AspNetCore.Mvc;

namespace Importify.Controllers
{
    [Route("api/massage")]
    [ApiController]
    public class MassageController : Controller
    {
        private readonly IMassageUsing _massageService;
        private readonly ITokenUsing _tokenService;
        private readonly string _headerName;

        public MassageController(IMassageUsing massageService, ITokenUsing tokenService, IConfiguration configuration)
            => (_massageService, _tokenService, _headerName) = (massageService, tokenService, configuration.GetSection("HeaderName").Value);

        [HttpGet]
        public async Task<ActionResult<List<Massage>>> GetMassagesAsync()
        {
            if (await _tokenService.CheckAccessKey(Request.Headers[_headerName].ToString()))
                return await _massageService.GetMassagesAsync();
            else
                return Unauthorized();
        }

        [HttpPost]
        public async Task<ActionResult<int>> AddMassageAsync(Massage massage)
        {
            return await _massageService.AddMassageAsync(massage);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<int>> DeleteMassageAsync(int id)
        {
            if (await _tokenService.CheckAccessKey(Request.Headers[_headerName].ToString()))
                return await _massageService.DeleteMassageAsync(id);
            else
                return Unauthorized();
        }
    }
}
