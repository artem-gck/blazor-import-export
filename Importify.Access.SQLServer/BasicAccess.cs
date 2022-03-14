using Importify.Access.Context;
using Importify.Access.Entities;
using Microsoft.EntityFrameworkCore;

namespace Importify.Access.SQLServer
{
    public class BasicAccess : IBasicAccess
    {
        private readonly ImportifyContext _context;

        public BasicAccess(ImportifyContext context)
            => _context = context;

        public async Task<List<Category>> GetCategoryAsync()
            => await _context.Categories.ToListAsync();

        public async Task<List<Country>> GetCountriesAsync()
            => await _context.Countries.ToListAsync();

        public async Task<List<Year>> GetYearsAsync()
            => await _context.Years.ToListAsync();
    }
}
