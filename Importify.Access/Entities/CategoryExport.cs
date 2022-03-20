namespace Importify.Access.Entities
{
    /// <summary>
    /// CategoryExport entity.
    /// </summary>
    public class CategoryExport
    {
        /// <summary>
        /// Gets or sets the category export identifier.
        /// </summary>
        /// <value>
        /// The category export identifier.
        /// </value>
        public int CategoryExportId { get; set; }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>
        /// The value.
        /// </value>
        public decimal Value { get; set; }

        /// <summary>
        /// Gets or sets the country.
        /// </summary>
        /// <value>
        /// The country.
        /// </value>
        public Country? Country { get; set; }

        /// <summary>
        /// Gets or sets the year.
        /// </summary>
        /// <value>
        /// The year.
        /// </value>
        public Year? Year { get; set; }

        /// <summary>
        /// Gets or sets the category.
        /// </summary>
        /// <value>
        /// The category.
        /// </value>
        public Category? Category { get; set; }
    }
}
