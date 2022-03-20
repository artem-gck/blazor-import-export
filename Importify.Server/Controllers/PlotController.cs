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
        private readonly ITokenUsing _tokenService;
        private readonly string _headerName;

        public PlotController(IPlotUsing countryService, ITokenUsing tokenService, IConfiguration configuration)
            => (_plotService, _tokenService, _headerName) = (countryService, tokenService, configuration.GetSection("HeaderName").Value);

        [HttpGet("all/{country}")]
        public async Task<ActionResult<List<CountryImportExport>>> GetCountryImportExportAsync(string country)
        {
            if (await _tokenService.CheckAccessKey(Request.Headers[_headerName].ToString()))
                return await _plotService.GetCountryImportExportAsync(country);
            else
                return Unauthorized();
        }

        [HttpGet("countryconstituent/{country}")]
        public async Task<ActionResult<List<CountryConstituent>>> GetCountryConstituentAsync(string country)
        {
            if (await _tokenService.CheckAccessKey(Request.Headers[_headerName].ToString()))
                return await _plotService.GetCountryConstituentAsync(country);
            else
                return Unauthorized();
        }

        [HttpGet("share/{country}/{year}")]
        public async Task<ActionResult<List<CountryConstituent>>> GetCountryShareAsync(string country, int year)
        {
            if (await _tokenService.CheckAccessKey(Request.Headers[_headerName].ToString()))
                return await _plotService.GetCountryShareAsync(country, year);
            else
                return Unauthorized();
        }

        [HttpGet("worldconstituent/{consiste}")]
        public async Task<ActionResult<List<WorldConstituents>>> GetWorldConstituentAsync(string consiste)
        {
            if (await _tokenService.CheckAccessKey(Request.Headers[_headerName].ToString()))
                return await _plotService.GetWorldConstituentAsync(consiste);
            else
                return Unauthorized();
        }

        [HttpGet("worldexport/{country}")]
        public async Task<ActionResult<List<WorldConstituentExport>>> GetWorldConstituentExportAsync(string country)
        {
            if (await _tokenService.CheckAccessKey(Request.Headers[_headerName].ToString()))
                 return await _plotService.GetWorldConstituentExportAsync(country);
            else
                return Unauthorized();
        }

        [HttpGet("exportshare/{consiste}/{year}")]
        public async Task<ActionResult<List<CategoryShare>>> GetCategoryShareExportAsync(string consiste, int year)
        {
            if (await _tokenService.CheckAccessKey(Request.Headers[_headerName].ToString()))
                return await _plotService.GetCategoryShareExportAsync(consiste, year);
            else
                return Unauthorized();
        }

        [HttpGet("importshare/{consiste}/{year}")]
        public async Task<ActionResult<List<CategoryShare>>> GetCategoryShareImportAsync(string consiste, int year)
        {
            if (await _tokenService.CheckAccessKey(Request.Headers[_headerName].ToString()))
                return await _plotService.GetCategoryShareImportAsync(consiste, year);
            else
                return Unauthorized();
        }

        [HttpPost("commonimportexport")]
        public async Task<ActionResult<int>> AddCommonImportExportAsync(CountryData countryData)
        {
            if (await _tokenService.CheckAccessKey(Request.Headers[_headerName].ToString()))
                return await _plotService.AddCommonImportExportAsync(countryData);
            else
                return Unauthorized();
        }

        [HttpDelete("commonimportexport")]
        public async Task<ActionResult<int>> DeleteCommonImportExportAsync(CountryData countryData)
        {
            if (await _tokenService.CheckAccessKey(Request.Headers[_headerName].ToString()))
                return await _plotService.DeleteCommonImportExportAsync(countryData);
            else
                return Unauthorized();
        }

        [HttpPut("commonimportexport")]
        public async Task<ActionResult<int>> UpdateCommonImportExportAsync(CountryData countryData)
        {
            if (await _tokenService.CheckAccessKey(Request.Headers[_headerName].ToString()))
                return await _plotService.UpdateCommonImportExportAsync(countryData);
            else
                return Unauthorized();
        }
    }
}
