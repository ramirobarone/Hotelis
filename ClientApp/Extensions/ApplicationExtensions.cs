using Application.HotelServices;
using Models.Interfaces;

namespace ClientApp.Extensions
{
    public static class ApplicationExtensions
    {
        public static void AddApplication(this WebApplicationBuilder app)
        {
            app.Services.AddScoped<IServiceGeneric<Models.Hotel>, HotelServiceQuery>();
        }
    }
}
