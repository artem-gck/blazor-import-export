using Importify.Service.ViewModels;

namespace Importify.Service
{
    /// <summary>
    /// Interface for plot logic.
    /// </summary>
    public interface IPlotUsing
    {
        /// <summary>
        /// Gets the country import export asynchronous.
        /// </summary>
        /// <param name="country">The country.</param>
        /// <returns>CountryImportExport value.</returns>
        public Task<List<CountryImportExport>> GetCountryImportExportAsync(string country);

        /// <summary>
        /// Gets the country constituent asynchronous.
        /// </summary>
        /// <param name="country">The country.</param>
        /// <returns>CountryConstituent value.</returns>
        public Task<List<CountryConstituent>> GetCountryConstituentAsync(string country);

        /// <summary>
        /// Gets the country share asynchronous.
        /// </summary>
        /// <param name="country">The country.</param>
        /// <param name="year">The year.</param>
        /// <returns>Data for share.</returns>
        public Task<List<CountryConstituent>> GetCountryShareAsync(string country, int year);

        /// <summary>
        /// Gets the world constituent asynchronous.
        /// </summary>
        /// <param name="consiste">The consiste.</param>
        /// <returns>WorldConstituents value.</returns>
        public Task<List<WorldConstituents>> GetWorldConstituentAsync(string consiste);

        /// <summary>
        /// Gets the world constituent export asynchronous.
        /// </summary>
        /// <param name="country">The country.</param>
        /// <returns>WorldConstituentExport value.</returns>
        public Task<List<WorldConstituentExport>> GetWorldConstituentExportAsync(string country);

        /// <summary>
        /// Gets the category share export asynchronous.
        /// </summary>
        /// <param name="consiste">The consiste.</param>
        /// <param name="year">The year.</param>
        /// <returns>Data for export share.</returns>
        public Task<List<CategoryShare>> GetCategoryShareExportAsync(string consiste, int year);

        /// <summary>
        /// Gets the category share import asynchronous.
        /// </summary>
        /// <param name="consiste">The consiste.</param>
        /// <param name="year">The year.</param>
        /// <returns>Data for import share.</returns>
        public Task<List<CategoryShare>> GetCategoryShareImportAsync(string consiste, int year);

        /// <summary>
        /// Adds the common import export asynchronous.
        /// </summary>
        /// <param name="countryData">The country data.</param>
        /// <returns>Id of new CommonImportExport.</returns>
        public Task<int> AddCommonImportExportAsync(CountryData countryData);

        /// <summary>
        /// Deletes the common import export asynchronous.
        /// </summary>
        /// <param name="countryData">The country data.</param>
        /// <returns>Id of deleted CommonImportExport.</returns>
        public Task<int> DeleteCommonImportExportAsync(CountryData countryData);

        /// <summary>
        /// Updates the common import export asynchronous.
        /// </summary>
        /// <param name="countryData">The country data.</param>
        /// <returns>Id of updated CommonImportExport.</returns>
        public Task<int> UpdateCommonImportExportAsync(CountryData countryData);
    }
}
