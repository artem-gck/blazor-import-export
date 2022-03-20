using Importify.Service.ViewModels;

namespace Importify.Service
{
    /// <summary>
    /// Interface for token logic.
    /// </summary>
    public interface ITokenUsing
    {
        /// <summary>
        /// Refreshes the specified token API model.
        /// </summary>
        /// <param name="tokenApiModel">The token API model.</param>
        /// <returns>Tokens.</returns>
        public Task<Tokens> Refresh(Tokens tokenApiModel);

        /// <summary>
        /// Checks the access key.
        /// </summary>
        /// <param name="token">The token.</param>
        /// <returns>Result of chacking token.</returns>
        public Task<bool> CheckAccessKey(string token);
    }
}
