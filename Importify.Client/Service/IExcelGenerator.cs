using Importify.Client.Model;

namespace Importify.Client.Service
{
    public interface IExcelGenerator
    {
        public Task<byte[]> GenerateTotalImportExportTable(List<CountryImportExport> data);
    }
}
