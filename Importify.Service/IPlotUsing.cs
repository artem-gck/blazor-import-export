using Importify.Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Importify.Service
{
    public interface IPlotUsing
    {
        public Task<List<CountryImportExport>> GetCountryImportExportAsync(string country);
        public Task<List<CountryConstituent>> GetCountryConstituentAsync(string country);
        public Task<List<CountryConstituent>> GetCountryShareAsync(string country, int year);
        public Task<List<WorldConstituents>> GetWorldConstituentAsync(string consiste);
        public Task<List<WorldConstituentExport>> GetWorldConstituentExportAsync(string country);
        public Task<List<CategoryShare>> GetCategoryShareExportAsync(string consiste, int year);
        public Task<List<CategoryShare>> GetCategoryShareImportAsync(string consiste, int year);
    }
}
