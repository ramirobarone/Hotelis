using Application.HotelServices;
using Application.Interfaces;
using Application.Models;

namespace ClientApp.Extensions
{
    public static class ApplicationExtensions
    {
        public static void AddApplication(this WebApplicationBuilder app)
        {
            app.Services.AddScoped<IServiceGeneric<HotelDto>, HotelServiceQuery>();
            app.Services.AddScoped<IServiceBySearchKey<HotelDto>, HotelServiceQuery>();

        }
    }
}
