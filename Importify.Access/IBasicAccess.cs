using Importify.Access.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Importify.Access
{
    public interface IBasicAccess
    {
        public Task<List<Country>> GetCountriesAsync();
        public Task<List<Year>> GetYearsAsync();
        public Task<List<Category>> GetCategoryAsync();
    }
}
