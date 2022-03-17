using Importify.Access.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Importify.Access
{
    public interface IPlotAccess
    {
        public Task<List<CommonImport>> GetCountryImportAsync(string country);
        public Task<List<CommonExport>> GetCountryExportAsync(string country);
        public Task<List<CategoryExport>> GetCountryConstituentAsync(string country);
        public Task<List<CategoryExport>> GetCountryShareAsync(string country, int year);
        public Task<List<CategoryImport>> GetWorldImportAsync(string consiste);
        public Task<List<CategoryExport>> GetWorldExportAsync(string consiste);
        public Task<List<CategoryExport>> GetCategoryShareExportAsync(string consiste, int year);
        public Task<List<CategoryImport>> GetCategoryShareImportAsync(string consiste, int year);
        public Task<int> AddCommonImportAsync(CommonImport commonImport);
        public Task<int> AddCommonExportAsync(CommonExport commonExport);
    }
}
