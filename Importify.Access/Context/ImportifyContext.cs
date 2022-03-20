using Importify.Access.Entities;
using Microsoft.EntityFrameworkCore;

namespace Importify.Access.Context
{
    /// <summary>
    /// Class for context.
    /// </summary>
    /// <seealso cref="Microsoft.EntityFrameworkCore.DbContext" />
    public class ImportifyContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ImportifyContext"/> class.
        /// </summary>
        /// <remarks>
        /// See <see href="https://aka.ms/efcore-docs-dbcontext">DbContext lifetime, configuration, and initialization</see>
        /// for more information.
        /// </remarks>
        public ImportifyContext()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="ImportifyContext"/> class.
        /// </summary>
        /// <param name="options">The options.</param>
        public ImportifyContext(DbContextOptions<ImportifyContext> options)
            : base(options)
        { }

        /// <summary>
        /// Gets or sets the categories.
        /// </summary>
        /// <value>
        /// The categories.
        /// </value>
        public DbSet<Category> Categories { get; set; } = null!;

        /// <summary>
        /// Gets or sets the years.
        /// </summary>
        /// <value>
        /// The years.
        /// </value>
        public DbSet<Year> Years { get; set; } = null!;

        /// <summary>
        /// Gets or sets the countries.
        /// </summary>
        /// <value>
        /// The countries.
        /// </value>
        public DbSet<Country> Countries { get; set; } = null!;

        /// <summary>
        /// Gets or sets the common exports.
        /// </summary>
        /// <value>
        /// The common exports.
        /// </value>
        public DbSet<CommonExport> CommonExports { get; set; } = null!;

        /// <summary>
        /// Gets or sets the common imports.
        /// </summary>
        /// <value>
        /// The common imports.
        /// </value>
        public DbSet<CommonImport> CommonImports { get; set; } = null!;

        /// <summary>
        /// Gets or sets the category exports.
        /// </summary>
        /// <value>
        /// The category exports.
        /// </value>
        public DbSet<CategoryExport> CategoryExports { get; set; } = null!;

        /// <summary>
        /// Gets or sets the category imports.
        /// </summary>
        /// <value>
        /// The category imports.
        /// </value>
        public DbSet<CategoryImport> CategoryImports { get; set; } = null!;

        /// <summary>
        /// Gets or sets the users.
        /// </summary>
        /// <value>
        /// The users.
        /// </value>
        public DbSet<User> Users { get; set; } = null!;

        /// <summary>
        /// Gets or sets the user infos.
        /// </summary>
        /// <value>
        /// The user infos.
        /// </value>
        public DbSet<UserInfo> UserInfos { get; set; } = null!;

        /// <summary>
        /// Gets or sets the massages.
        /// </summary>
        /// <value>
        /// The massages.
        /// </value>
        public DbSet<Massage> Massages { get; set; } = null!;

        /// <inheritdoc/>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Importify;Integrated Security=True");
        }
    }
}
