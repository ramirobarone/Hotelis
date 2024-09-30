using ClientApp.Extensions;
using Infrastructure.Context;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

string policyName = "ClientApp";

// Add services to the container.
builder.Host.UseSerilog((configure, context) =>
{
    //context.WriteTo.File("Logs.txt", Serilog.Events.LogEventLevel.Information);
    context.WriteTo.Console(Serilog.Events.LogEventLevel.Information);

});

builder.Services.AddControllersWithViews();
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddControllers().AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles); //TODO: ?????

builder.Services.AddDbContext<HotelisContext>(option => option.UseMySQL(builder.Configuration.GetValue<string>("ConnectionStrings:hotelis")));
builder.Services.AddHealthChecks();

builder.Logging.AddConsole();
builder.Logging.AddEventLog();
builder.Logging.AddJsonConsole();
builder.Services.AddCors(cors =>
{
    cors.AddPolicy(policyName, policy =>
    {
        policy.WithOrigins("https://localhost:44432", "http://localhost:44432").AllowAnyMethod().AllowAnyHeader();


    });

});

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
app.UseRouting();
app.UseCors(policyName);
app.UseStaticFiles();
app.MapHealthChecks("/health");
app.MapControllers();

//app.MapControllerRoute(
    //name: "default",
    //pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html");

app.Run();
