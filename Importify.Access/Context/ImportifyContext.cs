using Importify.Access.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Importify.Access.Context
{
    public class ImportifyContext : DbContext
    {
        public ImportifyContext()
        { }

        public ImportifyContext(DbContextOptions<ImportifyContext> options)
            : base(options)
        { }

        public DbSet<Category> Categories { get; set; } = null!;
        public DbSet<Year> Years { get; set; } = null!;
        public DbSet<Country> Countries { get; set; } = null!;
        public DbSet<CommonExport> CommonExports { get; set; } = null!;
        public DbSet<CommonImport> CommonImports { get; set; } = null!;
        public DbSet<CategoryExport> CategoryExports { get; set; } = null!;
        public DbSet<CategoryImport> CategoryImports { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Importify;Integrated Security=True");
        }
    }
}
