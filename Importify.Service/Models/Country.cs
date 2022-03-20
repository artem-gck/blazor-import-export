namespace Importify.Service.Models
{
    /// <summary>
    /// Country model.
    /// </summary>
    public class Country
    {
        /// <summary>
        /// Gets or sets the country identifier.
        /// </summary>
        /// <value>
        /// The country identifier.
        /// </value>
        public int CountryId { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the area.
        /// </summary>
        /// <value>
        /// The area.
        /// </value>
        public double? Area { get; set; }

        /// <summary>
        /// Gets or sets the population.
        /// </summary>
        /// <value>
        /// The population.
        /// </value>
        public long? Population { get; set; }

        /// <summary>
        /// Gets or sets the GDP.
        /// </summary>
        /// <value>
        /// The GDP.
        /// </value>
        public decimal? Gdp { get; set; }
    }
}
