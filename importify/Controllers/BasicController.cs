using Importify.Service;
using Importify.Service.Models;
using Microsoft.AspNetCore.Mvc;

namespace Importify.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BasicController : Controller
    {
        private readonly IBasicUsing _basicService;

        public BasicController(IBasicUsing basicService)
            => _basicService = basicService;

        [HttpGet("countries")]
        public async Task<ActionResult<List<Country>>> GetCountriesAsync()
            => await _basicService.GetCountriesAsync();

        [HttpGet("years")]
        public async Task<ActionResult<List<Year>>> GetYearsAsync()
            => await _basicService.GetYearsAsync();

        [HttpGet("categories")]
        public async Task<ActionResult<List<Category>>> GetCategoriesAsync()
            => await _basicService.GetCategoryAsync();
    }
}
