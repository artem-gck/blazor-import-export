using Importify.Access.Entities;

namespace Importify.Access
{
    /// <summary>
    /// Interface for authentification access.
    /// </summary>
    public interface IAuthAccess
    {
        /// <summary>
        /// Gets the user asynchronous.
        /// </summary>
        /// <param name="login">The login.</param>
        /// <returns>User by login.</returns>
        public Task<User> GetUserAsync(string login);

        /// <summary>
        /// Sets the new refresh key asynchronous.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns>Result of setting new refresh token.</returns>
        public Task<bool> SetNewRefreshKeyAsync(User user);

        /// <summary>
        /// Gets the users asynchronous.
        /// </summary>
        /// <returns>List of users.</returns>
        public Task<List<User>> GetUsersAsync();

        /// <summary>
        /// Adds the user asynchronous.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns>Id of new user.</returns>
        public Task<int> AddUserAsync(User user);

        /// <summary>
        /// Updates the user asynchronous.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns>Id of updated user.</returns>
        public Task<int> UpdateUserAsync(User user);

        /// <summary>
        /// Deletes the user asynchronous.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns>Id of deleted user.</returns>
        public Task<int> DeleteUserAsync(int id);

        public Task<List<Role>> GetAllRoles();
    }
}
