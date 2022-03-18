using Importify.Service.Models;
using Importify.Service.ViewModels;

namespace Importify.Service
{
    public interface IAuthUsing
    {
        public Task<Tokens> Login(User loginModel);
    }
}
