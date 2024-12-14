using Infrastructure.Models;

namespace Application.Models
{
    public class HotelPictureDto( int  Id, string Path)
    {
        public int Id { get; } = Id;
        public string Path { get; } = Path;

        public static implicit operator HotelPictureDto(HotelPicture hotel)
        {
            return new HotelPictureDto(hotel.Id, hotel.Path);
        }
    }
}
