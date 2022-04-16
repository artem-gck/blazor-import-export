using Importify.Client.Model;

namespace Importify.Client.Service
{
    public interface IAuthService
    {
        public Task<Tokens> Login(LoginUser user);
        public Task<int> Registration(RegistrationUser user);
    }
}
