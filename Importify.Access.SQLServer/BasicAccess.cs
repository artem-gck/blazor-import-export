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

        public async Task<Country> GetCountry(string country)
        {
            var countryDb = await _context.Countries.FirstOrDefaultAsync(c => c.Name == country);

            if (countryDb is not null)
                return countryDb;
            else
                return null;
        }

        public async Task<Year> GetYear(int year)
        {
            var yearDb = await _context.Years.FirstOrDefaultAsync(c => c.Value == year);

            if (yearDb is not null)
                return yearDb;
            else
                return null;
        }

        public async Task<Country> AddCountry(string country)
        {
            var countryDb = new Country()
            {
                Name = country,
            };

            var co = await _context.Countries.AddAsync(countryDb);
            return co.Entity;
        }

        public async Task<Year> AddYear(int year)
        {
            var yearDb = new Year()
            {
                Value = year,
            };

            var ye = await _context.Years.AddAsync(yearDb);
            return ye.Entity;
        }
    }
}
