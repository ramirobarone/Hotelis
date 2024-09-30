using Application.Interfaces;
using Application.Models;
using Application.Models.Booking.Available;
using Application.Services.Rooms;
using Microsoft.AspNetCore.Mvc;

namespace ClientApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoomController(IServiceGeneric<RoomDto> serviceRoom) : ControllerBase
    {

        [HttpGet]
        [Route(nameof(GetRoomById))]
        public async Task<IActionResult> GetRoomById(int idHotel)
        {
            if (idHotel == 0)
                return await Task.FromResult<IActionResult>(NoContent());

            IEnumerable<RoomDto> rooms = await serviceRoom.GetAllById(idHotel);

            if (rooms.Any())
                return Ok(rooms);

            return await Task.FromResult<IActionResult>(NoContent());
        }

        [HttpGet]
        public async Task<IActionResult> GetTimes()
        {

            var result = await ((ITimeRoom)serviceRoom).GetTimesAsync();

            if (!result.Any())
                return NoContent();

            return Ok(result);
        }
    }
}
