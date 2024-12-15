using Application.Interfaces;
using Application.Models;
using Infrastructure.Models;
using Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace Application.Services.HotelServices
{
    public class HotelServiceQuery(IRepository<Hotel> repositoryHotel,
                                   ILogger<HotelServiceQuery> logger) : IServiceGeneric<HotelDto>, IServiceSearchByKeyword<HotelDto>
    {

        public async Task<HotelDto> Create(HotelDto entity)
        {
            EntityEntry<Hotel>? _hotel = await repositoryHotel.CreateAsync(entity);

            return _hotel.Entity;
        }

        public async Task Delete(int id)
        {
            await repositoryHotel.DeleteAsync(id);
        }

        public async Task<IEnumerable<HotelDto>> GetAllById(int id)
        {
            logger.LogInformation("MethodName: {GetAllById} - Parameter: {entity}", nameof(GetAllById), id);

            var resultQuery = await repositoryHotel.GetAllByIdAsync(x => x.Id == id);

            logger.LogInformation("MethodName: {GetAllById} - result: {entity}", nameof(GetAllById), System.Text.Json.JsonSerializer.Serialize(resultQuery));

            List<HotelDto> resultList = new ();

            foreach (var result in resultQuery)
            {
                resultList.Add(result);
            }
            return resultList;
        }

        public async Task<HotelDto> GetById(int id)
        {
            var _hotel = await repositoryHotel.GetByIdAsync(x => x.Id == id, y => y.Include(x => x.AddressHotel));

            if (_hotel is null)
                return await Task.FromResult<HotelDto>(result: new());

            return _hotel;
        }

        public async Task<IEnumerable<HotelDto>> SearchByKeyword(string keyword)
        {
            if (string.IsNullOrEmpty(keyword))
                throw new ArgumentNullException(nameof(keyword));

            try
            {
                IEnumerable<Hotel> resultHotels = await repositoryHotel
                    .GetAllByIdAsync(where: x => x.MetaDescription.Contains(keyword), y => y.Include(x => x.AddressHotel)
                    .Include(x => x.HotelPictures));

                IList<HotelDto> hoteles = new List<HotelDto>();

                foreach (var hotel in resultHotels)
                {
                    hoteles.Add(hotel);
                }

                return hoteles;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                throw;
            }
        }

        public async Task Update(HotelDto entity)
        {
            ArgumentNullException.ThrowIfNull(entity);

            await repositoryHotel.UpdateAsync(entity);
        }
    }
}