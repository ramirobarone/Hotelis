using Application.Interfaces;
using Application.Models.Booking;
using Infrastructure.Models;
using Microsoft.AspNetCore.Mvc;

namespace ClientApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingsController(IBookings bookings, ILogger<BookingsController> logger) : ControllerBase
    {

        [HttpGet, Route(nameof(GetBookings))]

        public async Task<IActionResult> GetBookings(int _idRoom, string _date)
        {
            logger.LogInformation($"parameters query: {_idRoom} - {_date}");
            if (_idRoom <= 0 || string.IsNullOrEmpty(_date))
                return NoContent();

            return Ok(await bookings.GetSchedulesyRoom(_idRoom, _date));
        }

        [HttpPost]
        [Route(nameof(CreateBooking))]
        public async Task<IActionResult> CreateBooking(BookingInputDto _bookingInputDto)
        {
            logger.LogInformation("Service Cast to IServiceGeneric");
            var service = (IServiceGeneric<Bookings>)bookings;

            logger.LogInformation("Create booking");

            Bookings _booking = await service.Create(_bookingInputDto);

            logger.LogInformation("Created booking {0}", _bookingInputDto);

            return Created("/Payload", _bookingInputDto);
        }
        [HttpGet, Route(nameof(GetSchedulesByRoom))]
        public async Task<IActionResult> GetSchedulesByRoom(int idRoom,  string date)
        {
            if (idRoom <= 0)
                return NoContent();

            return Ok(await bookings.GetSchedulesyRoom(idRoom, date));
        }

        [HttpGet, Route(nameof(GetBookingsByUserGuid))]
        public async Task<IActionResult> GetBookingsByUserGuid(Guid userGuid)
        {
            if (userGuid == Guid.Empty)
                return NoContent();

            return Ok(await bookings.GetBookingsByUserGuidAsync(userGuid));
        }
    }
}