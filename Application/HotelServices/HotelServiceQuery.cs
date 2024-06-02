using Application.Interfaces;
using Application.Models;
using Infrastructure.Models;
using Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;

namespace Application.HotelServices
{
    public class HotelServiceQuery : IServiceGeneric<Models.HotelDto>, IServiceBySearchKey<HotelDto>
    {
        private readonly IRepository<Infrastructure.Models.Hotel> repository;

        public HotelServiceQuery(IRepository<Infrastructure.Models.Hotel> repository)
        {
            this.repository = repository;
        }

        public async Task Create(HotelDto entity)
        {
            await repository.CreateAsync(entity);
        }

        public async Task Delete(int id)
        {
            await repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<Models.HotelDto>> GetallById(Models.HotelDto entity)
        {
            var resultQuery = await repository.GetAllByIdAsync(x => x.Id == entity.Id);

            //return resultQuery.Cast<Models.HotelDto>();

            List<HotelDto> resultList = new List<HotelDto>();

            foreach (var result in resultQuery)
            {
                resultList.Add(result);
            }
            return resultList;
        }

        public async Task<Models.HotelDto> GetById(int id)
        {
            var _hotel = await repository.GetByIdAsync(x => x.Id == id, y => y.Include(x => x.AddressHotel));

            if (_hotel is null)
                return await Task.FromResult<HotelDto>(null);

            return _hotel;
        }

        public async Task<IEnumerable<HotelDto>> GetBySearchKeyword(string keyword)
        {
            IEnumerable<Hotel> resultHotels = await repository.GetAllByIdAsync(x => x.MetaDescription.Contains(keyword), null, y => y.Include(x => x.AddressHotel));

            IList<HotelDto> hoteles = new List<HotelDto>();
            foreach (var item in resultHotels)
            {
                hoteles.Add(item);
            }

            return hoteles;
        }

        public async Task Update(Models.HotelDto entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));

            await repository.UpdateAsync(entity);
        }
    }
}