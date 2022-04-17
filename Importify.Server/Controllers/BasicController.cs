using Importify.Service;
using Importify.Service.Models;
using Microsoft.AspNetCore.Mvc;

namespace Importify.Controllers
{
    [ApiController]
    [Route("api/basic")]
    public class BasicController : Controller
    {
        private readonly IBasicUsing _basicService;
        private readonly ITokenUsing _tokenService;
        private readonly string _headerName;

        public BasicController(IBasicUsing basicService, ITokenUsing tokenService, IConfiguration configuration)
            => (_basicService, _tokenService, _headerName) = (basicService, tokenService, configuration.GetSection("HeaderName").Value);

        [HttpGet("countries")]
        public async Task<ActionResult<List<Country>>> GetCountriesAsync()
        {
            if (await _tokenService.CheckAccessKey(Request.Headers[_headerName].ToString()))
                return await _basicService.GetCountriesAsync();
            else
                return Unauthorized();
        }

        [HttpGet("years")]
        public async Task<ActionResult<List<Year>>> GetYearsAsync()
        {
            if (await _tokenService.CheckAccessKey(Request.Headers[_headerName].ToString()))
                return await _basicService.GetYearsAsync();
            else
                return Unauthorized();
        }

        [HttpGet("categories")]
        public async Task<ActionResult<List<Category>>> GetCategoriesAsync()
        {
            if (await _tokenService.CheckAccessKey(Request.Headers[_headerName].ToString()))
                return await _basicService.GetCategoryAsync();
            else
                return Unauthorized();
        }
    }
}
