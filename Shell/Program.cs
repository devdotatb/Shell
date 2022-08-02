using Blazored.SessionStorage;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Shell.Data;
using Shell.Model;
using Shell.Service;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddScoped<WeatherForecastService>();
builder.Services.AddScoped<IMyService, MyService>();
builder.Services.AddScoped<IclsDefault, clsDefault>();
builder.Services.AddBlazoredSessionStorage();
/*builder.Services.AddDbContext<SHELLREGContext>(options =>
{
    options.UseSqlServer("Server=.\\sqlexpress;Integrated Security=SSPI;Initial Catalog=SHELL-REG;");
    options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
});*/
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
