namespace Importify.Service.Models
{
    /// <summary>
    /// Massage model.
    /// </summary>
    public class Massage
    {
        /// <summary>
        /// Gets or sets the massage identifier.
        /// </summary>
        /// <value>
        /// The massage identifier.
        /// </value>
        public int MassageId { get; set; }

        /// <summary>
        /// Gets or sets the massage text.
        /// </summary>
        /// <value>
        /// The massage text.
        /// </value>
        public string MassageText { get; set; }

        /// <summary>
        /// Gets or sets the user.
        /// </summary>
        /// <value>
        /// The user.
        /// </value>
        public string User { get; set; }
    }
}
