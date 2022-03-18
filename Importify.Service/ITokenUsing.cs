

using Importify.Service.ViewModels;

namespace Importify.Service
{
    public interface ITokenUsing
    {
        public Task<Tokens> Refresh(Tokens tokenApiModel);
        public Task<bool> CheckAccessKey(string token);
    }
}
