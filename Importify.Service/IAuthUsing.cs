using Importify.Service.Models;
using Importify.Service.ViewModels;

namespace Importify.Service
{
    public interface IAuthUsing
    {
        public Task<Tokens> LoginAsync(User user);
        public Task<int> RegistrationAsync(User user);
        public Task<List<User>> GetUsersAsync();
        public Task<int> UpdateUserAsync(User user);
        public Task<int> DeleteUserAsync(User user);
    }
}
