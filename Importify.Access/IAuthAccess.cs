using Importify.Access.Entities;

namespace Importify.Access
{
    public interface IAuthAccess
    {
        public Task<User> GetUserAsync(string login);
        public Task<bool> SetNewRefreshKeyAsync(User user);
        public Task<List<User>> GetUsersAsync();
        public Task<int> AddUserAsync(User user);
        public Task<int> UpdateUserAsync(User user);
        public Task<int> DeleteUserAsync(User user);
    }
}
