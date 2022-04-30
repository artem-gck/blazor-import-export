using Importify.Client.Model;

namespace Importify.Client.Service
{
    public interface IExcelGenerator
    {
        public Task<byte[]> GenerateTotalImportExportTable(List<CountryImportExport> data);
        public Task<byte[]> GenerateCategoryExportCategoryTable(List<CountryConstituent> data);
        public Task<byte[]> GenerateCategoryExportPlot(List<CountryConstituentPlot> data);
        public Task<byte[]> GenerateCategoryExportTablePlot(List<ExportConstituent> data);
        public Task<byte[]> GenerateCategoryImportTablePlot(List<ImportConstituent> data);
        public Task<byte[]> GenerateTotalExportTable(List<WorldExport> data);
        public Task<byte[]> GenerateShareOfCountriesImportTable(List<CategoryShare> data);
        public Task<byte[]> GenerateShareOfCountriesExportTable(List<CategoryShare> data);
    }
}
