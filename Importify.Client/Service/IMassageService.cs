using Importify.Client.Model;

namespace Importify.Client.Service
{
    public interface IMassageService
    {
        public Task<int> AddMassage(Massage massage);
        public Task<List<Massage>> GetMassages();
    }
}
