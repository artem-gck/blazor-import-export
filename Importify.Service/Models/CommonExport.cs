namespace Importify.Service.Models
{
    /// <summary>
    /// CommonExport model.
    /// </summary>
    public class CommonExport
    {
        /// <summary>
        /// Gets or sets the common export identifier.
        /// </summary>
        /// <value>
        /// The common export identifier.
        /// </value>
        public int CommonExportId { get; set; }

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
