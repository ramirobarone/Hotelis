
namespace Models
{
    public class Hotel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string MetaDescription { get; set; }
        public Address AddressHotel { get; set; }
        public string Email { get; set; }
        public int CodeArea { get; set; }
        public int PhoneNumber { get; set; }

        //public static implicit operator Hotel(Infrastructure.Models.Hotel hotel)
        //{
        //    return new Hotel()
        //    {
        //        Id = hotel.Id,
        //        Name = hotel.Name,
        //        Description = hotel.Description,
        //        MetaDescription = hotel.MetaDescription,
        //        AddressHotel = hotel.AddressHotel,
        //        Email = hotel.Email,
        //        PhoneNumber = hotel.PhoneNumber,
        //        CodeArea = hotel.CodeArea,
        //    };
        //}

    }
}