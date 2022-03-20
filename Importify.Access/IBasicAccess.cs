using Importify.Access.Entities;

namespace Importify.Access
{
    /// <summary>
    /// Interface for basic crud access.
    /// </summary>
    public interface IBasicAccess
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

        /// <summary>
        /// Gets the country.
        /// </summary>
        /// <param name="country">The country.</param>
        /// <returns>Country by name.</returns>
        public Task<Country> GetCountry(string country);

        /// <summary>
        /// Gets the year.
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns>Year by year.</returns>
        public Task<Year> GetYear(int year);

        /// <summary>
        /// Adds the country.
        /// </summary>
        /// <param name="country">The country.</param>
        /// <returns>Added country.</returns>
        public Task<Country> AddCountry(string country);

        /// <summary>
        /// Adds the year.
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns>Added year.</returns>
        public Task<Year> AddYear(int year);
    }
}
