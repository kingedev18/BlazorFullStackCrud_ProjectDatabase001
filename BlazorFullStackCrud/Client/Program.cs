global using BlazorFullStackCrud.Client.Services.SuperHeroService;
global using BlazorFullStackCrud.Shared;
global using BlazorFullStackCrud.Client.Services.GoodsService;
using BlazorFullStackCrud.Client;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<ISuperHeroService, SuperHeroService>();
builder.Services.AddScoped<IGoodsService, GoodsService>();

await builder.Build().RunAsync();
