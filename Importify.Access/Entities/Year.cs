namespace Importify.Access.Entities
{
    /// <summary>
    /// Year entity.
    /// </summary>
    public class Year
    {
        /// <summary>
        /// Gets or sets the year identifier.
        /// </summary>
        /// <value>
        /// The year identifier.
        /// </value>
        public int YearId { get; set; }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>
        /// The value.
        /// </value>
        public int Value { get; set; }

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
