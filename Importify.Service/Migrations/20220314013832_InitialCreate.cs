using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Importify.Service.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    CountryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Area = table.Column<double>(type: "float", nullable: true),
                    Population = table.Column<long>(type: "bigint", nullable: true),
                    Gdp = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.CountryId);
                });

            migrationBuilder.CreateTable(
                name: "Years",
                columns: table => new
                {
                    YearId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Years", x => x.YearId);
                });

            migrationBuilder.CreateTable(
                name: "CategoryExports",
                columns: table => new
                {
                    CategoryExportId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CountryId = table.Column<int>(type: "int", nullable: true),
                    YearId = table.Column<int>(type: "int", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryExports", x => x.CategoryExportId);
                    table.ForeignKey(
                        name: "FK_CategoryExports_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId");
                    table.ForeignKey(
                        name: "FK_CategoryExports_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "CountryId");
                    table.ForeignKey(
                        name: "FK_CategoryExports_Years_YearId",
                        column: x => x.YearId,
                        principalTable: "Years",
                        principalColumn: "YearId");
                });

            migrationBuilder.CreateTable(
                name: "CategoryImports",
                columns: table => new
                {
                    CategoryImportId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CountryId = table.Column<int>(type: "int", nullable: true),
                    YearId = table.Column<int>(type: "int", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryImports", x => x.CategoryImportId);
                    table.ForeignKey(
                        name: "FK_CategoryImports_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId");
                    table.ForeignKey(
                        name: "FK_CategoryImports_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "CountryId");
                    table.ForeignKey(
                        name: "FK_CategoryImports_Years_YearId",
                        column: x => x.YearId,
                        principalTable: "Years",
                        principalColumn: "YearId");
                });

            migrationBuilder.CreateTable(
                name: "CommonExports",
                columns: table => new
                {
                    CommonExportId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CountryId = table.Column<int>(type: "int", nullable: true),
                    YearId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommonExports", x => x.CommonExportId);
                    table.ForeignKey(
                        name: "FK_CommonExports_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "CountryId");
                    table.ForeignKey(
                        name: "FK_CommonExports_Years_YearId",
                        column: x => x.YearId,
                        principalTable: "Years",
                        principalColumn: "YearId");
                });

            migrationBuilder.CreateTable(
                name: "CommonImports",
                columns: table => new
                {
                    CommonImportId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CountryId = table.Column<int>(type: "int", nullable: true),
                    YearId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommonImports", x => x.CommonImportId);
                    table.ForeignKey(
                        name: "FK_CommonImports_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "CountryId");
                    table.ForeignKey(
                        name: "FK_CommonImports_Years_YearId",
                        column: x => x.YearId,
                        principalTable: "Years",
                        principalColumn: "YearId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategoryExports_CategoryId",
                table: "CategoryExports",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryExports_CountryId",
                table: "CategoryExports",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryExports_YearId",
                table: "CategoryExports",
                column: "YearId");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryImports_CategoryId",
                table: "CategoryImports",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryImports_CountryId",
                table: "CategoryImports",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryImports_YearId",
                table: "CategoryImports",
                column: "YearId");

            migrationBuilder.CreateIndex(
                name: "IX_CommonExports_CountryId",
                table: "CommonExports",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_CommonExports_YearId",
                table: "CommonExports",
                column: "YearId");

            migrationBuilder.CreateIndex(
                name: "IX_CommonImports_CountryId",
                table: "CommonImports",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_CommonImports_YearId",
                table: "CommonImports",
                column: "YearId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoryExports");

            migrationBuilder.DropTable(
                name: "CategoryImports");

            migrationBuilder.DropTable(
                name: "CommonExports");

            migrationBuilder.DropTable(
                name: "CommonImports");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "Years");
        }
    }
}
