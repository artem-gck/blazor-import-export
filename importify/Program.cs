using Importify.Access;
using Importify.Access.Context;
using Importify.Access.SQLServer;
using Importify.Service;
using Importify.Service.Logic;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ImportifyContext>(opt =>
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddTransient<IBasicUsing, BasicUsing>();
builder.Services.AddTransient<IPlotUsing, PlotUsing>();
builder.Services.AddTransient<IBasicAccess, BasicAccess>();
builder.Services.AddTransient<IPlotAccess, PlotAccess>();

builder.Services.AddMvc();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseStatusCodePages();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();

app.MapControllers();

app.Run();
