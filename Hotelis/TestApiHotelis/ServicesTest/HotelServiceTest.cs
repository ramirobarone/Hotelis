using Application.Interfaces;
using Application.Models;
using Microsoft.Extensions.DependencyInjection;

namespace TestApiHotelis.ServicesTest
{

    public class HotelServiceTest
    {
        [Fact]
        public async Task GetHotels_Ok()
        {
            //IServiceSearchByKeyword<HotelDto> serviceBySearchKey

            var services = new ServiceCollection();

            var serviceProvider = services.BuildServiceProvider();

            var service = serviceProvider.GetRequiredService<IServiceSearchByKeyword<HotelDto>>();

            var result = await service.SearchByKeyword("cordoba");

            Assert.All(result, item => Assert.Contains("cordoba", item.Name));
        }
    }
}
