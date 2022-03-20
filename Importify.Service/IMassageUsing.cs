using Importify.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Importify.Service
{
    public interface IMassageUsing
    {
        public Task<int> AddMassageAsync(Massage massage);
        public Task<int> DeleteMassageAsync(Massage massage);
        public Task<List<Massage>> GetMassagesAsync();
    }
}
