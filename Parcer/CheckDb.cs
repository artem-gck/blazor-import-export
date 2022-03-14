using Importify.Service.Model;
using Importify.Service.Model.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcer
{
    public static class CheckDb
    {
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
