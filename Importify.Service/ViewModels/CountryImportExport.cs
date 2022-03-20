namespace Importify.Service.ViewModels
{
    /// <summary>
    /// CountryImportExport viewModel.
    /// </summary>
    public class CountryImportExport
    {
        /// <summary>
        /// Gets or sets the year.
        /// </summary>
        /// <value>
        /// The year.
        /// </value>
        public int Year { get; set; }

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
        /// Gets or sets the net export value.
        /// </summary>
        /// <value>
        /// The net export value.
        /// </value>
        public decimal NetExportValue { get; set; }
    }
}
