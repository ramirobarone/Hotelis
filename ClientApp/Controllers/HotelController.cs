using Application.Interfaces;
using Application.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ClientApp.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class HotelController(IServiceGeneric<HotelDto> serviceHotel, IServiceBySearchKey<HotelDto> serviceBySearchKey, ILogger<HotelController> logger) : ControllerBase
    {
        [HttpGet(nameof(GetHotels))]
        public async Task<IActionResult> GetHotels(string searchKey)
        {
            if (string.IsNullOrEmpty(searchKey))
                return NoContent();

            return Ok(await serviceBySearchKey.GetBySearchKeyword(searchKey));
        }

        [HttpGet(nameof(GetHotel))]
        public async Task<IActionResult> GetHotel([FromQuery] int idHotel)
        {
            logger.LogInformation("Name {GetHotel} IdHotel {idHotel}", nameof(GetHotel), idHotel);

            if (idHotel == null)
                return NoContent();

            HotelDto _hotelDto = await serviceHotel.GetById(idHotel);

            logger.LogInformation("Service Name: {GetHotel} - Result: {_hotelDto}", nameof(serviceHotel.GetById), System.Text.Json.JsonSerializer.Serialize(_hotelDto));

            if (_hotelDto == null)
                return NoContent();

            return Ok(_hotelDto);
        }
        [ProducesResponseType<StatusCodeResult>((int)HttpStatusCode.Created)]
        [HttpPost(nameof(CreateHotel))]
        public async Task<IActionResult> CreateHotel(HotelDto hotelDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            await serviceHotel.Create(hotelDto);
            return Created();
        }
        [HttpPut(nameof(UpdateHotel))]
        public async Task<IActionResult> UpdateHotel(HotelDto hotelDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            await serviceHotel.Update(hotelDto);
            return Ok();
        }
        [HttpDelete(nameof(DeleteHotel))]
        public async Task<IActionResult> DeleteHotel(int id)
        {
            await serviceHotel.Delete(id);

            return Accepted();
        }

    }
}