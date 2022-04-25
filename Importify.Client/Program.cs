using Blazored.LocalStorage;
using IgniteUI.Blazor.Controls;
using Importify.Client;
using Importify.Client.Service;
using Importify.Client.Service.Logic;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddTransient(typeof(IIgniteUIBlazor), typeof(IgniteUIBlazor));
builder.Services.AddTransient<IAuthService, AuthService>();
builder.Services.AddTransient<IBasicService, BasicService>();
builder.Services.AddTransient<IPlotService, PlotService>();
builder.Services.AddTransient<IExcelGenerator, ExcelGenerator>();
builder.Services.AddTransient<IMassageService, MassageService>();

builder.Services.AddHttpContextAccessor();
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddBlazoredLocalStorage(config =>
    config.JsonSerializerOptions.WriteIndented = true);

//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

await builder.Build().RunAsync();
