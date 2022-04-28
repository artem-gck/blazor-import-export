namespace Importify.Client.Model
{
    public class User
    {
        public int? UserId { get; set; }

        /// <summary>
        /// Gets or sets the login.
        /// </summary>
        /// <value>
        /// The login.
        /// </value>
        public string? Login { get; set; }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        /// <value>
        /// The password.
        /// </value>
        public string? Password { get; set; }

        /// <summary>
        /// Gets or sets the user information.
        /// </summary>
        /// <value>
        /// The user information.
        /// </value>
        public UserInfo? UserInfo { get; set; }

        /// <summary>
        /// Gets or sets the massages.
        /// </summary>
        /// <value>
        /// The massages.
        /// </value>
        public List<Massage>? Massages { get; set; }
    }
}
