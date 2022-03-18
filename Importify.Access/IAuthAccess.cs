using Importify.Access.Entities;

namespace Importify.Access
{
    public interface IAuthAccess
    {
        public Task<User> AuthUserAsync(string login, string password);
        public Task<User> GetUserAsync(string login);
        public Task<bool> SetNewRefreshKeyAsync(User user); 
    }
}
