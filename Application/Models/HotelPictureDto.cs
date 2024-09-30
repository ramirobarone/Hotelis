using Infrastructure.Models;

namespace Application.Models
{
    public class HotelPictureDto
    {
        public HotelPictureDto(int Id, string Path)
        {
            this.Id = Id;
            this.Path = Path;
        }
        public int Id { get; init; }
        public string Path { get; init; }

        public static implicit operator HotelPictureDto(HotelPicture hotel)
        {
            return new HotelPictureDto(hotel.Id, hotel.Path);
        }

    }
}
