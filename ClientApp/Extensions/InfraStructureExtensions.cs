using Application.Models.CheckOut;
using ClientApp.OptionsPattern;
using Infrastructure.Models;
using Infrastructure.Repository;
using Infrastructure.ServiceHttp;

namespace ClientApp.Extensions
{
    public static class InfraStructureExtensions
    {
        public static void AddInfraStructure(this WebApplicationBuilder webApplication)
        {
            webApplication.Services.AddScoped<IRepository<Hotel>, Repository<Hotel>>();
            webApplication.Services.AddScoped<IRepository<HotelPicture>, Repository<HotelPicture>>();
            webApplication.Services.AddScoped<IRepository<Room>, Repository<Room>>();
            webApplication.Services.AddScoped<IRepository<Cost>, Repository<Cost>>();
            webApplication.Services.AddScoped<IRepository<Bookings>, Repository<Bookings>>();
            webApplication.Services.AddScoped<IRepository<TimesAvailable>, Repository<TimesAvailable>>();
            webApplication.Services.AddScoped<IRepository<User>, Repository<User>>();

            webApplication.Services.AddHttpClient<IHttpClientService<RequestPayment, ResponsePayment>, HttpClientService<RequestPayment, ResponsePayment>>(httpClient =>
            {
                MercadoPagoOption mercadoPagoOption = new ();
                webApplication.Configuration.GetSection(MercadoPagoOption.MercadoPagoOptionName).Bind(mercadoPagoOption);
                httpClient.BaseAddress = new Uri(mercadoPagoOption.UrlBase ?? throw new Exception("Url Base mercado pago no existe"));
                httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", mercadoPagoOption.Token);
            });
        }
    }
}
