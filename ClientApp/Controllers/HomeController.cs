using Microsoft.AspNetCore.Mvc;
using Models;
using Models.Interfaces;

namespace ClientApp.Controllers
{
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IServiceGeneric<Hotel> hotelService;

        public HomeController(IServiceGeneric<Models.Hotel> hotelService)
        {
            this.hotelService = hotelService;
        }

        [HttpGet(nameof(GetHotels))]
        public async Task<IActionResult> GetHotels(int id)
        {

            if (id == 0)
                return NoContent();


            return Ok(await hotelService.GetById(id));
        }
    }
}