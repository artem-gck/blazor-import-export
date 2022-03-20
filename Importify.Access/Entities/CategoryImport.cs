namespace Importify.Access.Entities
{
    /// <summary>
    /// CategoryImport entity.
    /// </summary>
    public class CategoryImport
    {
        /// <summary>
        /// Gets or sets the category import identifier.
        /// </summary>
        /// <value>
        /// The category import identifier.
        /// </value>
        public int CategoryImportId { get; set; }

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
