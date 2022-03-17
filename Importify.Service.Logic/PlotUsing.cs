using Importify.Access;
using Importify.Access.Entities;
using Importify.Service.ViewModels;

namespace Importify.Service.Logic
{
    public class PlotUsing : IPlotUsing
    {
        private readonly IPlotAccess _plotAccess;
        private readonly IBasicAccess _basicAccess;

        public PlotUsing(IPlotAccess plotAccess, IBasicAccess basicAccess)
            => (_plotAccess,  _basicAccess) = (plotAccess, basicAccess);

        public async Task<List<CountryImportExport>> GetCountryImportExportAsync(string country)
        {
            var import = await _plotAccess.GetCountryImportAsync(country);
            var export = await _plotAccess.GetCountryExportAsync(country);

            var result = new List<CountryImportExport>(import.Count);
            
            for(var i = 0; i < import.Count; i++)
            {
                result.Add(new CountryImportExport()
                {
                    Year = import[i].Year.Value,
                    ExportValue = export[i].Value,
                    ImportValue = import[i].Value,
                    NetExportValue = import[i].Value - export[i].Value,
                });
            }

            return result;
        }

        public async Task<List<CountryConstituent>> GetCountryConstituentAsync(string country)
        {
            var export = await _plotAccess.GetCountryConstituentAsync(country);

            return export.Select(exp => new CountryConstituent()
            {
                Year = exp.Year.Value,
                Constituent = exp.Category.Name,
                Value = exp.Value
            }).ToList();
        }

        public async Task<List<CountryConstituent>> GetCountryShareAsync(string country, int year)
        {
            var export = await _plotAccess.GetCountryShareAsync(country, year);

            return export.Select(exp => new CountryConstituent()
            {
                Year = exp.Year.Value,
                Constituent = exp.Category.Name,
                Value = exp.Value
            }).ToList();
        }

        public async Task<List<WorldConstituents>> GetWorldConstituentAsync(string consiste)
        {
            var import = await _plotAccess.GetWorldImportAsync(consiste);
            var export = await _plotAccess.GetWorldExportAsync(consiste);

            var result = new List<WorldConstituents>(import.Count);

            for (var i = 0; i < import.Count; i++)
            {
                result.Add(new WorldConstituents()
                {
                    Year = import[i].Year.Value,
                    Constituent = import[i].Category.Name,
                    ExportValue = export[i].Value,
                    ImportValue = import[i].Value,
                    Country = import[i].Country.Name
                });
            }

            return result;
        }

        public async Task<List<WorldConstituentExport>> GetWorldConstituentExportAsync(string country)
        {
            var export = await _plotAccess.GetCountryConstituentAsync(country);

            return export.GroupBy(exp => exp.Year)
                         .Select(r => new WorldConstituentExport()
                         {
                             Year = r.Key.Value,
                             Value = r.Sum(t => t.Value)
                         }).ToList();
        }

        public async Task<List<CategoryShare>> GetCategoryShareExportAsync(string consiste, int year)
        {
            var export = await _plotAccess.GetCategoryShareExportAsync(consiste, year);

            return export.Select(exp => new CategoryShare()
            {
                Country = exp.Country.Name,
                Value = exp.Value
            }).ToList();
        }

        public async Task<List<CategoryShare>> GetCategoryShareImportAsync(string consiste, int year)
        {
            var import = await _plotAccess.GetCategoryShareImportAsync(consiste, year);

            return import.Select(exp => new CategoryShare()
            {
                Country = exp.Country.Name,
                Value = exp.Value
            }).ToList();
        }

        public async Task<(int, int)> AddCommonImportExportAsync(CountryData countryData)
        {
            var country = await _basicAccess.GetCountry(countryData.Country);
            var year = await _basicAccess.GetYear(countryData.Year);

            country = country is not null ? country : await _basicAccess.AddCountry(countryData.Country);
            year = year is not null ? year : await _basicAccess.AddYear(countryData.Year);

            var commonExport = new CommonExport()
            {
                Value = countryData.ExportValue,
                Year = year,
                Country = country
            };

            var commonImport = new CommonImport()
            {
                Value = countryData.ImportValue,
                Year = year,
                Country = country
            };

            var commonExportId = await _plotAccess.AddCommonExportAsync(commonExport);
            var commonImportId = await _plotAccess.AddCommonImportAsync(commonImport);

            return (commonExportId, commonImportId);
        }
    }
}