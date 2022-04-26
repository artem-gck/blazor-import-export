using Importify.Access.Entities;

namespace Importify.Access
{
    /// <summary>
    /// Interface for massage access.
    /// </summary>
    public interface IMassageAccess
    {
        /// <summary>
        /// Adds the massage asynchronous.
        /// </summary>
        /// <param name="massage">The massage.</param>
        /// <returns>Id of added massage.</returns>
        public Task<int> AddMassageAsync(Massage massage);

        /// <summary>
        /// Deletes the massage asynchronous.
        /// </summary>
        /// <param name="massage">The massage.</param>
        /// <returns>Id of deleted massage.</returns>
        public Task<int> DeleteMassageAsync(int id);

        /// <summary>
        /// Gets the massages asynchronous.
        /// </summary>
        /// <returns>List of massages.</returns>
        public Task<List<Massage>> GetMassagesAsync();
    }
}
