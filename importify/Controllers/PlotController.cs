using Importify.Access;
using Importify.Service;
using Importify.Service.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Importify.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlotController : Controller
    {
        private readonly IPlotUsing _plotService;

        public PlotController(IPlotUsing countryService)
            => _plotService = countryService;

        [HttpGet("all/{country}")]
        public async Task<ActionResult<List<CountryImportExport>>> GetCountryImportExportAsync(string country)
            => await _plotService.GetCountryImportExportAsync(country);

        [HttpGet("countryconstituent/{country}")]
        public async Task<ActionResult<List<CountryConstituent>>> GetCountryConstituentAsync(string country)
            => await _plotService.GetCountryConstituentAsync(country);

        [HttpGet("share/{country}/{year}")]
        public async Task<ActionResult<List<CountryConstituent>>> GetCountryShareAsync(string country, int year)
            => await _plotService.GetCountryShareAsync(country, year);

        [HttpGet("worldconstituent/{consiste}")]
        public async Task<ActionResult<List<WorldConstituents>>> GetWorldConstituentAsync(string consiste)
            => await _plotService.GetWorldConstituentAsync(consiste);

        [HttpGet("worldexport/{country}")]
        public async Task<ActionResult<List<WorldConstituentExport>>> GetWorldConstituentExportAsync(string country)
            => await _plotService.GetWorldConstituentExportAsync(country);

        [HttpGet("exportshare/{consiste}/{year}")]
        public async Task<ActionResult<List<CategoryShare>>> GetCategoryShareExportAsync(string consiste, int year)
            => await _plotService.GetCategoryShareExportAsync(consiste, year);

        [HttpGet("importshare/{consiste}/{year}")]
        public async Task<ActionResult<List<CategoryShare>>> GetCategoryShareImportAsync(string consiste, int year)
            => await _plotService.GetCategoryShareImportAsync(consiste, year);

        [HttpPost("commonimportexport")]
        public async Task<IActionResult> AddCommonImportExportAsync(CountryData countryData)
            => Ok(await _plotService.AddCommonImportExportAsync(countryData));
    }
}
