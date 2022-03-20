using Importify.Access.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Importify.Access
{
    public interface IMassageAccess
    {
        public Task<int> AddMassageAsync(Massage massage);
        public Task<int> DeleteMassageAsync(Massage massage);
        public Task<List<Massage>> GetMassagesAsync();
    }
}
