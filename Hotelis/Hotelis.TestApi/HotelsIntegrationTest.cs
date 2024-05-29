using Hotelis.TestApi.ControllersTestConfig;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;
using System.Net.Http.Json;

namespace Hotelis.TestApi
{
    public class HotelsIntegrationTest : WebApplitacionConfig
    {

        public HotelsIntegrationTest(WebApplicationFactory<Microsoft.VisualStudio.TestPlatform.TestHost.Program> webApplicationFactory) : base(webApplicationFactory)
        {

        }

        [Fact]
        public async void HotelGetById_Test_OkResult()
        {
            var result = await _httpClient.GetFromJsonAsync<Models.Hotel>("/GetHotels");

            Assert.NotNull(result);
        }
    }
}