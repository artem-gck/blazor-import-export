using Importify.Access.Context;
using Importify.Access.Entities;
using Microsoft.EntityFrameworkCore;

namespace Importify.Access.SQLServer
{
    /// <summary>
    /// Class for massage access in SQL Server.
    /// </summary>
    /// <seealso cref="Importify.Access.IMassageAccess" />
    public class MassageAccess : IMassageAccess
    {
        private readonly ImportifyContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="MassageAccess"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public MassageAccess(ImportifyContext context)
            => _context = context;

        /// <inheritdoc/>
        public async Task<int> AddMassageAsync(Massage massage)
        {
            var mas = await _context.Massages.AddAsync(massage);
            await _context.SaveChangesAsync();

            return mas.Entity.MassageId;
        }

        /// <inheritdoc/>
        public async Task<int> DeleteMassageAsync(int id)
        {
            var massa = await _context.Massages.Include(ms => ms.User).FirstOrDefaultAsync(ms => ms.MassageId == id);

            var mas = _context.Massages.Remove(massa);
            await _context.SaveChangesAsync();

            return mas.Entity.MassageId;
        }

        /// <inheritdoc/>
        public async Task<List<Massage>> GetMassagesAsync()
            => await _context.Massages.Include(ms => ms.User).ToListAsync();
    }
}
