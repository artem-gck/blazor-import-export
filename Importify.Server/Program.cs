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
builder.Services.AddTransient<IAuthUsing, AuthUsing>();
builder.Services.AddTransient<IPlotUsing, PlotUsing>();
builder.Services.AddTransient<ITokenUsing, TokenUsing>();
builder.Services.AddTransient<IMassageUsing, MassageUsing>();

builder.Services.AddTransient<IBasicAccess, BasicAccess>();
builder.Services.AddTransient<IAuthAccess, AuthAccess>();
builder.Services.AddTransient<IPlotAccess, PlotAccess>();
builder.Services.AddTransient<IMassageAccess, MassageAccess>();

builder.Services.AddCors();

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

app.UseCors(options =>
            options.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader()
                   );

app.UseAuthorization();

app.MapControllers();

app.Run();
