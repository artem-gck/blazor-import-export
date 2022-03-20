namespace Importify.Service.ViewModels
{
    /// <summary>
    /// WorldConstituents viewModel.
    /// </summary>
    public class WorldConstituents
    {
        /// <summary>
        /// Gets or sets the year.
        /// </summary>
        /// <value>
        /// The year.
        /// </value>
        public int Year { get; set; }

        /// <summary>
        /// Gets or sets the constituent.
        /// </summary>
        /// <value>
        /// The constituent.
        /// </value>
        public string Constituent { get; set; }

        /// <summary>
        /// Gets or sets the export value.
        /// </summary>
        /// <value>
        /// The export value.
        /// </value>
        public decimal ExportValue { get; set; }

        /// <summary>
        /// Gets or sets the import value.
        /// </summary>
        /// <value>
        /// The import value.
        /// </value>
        public decimal ImportValue { get; set; }

        /// <summary>
        /// Gets or sets the country.
        /// </summary>
        /// <value>
        /// The country.
        /// </value>
        public string Country { get; set; }
    }
}
