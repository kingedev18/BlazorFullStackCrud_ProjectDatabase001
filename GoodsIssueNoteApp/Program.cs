using GoodsIssueNoteApp.Services.GoodsService;
using GoodsIssueNoteApp.Components;
using GoodsIssueNoteApp.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Read the base URL from the configuration
var apiBaseUrl = builder.Configuration.GetValue<string>("ApiBaseUrl");

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

// Configure HttpClient with the base address
builder.Services.AddHttpClient<IGoodsService, GoodsService>(client =>
{
    client.BaseAddress = new Uri(apiBaseUrl);
});

// Project Database
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Register Project services
builder.Services.AddScoped<IGoodsService, GoodsService>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
