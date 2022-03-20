namespace Importify.Access.Entities
{
    /// <summary>
    /// Country entity.
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

        /// <summary>
        /// Gets or sets the common exports.
        /// </summary>
        /// <value>
        /// The common exports.
        /// </value>
        public List<CommonExport>? CommonExports { get; set; } = new();

        /// <summary>
        /// Gets or sets the common imports.
        /// </summary>
        /// <value>
        /// The common imports.
        /// </value>
        public List<CommonImport>? CommonImports { get; set; } = new();

        /// <summary>
        /// Gets or sets the category exports.
        /// </summary>
        /// <value>
        /// The category exports.
        /// </value>
        public List<CategoryExport>? CategoryExports { get; set; } = new();

        /// <summary>
        /// Gets or sets the category imports.
        /// </summary>
        /// <value>
        /// The category imports.
        /// </value>
        public List<CategoryImport>? CategoryImports { get; set; } = new();
    }
}
