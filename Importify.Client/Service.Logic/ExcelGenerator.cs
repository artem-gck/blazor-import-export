using Importify.Client.Model;
using OfficeOpenXml;

namespace Importify.Client.Service.Logic
{
    public class ExcelGenerator : IExcelGenerator
    { 
        public async Task<byte[]> GenerateTotalImportExportTable(List<CountryImportExport> data)
        {
            var package = new ExcelPackage();

            var sheet = package.Workbook.Worksheets.Add("Default");

            sheet.Cells[1, 1].Value = "Год";
            sheet.Cells[1, 2].Value = "Импорт";
            sheet.Cells[1, 3].Value = "Экспорт";
            sheet.Cells[1, 4].Value = "Сальдо";

            var row = 2;

            foreach (var item in data)
            {
                sheet.Cells[row, 1].Value = item.Year;
                sheet.Cells[row, 2].Value = item.ImportValue;
                sheet.Cells[row, 3].Value = item.ExportValue;
                sheet.Cells[row, 4].Value = item.NetExportValue;

                row++;
            }

            return await package.GetAsByteArrayAsync();
        }
    }
}
