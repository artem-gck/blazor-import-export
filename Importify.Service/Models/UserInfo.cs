namespace Importify.Service.Models
{
    /// <summary>
    /// UserInfo model.
    /// </summary>
    public class UserInfo
    {
        /// <summary>
        /// Gets or sets the user information identifier.
        /// </summary>
        /// <value>
        /// The user information identifier.
        /// </value>
        public int UserInfoId { get; set; }

        /// <summary>
        /// Gets or sets the number of phone.
        /// </summary>
        /// <value>
        /// The number of phone.
        /// </value>
        public string NumberOfPhone { get; set; }

        /// <summary>
        /// Gets or sets the position.
        /// </summary>
        /// <value>
        /// The position.
        /// </value>
        public Role? Role { get; set; }

        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        /// <value>
        /// The email.
        /// </value>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        /// <value>
        /// The user identifier.
        /// </value>
        public int UserId { get; set; }

        /// <summary>
        /// Gets or sets the user.
        /// </summary>
        /// <value>
        /// The user.
        /// </value>
        public User? User { get; set; }
    }
}
