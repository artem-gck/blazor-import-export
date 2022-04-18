using Importify.Client.Model;

namespace Importify.Client.Service
{
    public interface IPlotService
    {
        public Task<List<CountryImportExport>> GetCountryImportExportAsync(string country);
    }
}
