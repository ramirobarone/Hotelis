using Application.Models.Extensions;
using Infrastructure.Models;
using System.Runtime.CompilerServices;

namespace Application.Models
{
    public class HotelDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? MetaDescription { get; set; }
        public Address? AddressHotel { get; set; }
        public string? Email { get; set; }
        public int CodeArea { get; set; }
        public int PhoneNumber { get; set; }
        public IEnumerable<HotelPictureDto> Pictures { get; set; }



        public static implicit operator HotelDto(Hotel hotel)
        {

            return new Models.HotelDto()
            {
                Id = hotel.Id,
                CodeArea = hotel.CodeArea,
                Description = hotel.Description,
                Email = hotel.Email,
                MetaDescription = hotel.MetaDescription,
                Name = hotel.Name,
                PhoneNumber = hotel.PhoneNumber,
                Pictures = hotel?.HotelPictures?.ConvertToHotelPictureDto(),

                AddressHotel = new Models.Address()
                {
                    Id = hotel.AddressHotel.Id,
                    IdCity = hotel.AddressHotel.Id,
                    Latitud = hotel.AddressHotel.Latitud,
                    Longitud = hotel.AddressHotel.Longitud,
                    Number = hotel.AddressHotel.Number,
                    PostalCode = hotel.AddressHotel.PostalCode,
                    Street = hotel.AddressHotel.Street

                }
            };
        }

        public static implicit operator Hotel(HotelDto hotel)
        {
            return new Hotel()
            {
                Id = hotel.Id,
                CodeArea = hotel.CodeArea,
                Description = hotel.Description,
                Email = hotel.Email,
                MetaDescription = hotel.MetaDescription,
                Name = hotel.Name,
                PhoneNumber = hotel.PhoneNumber,
                AddressHotel = new Address()
                {
                    Id = hotel.AddressHotel.Id,
                    IdCity = hotel.AddressHotel.Id,
                    Latitud = hotel.AddressHotel.Latitud,
                    Longitud = hotel.AddressHotel.Longitud,
                    Number = hotel.AddressHotel.Number,
                    PostalCode = hotel.AddressHotel.PostalCode,
                    Street = hotel.AddressHotel.Street

                }
            };
        }
    }

}