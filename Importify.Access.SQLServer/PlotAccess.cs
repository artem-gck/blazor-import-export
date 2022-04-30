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
    /// <summary>
    /// Class for plot data access in SQL Server.
    /// </summary>
    /// <seealso cref="Importify.Access.IPlotAccess" />
    public class PlotAccess : IPlotAccess
    {
        private readonly ImportifyContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="PlotAccess"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public PlotAccess(ImportifyContext context)
            => _context = context;

        /// <inheritdoc/>
        public async Task<List<CommonExport>> GetCountryExportAsync(string country)
             => await _context.CommonExports.Include(export => export.Country)
                                            .Include(export => export.Year)
                                            .Where(export => export.Country.Name == country)
                                            .ToListAsync();

        /// <inheritdoc/>
        public async Task<List<CommonImport>> GetCountryImportAsync(string country)
            => await _context.CommonImports.Include(import => import.Country)
                                           .Include(import => import.Year)
                                           .Where(import => import.Country.Name == country)
                                           .ToListAsync();

        /// <inheritdoc/>
        public async Task<List<CategoryExport>> GetCountryConstituentAsync(string country)
            => await _context.CategoryExports.Include(export => export.Category)
                                             .Include(export => export.Country)
                                             .Include(export => export.Year)
                                             .Where(export => export.Country.Name == country)
                                             .ToListAsync();

        /// <inheritdoc/>
        public async Task<List<CategoryExport>> GetCountryShareAsync(string country, int year)
            => await _context.CategoryExports.Include(export => export.Category)
                                             .Include(export => export.Country)
                                             .Include(export => export.Year)
                                             .Where(export => export.Country.Name == country && export.Year.Value == year)
                                             .ToListAsync();

        /// <inheritdoc/>
        public async Task<List<CategoryImport>> GetWorldImportAsync(string consiste)
            => await _context.CategoryImports.Include(import => import.Category)
                                             .Include(import => import.Country)
                                             .Include(import => import.Year)
                                             .Where(import => import.Category.Name == consiste)
                                             .ToListAsync();

        /// <inheritdoc/>
        public async Task<List<CategoryExport>> GetWorldExportAsync(string consiste)
            => await _context.CategoryExports.Include(import => import.Category)
                                             .Include(import => import.Country)
                                             .Include(import => import.Year)
                                             .Where(import => import.Category.Name == consiste)
                                             .ToListAsync();

        /// <inheritdoc/>
        public async Task<List<CategoryExport>> GetCategoryShareExportAsync(string consiste, int year)
            => await _context.CategoryExports.Include(import => import.Category)
                                             .Include(import => import.Country)
                                             .Include(import => import.Year)
                                             .Where(import => import.Category.Name == consiste && import.Year.Value == year)
                                             .ToListAsync();

        /// <inheritdoc/>
        public async Task<List<CategoryImport>> GetCategoryShareImportAsync(string consiste, int year)
            => await _context.CategoryImports.Include(import => import.Category)
                                             .Include(import => import.Country)
                                             .Include(import => import.Year)
                                             .Where(import => import.Category.Name == consiste && import.Year.Value == year)
                                             .ToListAsync();

        /// <inheritdoc/>
        public async Task<int> AddCommonExportAsync(CommonExport commonExport)
        {
            var commonExportDb = await _context.CommonExports.FirstOrDefaultAsync(ce => ce.Country.Name == commonExport.Country.Name && ce.Year.Value == commonExport.Year.Value);

            if (commonExportDb is null)
            {
                var ce = await _context.CommonExports.AddAsync(commonExport);
                await _context.SaveChangesAsync();

                return ce.Entity.CommonExportId;
            }
            else
                return -1;
        }

        /// <inheritdoc/>
        public async Task<int> AddCommonImportAsync(CommonImport commonImport)
        {
            var commonImportDb = await _context.CommonImports.FirstOrDefaultAsync(ce => ce.Country.Name == commonImport.Country.Name && ce.Year.Value == commonImport.Year.Value);

            if (commonImportDb is null)
            {
                var ce = await _context.CommonImports.AddAsync(commonImport);
                await _context.SaveChangesAsync();

                return ce.Entity.CommonImportId;
            }
            else
                return -1;
        }

        /// <inheritdoc/>
        public async Task<int> DeleteCommonExportAsync(CommonExport commonExport)
        {
            var export = await _context.CommonExports.FirstOrDefaultAsync(exp => exp.Year == commonExport.Year && exp.Country.Name == commonExport.Country.Name);

            _context.CommonExports.Remove(export);
            await _context.SaveChangesAsync();

            return export.CommonExportId;
        }

        /// <inheritdoc/>
        public async Task<int> DeleteCommonImportAsync(CommonImport commonImport)
        {
            var import = await _context.CommonImports.FirstOrDefaultAsync(imp => imp.Year == commonImport.Year && imp.Country.Name == commonImport.Country.Name);

            _context.CommonImports.Remove(import);
            await _context.SaveChangesAsync();

            return import.CommonImportId;
        }

        /// <inheritdoc/>
        public async Task<int> UpdateCommonExportAsync(CommonExport commonExport)
        {
            var export = await _context.CommonExports.FirstOrDefaultAsync(exp => exp.Year == commonExport.Year && exp.Country.Name == commonExport.Country.Name);

            export.Country = commonExport.Country;
            export.Year = commonExport.Year;
            export.Value = commonExport.Value;

            await _context.SaveChangesAsync();

            return export.CommonExportId;
        }

        /// <inheritdoc/>
        public async Task<int> UpdateCommonImportAsync(CommonImport commonImport)
        {
            var import = await _context.CommonImports.FirstOrDefaultAsync(imp => imp.Year == commonImport.Year && imp.Country.Name == commonImport.Country.Name);

            import.Country = commonImport.Country;
            import.Year = commonImport.Year;
            import.Value = commonImport.Value;

            await _context.SaveChangesAsync();

            return import.CommonImportId;
        }
    }
}
