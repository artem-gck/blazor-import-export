using Importify.Service.Model.Context;
using Parcer;

var context = new ImportifyContext();

context.Database.EnsureDeleted();
context.Database.EnsureCreated();

CheckDb.SetCommonExport(context, "data/10years-export.csv");
CheckDb.SetCommonImport(context, "data/10years-import.csv");

CheckDb.SetCategoryImport(context, "Химикаты", "data/Import-chemicals.csv");
CheckDb.SetCategoryImport(context, "Потребительство", "data/Import-consumer.csv");
CheckDb.SetCategoryImport(context, "Питание", "data/Import-eat.csv");
CheckDb.SetCategoryImport(context, "Топливо", "data/Import-fuels.csv");
CheckDb.SetCategoryImport(context, "Стекло", "data/Import-glass.csv");
CheckDb.SetCategoryImport(context, "Металлы", "data/Import-metals.csv");
CheckDb.SetCategoryImport(context, "Пластик", "data/Import-plastic.csv");
CheckDb.SetCategoryImport(context, "Текстиль", "data/Import-textiles.csv");
CheckDb.SetCategoryImport(context, "Транспорт", "data/Import-transportation.csv");
CheckDb.SetCategoryImport(context, "Дерево", "data/Import-wood.csv");

CheckDb.SetCategoryExport(context, "Химикаты", "data/Export-chemicals.csv");
CheckDb.SetCategoryExport(context, "Потребительство", "data/Export-consumer.csv");
CheckDb.SetCategoryExport(context, "Питание", "data/Export-eat.csv");
CheckDb.SetCategoryExport(context, "Топливо", "data/Export-fuels.csv");
CheckDb.SetCategoryExport(context, "Стекло", "data/Export-glass.csv");
CheckDb.SetCategoryExport(context, "Металлы", "data/Export-metals.csv");
CheckDb.SetCategoryExport(context, "Пластик", "data/Export-plastic.csv");
CheckDb.SetCategoryExport(context, "Текстиль", "data/Export-textiles.csv");
CheckDb.SetCategoryExport(context, "Транспорт", "data/Export-transportation.csv");
CheckDb.SetCategoryExport(context, "Дерево", "data/Export-wood.csv");