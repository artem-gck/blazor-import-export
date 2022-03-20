using Importify.Access.Context;
using Importify.Access.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Importify.Access.SQLServer
{
    public class MassageAccess : IMassageAccess
    {
        private readonly ImportifyContext _context;

        public MassageAccess(ImportifyContext context)
            => _context = context;

        public async Task<int> AddMassageAsync(Massage massage)
        {
            var mas = await _context.Massages.AddAsync(massage);
            await _context.SaveChangesAsync();

            return mas.Entity.MassageId;
        }

        public async Task<int> DeleteMassageAsync(Massage massage)
        {
            var massa = await _context.Massages.Include(ms => ms.User).FirstOrDefaultAsync(ms => ms.User == massage.User && ms.MassageText == massage.MassageText);

            var mas = _context.Massages.Remove(massa);
            await _context.SaveChangesAsync();

            return mas.Entity.MassageId;
        }

        public async Task<List<Massage>> GetMassagesAsync()
            => await _context.Massages.Include(ms => ms.User).ToListAsync();
    }
}
