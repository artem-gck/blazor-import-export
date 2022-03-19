using Importify.Access.Entities;

namespace Importify.Access
{
    public interface IAuthAccess
    {
        public Task<User> AuthUserAsync(string login);
        public Task<User> GetUserAsync(string login);
        public Task<bool> SetNewRefreshKeyAsync(User user);
        public Task<List<User>> GetUsersAsync();
        public Task<int> AddUserAsync(User user);
    }
}
