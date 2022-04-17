using Importify.Client.Model;

namespace Importify.Client.Service
{
    public interface IBasicService
    {
        public Task<List<Country>> GetCountryes();
        public Task<List<Year>> GetYears();
    }
}
