using Application.Models.Booking;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Hotelis.TestApi.ControllersTestConfig
{
    public class WebApplitacionConfig : IClassFixture<WebApplicationFactory<Program>>
    {
        protected readonly HttpClient _httpClient;
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
    public class BookingsControllerTest : WebApplitacionConfig
    {
        public BookingsControllerTest(WebApplicationFactory<Program> webApplication) : base(webApplication)
        {

        }

        [Fact]
        public async void CreateBookingOk()
        {
            BookingInputDto booking = new BookingInputDto() { Date = DateTime.Now, IdRoom = 1, CheckInTimeId=1 };

            var json = new StringContent(System.Text.Json.JsonSerializer.Serialize(booking), System.Text.Encoding.UTF8, "application/json");

            var result = await _httpClient.PostAsync("CreateBooking", json);

            Assert.True(result.IsSuccessStatusCode);
        }
    }
}
