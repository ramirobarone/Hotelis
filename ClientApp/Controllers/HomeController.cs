using Microsoft.AspNetCore.Mvc;

namespace ClientApp.Controllers
{
    [ApiController]
    public class HomeController : ControllerBase
    {

        [HttpGet(nameof(GetHotels))]
        public async Task<IActionResult> GetHotels(string search)
        {
            return await Task.FromResult(Ok());
        }
    }
}