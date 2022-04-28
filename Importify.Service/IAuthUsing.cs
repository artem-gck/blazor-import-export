using Importify.Service.Models;
using Importify.Service.ViewModels;

namespace Importify.Service
{
    /// <summary>
    /// Interface for authentification logic.
    /// </summary>
    public interface IAuthUsing
    {
        /// <summary>
        /// Logins the asynchronous.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns>Tokens.</returns>
        public Task<Tokens> LoginAsync(User user);

        /// <summary>
        /// Registrations the asynchronous.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns>Id of new user.</returns>
        public Task<int> RegistrationAsync(User user);

        /// <summary>
        /// Gets the users asynchronous.
        /// </summary>
        /// <returns>List of users.</returns>
        public Task<List<User>> GetUsersAsync();

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

        public Task<User> GetUser(string login);

        public Task<List<Role>> GetAllRoles();

        public Task<int> AddUserAsync(User user);
    }
}
