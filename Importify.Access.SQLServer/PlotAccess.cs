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
    public class PlotAccess : IPlotAccess
    {
        private readonly ImportifyContext _context;

        public PlotAccess(ImportifyContext context)
            => _context = context;

        public async Task<List<CommonExport>> GetCountryExportAsync(string country)
             => await _context.CommonExports.Include(export => export.Country)
                                            .Include(export => export.Year)
                                            .Where(export => export.Country.Name == country)
                                            .ToListAsync();

        public async Task<List<CommonImport>> GetCountryImportAsync(string country)
            => await _context.CommonImports.Include(import => import.Country)
                                           .Include(import => import.Year)
                                           .Where(import => import.Country.Name == country)
                                           .ToListAsync();

        public async Task<List<CategoryExport>> GetCountryConstituentAsync(string country)
            => await _context.CategoryExports.Include(export => export.Category)
                                             .Include(export => export.Country)
                                             .Include(export => export.Year)
                                             .Where(export => export.Country.Name == country)
                                             .ToListAsync();

        public async Task<List<CategoryExport>> GetCountryShareAsync(string country, int year)
            => await _context.CategoryExports.Include(export => export.Category)
                                             .Include(export => export.Country)
                                             .Include(export => export.Year)
                                             .Where(export => export.Country.Name == country && export.Year.Value == year)
                                             .ToListAsync();

        public async Task<List<CategoryImport>> GetWorldImportAsync(string consiste)
            => await _context.CategoryImports.Include(import => import.Category)
                                             .Include(import => import.Country)
                                             .Include(import => import.Year)
                                             .Where(import => import.Category.Name == consiste)
                                             .ToListAsync();

        public async Task<List<CategoryExport>> GetWorldExportAsync(string consiste)
            => await _context.CategoryExports.Include(import => import.Category)
                                             .Include(import => import.Country)
                                             .Include(import => import.Year)
                                             .Where(import => import.Category.Name == consiste)
                                             .ToListAsync();

        public async Task<List<CategoryExport>> GetCategoryShareExportAsync(string consiste, int year)
            => await _context.CategoryExports.Include(import => import.Category)
                                             .Include(import => import.Country)
                                             .Include(import => import.Year)
                                             .Where(import => import.Category.Name == consiste && import.Year.Value == year)
                                             .ToListAsync();

        public async Task<List<CategoryImport>> GetCategoryShareImportAsync(string consiste, int year)
            => await _context.CategoryImports.Include(import => import.Category)
                                             .Include(import => import.Country)
                                             .Include(import => import.Year)
                                             .Where(import => import.Category.Name == consiste && import.Year.Value == year)
                                             .ToListAsync();
    }
}
