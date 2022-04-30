using Importify.Client.Model;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.Drawing;

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

            SetStyle(sheet, 4, row);

            return await package.GetAsByteArrayAsync();
        }

        public async Task<byte[]> GenerateCategoryExportCategoryTable(List<CountryConstituent> data)
        {
            var package = new ExcelPackage();

            var sheet = package.Workbook.Worksheets.Add("Default");

            sheet.Cells[1, 1].Value = "Год";
            sheet.Cells[1, 2].Value = "Категория";
            sheet.Cells[1, 3].Value = "Экспорт";

            var row = 2;

            foreach (var item in data)
            {
                sheet.Cells[row, 1].Value = item.Year;
                sheet.Cells[row, 2].Value = item.Constituent;
                sheet.Cells[row, 3].Value = item.Value;

                row++;
            }

            SetStyle(sheet, 3, row);

            return await package.GetAsByteArrayAsync();
        }

        public async Task<byte[]> GenerateCategoryExportPlot(List<CountryConstituentPlot> data)
        {
            var package = new ExcelPackage();

            var sheet = package.Workbook.Worksheets.Add("Default");

            sheet.Cells[1, 1].Value = "Категория";
            sheet.Cells[1, 2].Value = "Экспорт";

            var row = 2;

            foreach (var item in data)
            {
                sheet.Cells[row, 1].Value = item.Constituent;
                sheet.Cells[row, 2].Value = item.Value;

                row++;
            }

            SetStyle(sheet, 2, row);

            return await package.GetAsByteArrayAsync();
        }

        public async Task<byte[]> GenerateCategoryExportTablePlot(List<ExportConstituent> data)
        {
            var package = new ExcelPackage();

            var sheet = package.Workbook.Worksheets.Add("Default");

            sheet.Cells[1, 1].Value = "Год";
            sheet.Cells[1, 2].Value = "Экспорт";
            sheet.Cells[1, 2].Value = "Страна";

            var row = 2;

            foreach (var item in data)
            {
                sheet.Cells[row, 1].Value = item.Year;
                sheet.Cells[row, 2].Value = item.ExportValue;
                sheet.Cells[row, 3].Value = item.Country;

                row++;
            }

            SetStyle(sheet, 3, row);

            return await package.GetAsByteArrayAsync();
        }

        public async Task<byte[]> GenerateCategoryImportTablePlot(List<ImportConstituent> data)
        {
            var package = new ExcelPackage();

            var sheet = package.Workbook.Worksheets.Add("Default");

            sheet.Cells[1, 1].Value = "Год";
            sheet.Cells[1, 2].Value = "Импорт";
            sheet.Cells[1, 2].Value = "Страна";

            var row = 2;

            foreach (var item in data)
            {
                sheet.Cells[row, 1].Value = item.Year;
                sheet.Cells[row, 2].Value = item.ImportValue;
                sheet.Cells[row, 3].Value = item.Country;

                row++;
            }

            SetStyle(sheet, 3, row);

            return await package.GetAsByteArrayAsync();
        }

        public async Task<byte[]> GenerateTotalExportTable(List<WorldExport> data)
        {
            var package = new ExcelPackage();

            var sheet = package.Workbook.Worksheets.Add("Default");

            sheet.Cells[1, 1].Value = "Год";
            sheet.Cells[1, 2].Value = "Экспорт";

            var row = 2;

            foreach (var item in data)
            {
                sheet.Cells[row, 1].Value = item.Year;
                sheet.Cells[row, 2].Value = item.Value;

                row++;
            }

            SetStyle(sheet, 2, row);

            return await package.GetAsByteArrayAsync();
        }

        public async Task<byte[]> GenerateShareOfCountriesImportTable(List<CategoryShare> data)
        {
            var package = new ExcelPackage();

            var sheet = package.Workbook.Worksheets.Add("Default");

            sheet.Cells[1, 1].Value = "Год";
            sheet.Cells[1, 2].Value = "Импорт";

            var row = 2;

            foreach (var item in data)
            {
                sheet.Cells[row, 1].Value = item.Country;
                sheet.Cells[row, 2].Value = item.Value;

                row++;
            }

            SetStyle(sheet, 2, row);

            return await package.GetAsByteArrayAsync();
        }

        public async Task<byte[]> GenerateShareOfCountriesExportTable(List<CategoryShare> data)
        {
            var package = new ExcelPackage();

            var sheet = package.Workbook.Worksheets.Add("Default");

            sheet.Cells[1, 1].Value = "Год";
            sheet.Cells[1, 2].Value = "Экспорт";

            var row = 2;

            foreach (var item in data)
            {
                sheet.Cells[row, 1].Value = item.Country;
                sheet.Cells[row, 2].Value = item.Value;

                row++;
            }

            SetStyle(sheet, 2, row);

            return await package.GetAsByteArrayAsync();
        }

        private void SetStyle(ExcelWorksheet sheet, int colomn, int row)
        {
            sheet.Cells[1, 1, row - 1, colomn].AutoFitColumns();

            for (var i = 1; i < colomn + 1; i++)
                sheet.Column(i).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

            for (var x = 1; x < colomn + 1; x++)
                for (var y = 1; y < row; y++)
                    sheet.Cells[y, x].Style.Border.BorderAround(ExcelBorderStyle.Thin);

            for (var x = 1; x < colomn + 1; x++)
            {
                sheet.Cells[1, x].Style.Fill.PatternType = ExcelFillStyle.Solid;
                sheet.Cells[1, x].Style.Fill.BackgroundColor.SetColor(Color.LightGreen);
            }
        }
    }
}
