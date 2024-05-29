using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace Hotelis.TestApi.ControllersTestConfig
{
    public class WebApplitacionConfig : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly HttpClient _httpClient;
        public WebApplitacionConfig(WebApplicationFactory<Program> webApplication)
        {
            _httpClient = webApplication.CreateClient();
        }

        public class TestControllerHotels : WebApplitacionConfig
        {
            public TestControllerHotels(WebApplicationFactory<Program> webApplication) : base(webApplication)
            {

            }
            [Fact]
            public async void Get()
            {
                var result = await _httpClient.GetAsync("gethotels");
                Assert.NotNull(result);
            }
        }
    }
}
