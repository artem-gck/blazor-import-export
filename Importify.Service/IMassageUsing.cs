using Importify.Service.Models;

namespace Importify.Service
{
    /// <summary>
    /// Interface for massages logic.
    /// </summary>
    public interface IMassageUsing
    {
        /// <summary>
        /// Adds the massage asynchronous.
        /// </summary>
        /// <param name="massage">The massage.</param>
        /// <returns>Id of new massage.</returns>
        public Task<int> AddMassageAsync(Massage massage);

        /// <summary>
        /// Deletes the massage asynchronous.
        /// </summary>
        /// <param name="massage">The massage.</param>
        /// <returns>Id of deleted massage.</returns>
        public Task<int> DeleteMassageAsync(Massage massage);

        /// <summary>
        /// Gets the massages asynchronous.
        /// </summary>
        /// <returns>List of massages.</returns>
        public Task<List<Massage>> GetMassagesAsync();
    }
}
