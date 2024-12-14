using Infrastructure.Models;

namespace Application.Models.Extensions
{
    public static class ConvertToIEnumerable
    {
        public static IEnumerable<HotelPictureDto> ConvertToHotelPictureDto(this ICollection<HotelPicture> images)
        {
            List<HotelPictureDto> hotelPictureDtos = new ();

            foreach (HotelPicture image in images)
            {
                hotelPictureDtos.Add(new HotelPictureDto(image.Id, image.Path));
            }
            return hotelPictureDtos;
        }
    }
}
