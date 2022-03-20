using Importify.Service.Models;

namespace Importify.Service
{
    /// <summary>
    /// Interface for basic crud.
    /// </summary>
    public interface IBasicUsing
    {
        /// <summary>
        /// Gets the countries asynchronous.
        /// </summary>
        /// <returns>List of countries.</returns>
        public Task<List<Country>> GetCountriesAsync();

        /// <summary>
        /// Gets the years asynchronous.
        /// </summary>
        /// <returns>List of years.</returns>
        public Task<List<Year>> GetYearsAsync();

        /// <summary>
        /// Gets the category asynchronous.
        /// </summary>
        /// <returns>List of categories.</returns>
        public Task<List<Category>> GetCategoryAsync();
    }
}
