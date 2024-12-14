using Application.Models.Extensions;
using Infrastructure.Models;

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
        public IEnumerable<HotelPictureDto>? Pictures { get; set; }

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
                Pictures = hotel?.HotelPictures?.ConvertToHotelPictureDto() ?? Enumerable.Empty<HotelPictureDto>(),

                AddressHotel = new Models.Address()
                {
                    Id = hotel?.AddressHotel.Id ?? 0,
                    IdCity = hotel?.AddressHotel.IdCity ?? 0,
                    Latitud = hotel?.AddressHotel?.Latitud ?? string.Empty,
                    Longitud = hotel?.AddressHotel?.Longitud ?? string.Empty,
                    Number = hotel?.AddressHotel?.Number ?? string.Empty,
                    PostalCode = hotel?.AddressHotel?.PostalCode ?? string.Empty,
                    Street = hotel?.AddressHotel?.Street ?? string.Empty

                }
            };
        }

        public static implicit operator Hotel(HotelDto hotel)
        {
            return new Hotel()
            {
                Id = hotel.Id,
                CodeArea = hotel.CodeArea,
                Description = hotel.Description ?? string.Empty,
                Email = hotel.Email ?? string.Empty,
                MetaDescription = hotel.MetaDescription ?? string.Empty,
                Name = hotel.Name ?? string.Empty,
                PhoneNumber = hotel.PhoneNumber,
                AddressHotel = new Address()
                {
                    Id = hotel.AddressHotel?.Id ?? 0,
                    IdCity = hotel.AddressHotel?.IdCity ?? 0,
                    Latitud = hotel.AddressHotel?.Latitud ?? string.Empty,
                    Longitud = hotel.AddressHotel?.Longitud ?? string.Empty,
                    Number = hotel.AddressHotel?.Number ?? string.Empty,
                    PostalCode = hotel.AddressHotel?.PostalCode ?? string.Empty,
                    Street = hotel.AddressHotel?.Street ?? string.Empty

                }
            };
        }
    }
}