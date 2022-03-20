namespace Importify.Access.Entities
{
    /// <summary>
    /// Category entity.
    /// </summary>
    public class Category
    {
        /// <summary>
        /// Gets or sets the category identifier.
        /// </summary>
        /// <value>
        /// The category identifier.
        /// </value>
        public int CategoryId { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }

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
