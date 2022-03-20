using Importify.Access.Entities;

namespace Importify.Access
{
    /// <summary>
    /// Interface for plot data access.
    /// </summary>
    public interface IPlotAccess
    {
        /// <summary>
        /// Gets the country import asynchronous.
        /// </summary>
        /// <param name="country">The country.</param>
        /// <returns>CommonImport value.</returns>
        public Task<List<CommonImport>> GetCountryImportAsync(string country);

        /// <summary>
        /// Gets the country export asynchronous.
        /// </summary>
        /// <param name="country">The country.</param>
        /// <returns>CommonExport value.</returns>
        public Task<List<CommonExport>> GetCountryExportAsync(string country);

        /// <summary>
        /// Gets the country constituent asynchronous.
        /// </summary>
        /// <param name="country">The country.</param>
        /// <returns>CategoryExport value.</returns>
        public Task<List<CategoryExport>> GetCountryConstituentAsync(string country);

        /// <summary>
        /// Gets the country share asynchronous.
        /// </summary>
        /// <param name="country">The country.</param>
        /// <param name="year">The year.</param>
        /// <returns>Data for country share.</returns>
        public Task<List<CategoryExport>> GetCountryShareAsync(string country, int year);

        /// <summary>
        /// Gets the world import asynchronous.
        /// </summary>
        /// <param name="consiste">The consiste.</param>
        /// <returns>World import.</returns>
        public Task<List<CategoryImport>> GetWorldImportAsync(string consiste);

        /// <summary>
        /// Gets the world export asynchronous.
        /// </summary>
        /// <param name="consiste">The consiste.</param>
        /// <returns>World export.</returns>
        public Task<List<CategoryExport>> GetWorldExportAsync(string consiste);

        /// <summary>
        /// Gets the category share export asynchronous.
        /// </summary>
        /// <param name="consiste">The consiste.</param>
        /// <param name="year">The year.</param>
        /// <returns>Category export share.</returns>
        public Task<List<CategoryExport>> GetCategoryShareExportAsync(string consiste, int year);

        /// <summary>
        /// Gets the category share import asynchronous.
        /// </summary>
        /// <param name="consiste">The consiste.</param>
        /// <param name="year">The year.</param>
        /// <returns>Category import share.</returns>
        public Task<List<CategoryImport>> GetCategoryShareImportAsync(string consiste, int year);

        /// <summary>
        /// Adds the common import asynchronous.
        /// </summary>
        /// <param name="commonImport">The common import.</param>
        /// <returns>Id of new CommonImport.</returns>
        public Task<int> AddCommonImportAsync(CommonImport commonImport);

        /// <summary>
        /// Adds the common export asynchronous.
        /// </summary>
        /// <param name="commonExport">The common export.</param>
        /// <returns>Id of new CommonExport.</returns>
        public Task<int> AddCommonExportAsync(CommonExport commonExport);

        /// <summary>
        /// Deletes the common export asynchronous.
        /// </summary>
        /// <param name="commonExport">The common export.</param>
        /// <returns>Id of deleted CommonExport.</returns>
        public Task<int> DeleteCommonExportAsync(CommonExport commonExport);

        /// <summary>
        /// Deletes the common import asynchronous.
        /// </summary>
        /// <param name="commonImport">The common import.</param>
        /// <returns>Id of deleted CommonImport.</returns>
        public Task<int> DeleteCommonImportAsync(CommonImport commonImport);

        /// <summary>
        /// Updates the common export asynchronous.
        /// </summary>
        /// <param name="commonExport">The common export.</param>
        /// <returns>Id of updated CommonExport.</returns>
        public Task<int> UpdateCommonExportAsync(CommonExport commonExport);

        /// <summary>
        /// Updates the common import asynchronous.
        /// </summary>
        /// <param name="commonImport">The common import.</param>
        /// <returns>Id of updated CommonImport.</returns>
        public Task<int> UpdateCommonImportAsync(CommonImport commonImport);
    }
}
