using Importify.Service;
using Importify.Service.Models;
using Microsoft.AspNetCore.Mvc;

namespace Importify.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ImportifyController : Controller
    {
        private readonly IBasicUsing _basicService;

        public ImportifyController(IBasicUsing basicService)
            => _basicService = basicService;

        [HttpGet("countries")]
        public async Task<ActionResult<List<Country>>> GetCountries()
            => await _basicService.GetCountriesAsync();

        [HttpGet("years")]
        public async Task<ActionResult<List<Year>>> GetYears()
            => await _basicService.GetYearsAsync();

        [HttpGet("categories")]
        public async Task<ActionResult<List<Category>>> GetCategories()
            => await _basicService.GetCategoryAsync();
    }
}
