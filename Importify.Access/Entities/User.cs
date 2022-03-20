namespace Importify.Access.Entities
{
    /// <summary>
    /// User entity.
    /// </summary>
    public class User
    {
        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        /// <value>
        /// The user identifier.
        /// </value>
        public int UserId { get; set; }

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
        public byte[]? Password { get; set; }

        /// <summary>
        /// Gets or sets the refresh token.
        /// </summary>
        /// <value>
        /// The refresh token.
        /// </value>
        public string? RefreshToken { get; set; }

        /// <summary>
        /// Gets or sets the refresh token expiry time.
        /// </summary>
        /// <value>
        /// The refresh token expiry time.
        /// </value>
        public DateTime? RefreshTokenExpiryTime { get; set; }

        /// <summary>
        /// Gets or sets the user information.
        /// </summary>
        /// <value>
        /// The user information.
        /// </value>
        public UserInfo UserInfo { get; set; }

        /// <summary>
        /// Gets or sets the massages.
        /// </summary>
        /// <value>
        /// The massages.
        /// </value>
        public List<Massage> Massages { get; set; } = new();
    }
}
