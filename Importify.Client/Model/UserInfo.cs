namespace Importify.Client.Model
{
    public class UserInfo
    {
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
    }
}
