using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace Hotelis.TestApi.ControllersTestConfig
{
    public class WebApplitacionConfig : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _webApplication;
        protected readonly HttpClient _httpClient;
        public WebApplitacionConfig(WebApplicationFactory<Program> webApplication)
        {
            _webApplication = webApplication;
            _httpClient= _webApplication.CreateClient();
        }
    }
}
