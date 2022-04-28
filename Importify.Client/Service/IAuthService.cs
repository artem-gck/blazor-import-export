using Importify.Client.Model;

namespace Importify.Client.Service
{
    public interface IAuthService
    {
        public Task<Tokens> Login(LoginUser user);
        public Task<int> Registration(RegistrationUser user);
        public Task<User> GetUser(string login);
        public Task<List<UserView>> GetUsers();
        public Task<int> DeleteUser(int id);
        public Task<int> AddUser(User user);
        public Task<int> UpdateUser(User user);
        public Task<List<Role>> GetAllRoles();
    }
}
