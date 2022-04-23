using Importify.Client.Model;

namespace Importify.Client.Service
{
    public interface IExcelGenerator
    {
        public Task<byte[]> GenerateTotalImportExportTable(List<CountryImportExport> data);
        public Task<byte[]> GenerateCategoryExportCategoryTable(List<CountryConstituent> data);
        public Task<byte[]> GenerateCategoryExportPlot(List<CountryConstituentPlot> data);
    }
}
