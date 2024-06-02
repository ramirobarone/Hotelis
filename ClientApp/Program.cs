using ClientApp.Controllers;
using ClientApp.Extensions;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Serilog;
using Serilog.AspNetCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Host.UseSerilog((configure, context) =>
{
    //context.WriteTo.File("Logs.txt", Serilog.Events.LogEventLevel.Information);
    context.WriteTo.Console(Serilog.Events.LogEventLevel.Information);

});

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<HotelisContext>(option => option.UseMySQL(builder.Configuration.GetValue<string>("ConnectionStrings:hotelis")));
builder.Services.AddHealthChecks();

builder.Logging.AddConsole();
builder.Logging.AddEventLog();
builder.Logging.AddJsonConsole();

builder.AddInfraStructure();
builder.AddApplication();

var app = builder.Build();



// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.MapHealthChecks("/health");
app.UseCors( cors =>
{
    cors.AllowAnyOrigin();
});


app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html"); ;

app.Run();
