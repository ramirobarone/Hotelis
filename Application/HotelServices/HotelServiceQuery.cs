using Models.Interfaces;
using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace Application.HotelServices
{
    public class HotelServiceQuery : IServiceGeneric<Models.Hotel>
    {
        private readonly IRepository<Infrastructure.Models.Hotel> repository;

        public HotelServiceQuery(IRepository<Infrastructure.Models.Hotel> repository)
        {
            this.repository = repository;
        }

        public Task Create(Models.Hotel entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Models.Hotel>> GetallById(Models.Hotel entity)
        {
            throw new NotImplementedException();
        }

        public async Task<Models.Hotel> GetById(int id)
        {
            var response = await repository.GetByIdAsync(x => x.Id == id);

            if (response is null)
                return await Task.FromResult<Models.Hotel>(new Models.Hotel());

            return new Models.Hotel()
            {
                Id = response.Id,
                CodeArea = response.CodeArea,
                Description = response.Description,
                Email = response.Email,
                MetaDescription = response.MetaDescription,
                Name = response.Name,
                PhoneNumber = response.PhoneNumber,
                AddressHotel = new Models.Address()
                {
                    Id = response.AddressHotel.Id,
                    IdCity = response.AddressHotel.Id,
                    Latitud = response.AddressHotel.Latitud,
                    Longitud = response.AddressHotel.Longitud,
                    Number = response.AddressHotel.Number,
                    PostalCode = response.AddressHotel.PostalCode,
                    Street = response.AddressHotel.Street

                }
            };
        }

        public Task Update(Models.Hotel entity)
        {
            throw new NotImplementedException();
        }
    }
}
