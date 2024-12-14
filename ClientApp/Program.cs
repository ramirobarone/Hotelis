using ClientApp.Extensions;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Serilog;

public class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.AddServiceDefaults();

        string policyName = "ClientApp";

        // Add services to the container.
        builder.Host.UseSerilog((configure, context) =>
        {
            context.WriteTo.File(
                path: "Logs/log-.txt",
                rollingInterval: RollingInterval.Day,
                outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level}] {Message}{NewLine}{Exception}"
            );
            context.WriteTo.Console(Serilog.Events.LogEventLevel.Information);

        });


        builder.Services.AddControllersWithViews();
        builder.Services.AddHealthChecks();

        //builder.Services.AddDbContext<HotelisContext>(options => options.UseMySQL(builder.Configuration.GetConnectionString("hotelis") ?? throw new Exception()));
        builder.AddMySqlDbContext<HotelisContext>("hotelis");

        builder.Logging.AddConsole();
#if WINDOWS
        builder.Logging.AddEventLog();
#endif
        builder.Logging.AddJsonConsole();
        builder.Services.AddCors(cors =>
        {
            cors.AddPolicy(policyName, policy =>
            {
                policy.WithOrigins("https://localhost:44432", "http://localhost:44432").AllowAnyMethod().AllowAnyHeader();


            });

        });

        builder.Services.AddMemoryCache();
        builder.AddInfraStructure();
        builder.AddApplication();

        builder.AddRabbitMQClient("Aspire");

        builder.Services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "Hotelis", Version = "v1" });
            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Description = @"Type into the textbox: Bearer {your JWT token}.",
                Name = "Authorization",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.ApiKey,
                Scheme = "Bearer"
            });
            c.AddSecurityRequirement(new OpenApiSecurityRequirement() {
                   {
                       new OpenApiSecurityScheme {
                           Reference = new OpenApiReference {
                                   Type = ReferenceType.SecurityScheme,
                                       Id = "Bearer"
                               },
                               Scheme = "Bearer",
                               Name = "Bearer",
                               In = ParameterLocation.Header,

                       },
                       new List<string> ()
                   }
                               });
        });

        var app = builder.Build();

        app.MapDefaultEndpoints();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.

            app.UseHsts();

        }
        if (app.Environment.IsDevelopment())
        {
            using (var scope = app.Services.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<HotelisContext>();
                context.Database.EnsureCreated();
            }

        }

        app.UseSwagger();
        app.UseSwaggerUI();

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
    }
}