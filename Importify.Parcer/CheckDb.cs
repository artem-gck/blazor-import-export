using Importify.Access.Context;
using Importify.Access.Entities;
using System.Globalization;

namespace Parcer
{
    /// <summary>
    /// Class for working with data base.
    /// </summary>
    public static class CheckDb
    {
        /// <summary>
        /// Sets the countries.
        /// </summary>
        /// <param name="context">The context.</param>
        public static void SetCountries(ImportifyContext context)
        {
            var countries = new List<Country>()
            {
                new Country()
                {
                    Name = "Австралия",
                    Area = 7692024,
                    Population = 25694393,
                    Gdp = 1.346m
                },
                new Country()
                {
                    Name = "Австрия",
                    Area = 83879,
                    Population = 8923507,
                    Gdp = 0.521m
                },
                new Country()
                {
                    Name = "Бельгия",
                    Area = 30528,
                    Population = 11480534,
                    Gdp = 0.529m
                },
                new Country()
                {
                    Name = "Канада",
                    Area = 9984670,
                    Population = 38547000,
                    Gdp = 1.921m
                },
                new Country()
                {
                    Name = "Чехия",
                    Area = 78866,
                    Population = 10701777,
                    Gdp = 0.454m
                },
                new Country()
                {
                    Name = "Дания",
                    Area = 43094,
                    Population = 5822763,
                    Gdp = 0.346m
                },
                new Country()
                {
                    Name = "Финляндия",
                    Area = 338145,
                    Population = 5543659,
                    Gdp = 0.280m
                },
                new Country()
                {
                    Name = "Франция",
                    Area = 643801,
                    Population = 68084217,
                    Gdp = 2.954m
                },
                new Country()
                {
                    Name = "Германия",
                    Area = 357385,
                    Population = 83019200,
                    Gdp = 4.672m
                },
                new Country()
                {
                    Name = "Греция",
                    Area = 131957,
                    Population = 10741165,
                    Gdp = 0.210m
                }
            };

            Console.Write('.');
            context.Countries.AddRange(countries);
            context.SaveChanges();
        }

        /// <summary>
        /// Sets the common export.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="path">The path.</param>
        public static void SetCommonExport(ImportifyContext context, string path)
        {
            var countries = new Dictionary<string, string>();
            countries["AUS"] = "Австралия";
            countries["AUT"] = "Австрия";
            countries["BEL"] = "Бельгия";
            countries["CAN"] = "Канада";
            countries["CZE"] = "Чехия";
            countries["DNK"] = "Дания";
            countries["FIN"] = "Финляндия";
            countries["FRA"] = "Франция";
            countries["DEU"] = "Германия";
            countries["GRC"] = "Греция";

            Console.Write('.');
            var fileLines = File.ReadAllLines(path);

            foreach (var str in fileLines)
            {
                var commonExport = new CommonExport();

                var col = str.Split(',');

                commonExport.Value = decimal.Parse(col[6], CultureInfo.InvariantCulture);
                commonExport.Country = CheckDb.GetCountry(context, countries[col[0]]);
                commonExport.Year = CheckDb.GetYear(context, int.Parse(col[5]));

                context.CommonExports.Add(commonExport);
            }

            context.SaveChanges();
        }

        /// <summary>
        /// Sets the common import.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="path">The path.</param>
        public static void SetCommonImport(ImportifyContext context, string path)
        {
            var countries = new Dictionary<string, string>();
            countries["AUS"] = "Австралия";
            countries["AUT"] = "Австрия";
            countries["BEL"] = "Бельгия";
            countries["CAN"] = "Канада";
            countries["CZE"] = "Чехия";
            countries["DNK"] = "Дания";
            countries["FIN"] = "Финляндия";
            countries["FRA"] = "Франция";
            countries["DEU"] = "Германия";
            countries["GRC"] = "Греция";

            Console.Write('.');
            var fileLines = File.ReadAllLines(path);

            foreach (var str in fileLines)
            {
                var commonImport = new CommonImport();

                var col = str.Split(',');

                commonImport.Value = decimal.Parse(col[6], CultureInfo.InvariantCulture);
                commonImport.Country = CheckDb.GetCountry(context, countries[col[0]]);
                commonImport.Year = CheckDb.GetYear(context, int.Parse(col[5]));

                context.CommonImports.Add(commonImport);
            }

            context.SaveChanges();
        }

        /// <summary>
        /// Sets the category import.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="category">The category.</param>
        /// <param name="path">The path.</param>
        public static void SetCategoryImport(ImportifyContext context, string category, string path)
        {
            var countries = new Dictionary<string, string>();
            countries["Australia"] = "Австралия";
            countries["Austria"] = "Австрия";
            countries["Belgium"] = "Бельгия";
            countries["Canada"] = "Канада";
            countries["Czech Republic"] = "Чехия";
            countries["Denmark"] = "Дания";
            countries["Finland"] = "Финляндия";
            countries["France"] = "Франция";
            countries["Germany"] = "Германия";
            countries["Greece"] = "Греция";

            Console.Write('.');
            var fileLines = File.ReadAllLines(path);

            foreach (var str in fileLines)
            {
                var col = str.Split(',');
                Country country;

                try
                {
                    country = CheckDb.GetCountry(context, countries[col[1]]);
                }
                catch
                {
                    continue;
                }

                var categoryDb = CheckDb.GetCategory(context, category);

                for (var i = 0; i < 11; i++)
                {
                    var categoryImport = new CategoryImport();

                    var year = 2009 + i;

                    categoryImport.Value = decimal.Parse(col[i + 5], CultureInfo.InvariantCulture);
                    categoryImport.Country = country;
                    categoryImport.Year = CheckDb.GetYear(context, year);
                    categoryImport.Category = categoryDb;

                    context.CategoryImports.Add(categoryImport);
                }
            }

            context.SaveChanges();
        }

        /// <summary>
        /// Sets the category export.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="category">The category.</param>
        /// <param name="path">The path.</param>
        public static void SetCategoryExport(ImportifyContext context, string category, string path)
        {
            var countries = new Dictionary<string, string>();
            countries["Australia"] = "Австралия";
            countries["Austria"] = "Австрия";
            countries["Belgium"] = "Бельгия";
            countries["Canada"] = "Канада";
            countries["Czech Republic"] = "Чехия";
            countries["Denmark"] = "Дания";
            countries["Finland"] = "Финляндия";
            countries["France"] = "Франция";
            countries["Germany"] = "Германия";
            countries["Greece"] = "Греция";

            Console.Write('.');
            var fileLines = File.ReadAllLines(path);

            foreach (var str in fileLines)
            {
                var col = str.Split(',');
                Country country;

                try
                {
                    country = CheckDb.GetCountry(context, countries[col[1]]);
                }
                catch
                {
                    continue;
                }

                var categoryDb = CheckDb.GetCategory(context, category);

                for (var i = 0; i < 11; i++)
                {
                    var categoryExport = new CategoryExport();

                    var year = 2009 + i;

                    categoryExport.Value = decimal.Parse(col[i + 5], CultureInfo.InvariantCulture);
                    categoryExport.Country = country;
                    categoryExport.Year = CheckDb.GetYear(context, year);
                    categoryExport.Category = categoryDb;

                    context.CategoryExports.Add(categoryExport);
                }
            }

            context.SaveChanges();
        }

        private static Year GetYear(ImportifyContext context, int year)
        {
            var yearDb = context.Years.FirstOrDefault(y => y.Value == year);

            if (yearDb is not null)
                return yearDb;
            else
            {
                yearDb = new Year();
                yearDb.Value = year;

                context.Years.Add(yearDb);
                context.SaveChanges();
                return yearDb;
            }
        }

        private static Country GetCountry(ImportifyContext context, string country)
        {
            var countryDb = context.Countries.FirstOrDefault(c => c.Name == country);

            if (countryDb is not null)
                return countryDb;
            else
            {
                countryDb = new Country();
                countryDb.Name = country;

                context.Countries.Add(countryDb);
                context.SaveChanges();
                return countryDb;
            }
        }

        private static Category GetCategory(ImportifyContext context, string category)
        {
            var categoryDb = context.Categories.FirstOrDefault(c => c.Name == category);

            if (categoryDb is not null)
                return categoryDb;
            else
            {
                categoryDb = new Category();
                categoryDb.Name = category;

                context.Categories.Add(categoryDb);
                context.SaveChanges();
                return categoryDb;
            }
        }
    }
}
