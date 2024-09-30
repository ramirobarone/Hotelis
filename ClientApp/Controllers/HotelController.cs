using Application.Interfaces;
using Application.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ClientApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HotelController(IServiceGeneric<HotelDto> serviceHotel, IServiceSearchByKeyword<HotelDto> serviceBySearchKey, ILogger<HotelController> logger) : ControllerBase
    {
        [HttpGet(nameof(GetHotels))]
        public async Task<IActionResult> GetHotels(string searchKey)
        {
            logger.LogInformation("NameMethod {nameof(GetHotels)} - searchKey: {searchKey}", nameof(GetHotels), searchKey);

            if (string.IsNullOrEmpty(searchKey))
                return NoContent();

            var resultHotels = await serviceBySearchKey.SearchByKeyword(searchKey);
            logger.LogInformation("NameMethod {nameof(GetHotels)} - ResultSearchKey: {resultHotels}", nameof(GetHotels), System.Text.Json.JsonSerializer.Serialize(resultHotels));

            return Ok(resultHotels);
        }

        [HttpGet(nameof(GetHotel))]
        public async Task<IActionResult> GetHotel([FromQuery] int idHotel)
        {
            logger.LogInformation("NameMethod {GetHotel} IdHotel {idHotel}", nameof(GetHotel), idHotel);

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