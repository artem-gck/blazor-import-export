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
    }
}
