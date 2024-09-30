using Application.Interfaces;
using Application.Models;
using Infrastructure.Models;
using Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Application.Services.HotelServices
{
    public class HotelServiceQuery(IRepository<Hotel> repositoryHotel,
                                   IRepository<HotelPicture> repositoryPicture,
                                   ILogger<HotelServiceQuery> logger) : IServiceGeneric<HotelDto>, IServiceSearchByKeyword<HotelDto>
    {

        public async Task<HotelDto> Create(HotelDto entity)
        {
           var _hotel= await repositoryHotel.CreateAsync(entity);

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

            List<HotelDto> resultList = new List<HotelDto>();

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
                return await Task.FromResult<HotelDto>(null);

            return _hotel;
        }

        public async Task<IEnumerable<HotelDto>> SearchByKeyword(string keyword)
        {
            IEnumerable<Hotel> resultHotels = await repositoryHotel
                .GetAllByIdAsync(x => x.MetaDescription.Contains(keyword), null, y => y.Include(x => x.AddressHotel)
                .Include(x => x.HotelPictures));

            IList<HotelDto> hoteles = new List<HotelDto>();

            foreach (var item in resultHotels)
            {
                hoteles.Add(item);
            }

            return hoteles;
        }

        public async Task Update(HotelDto entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));

            await repositoryHotel.UpdateAsync(entity);
        }
    }
}