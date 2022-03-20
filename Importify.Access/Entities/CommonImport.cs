namespace Importify.Access.Entities
{
    /// <summary>
    /// CommonImport entity.
    /// </summary>
    public class CommonImport
    {
        /// <summary>
        /// Gets or sets the common import identifier.
        /// </summary>
        /// <value>
        /// The common import identifier.
        /// </value>
        public int CommonImportId { get; set; }

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
    }
}
