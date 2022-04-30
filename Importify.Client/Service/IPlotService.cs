using Importify.Client.Model;

namespace Importify.Client.Service
{
    public interface IPlotService
    {
        public Task<List<CountryImportExport>> GetCountryImportExportAsync(string country);
        public Task<List<CountryConstituent>> GetCountryConstituentAsync(string country, int year);
        public Task<List<CountryConstituent>> GetCountryConstituentExportAsync(string country);
        public Task<List<ExportConstituent>> GetExportConstituent(string category);
        public Task<List<ImportConstituent>> GetImportConstituent(string category);
        public Task<List<WorldExport>> GetWorldExport(string country);
        public Task<List<CategoryShare>> GetCategoryShareImport(string category, int year);
        public Task<List<CategoryShare>> GetCategoryShareExport(string category, int year);
        public Task<int> AddCountryData(CountryData data);
        public Task<int> UpdateCountryData(CountryData data);
        public Task<int> DeleteCountryData(CountryData data);
    }
}
