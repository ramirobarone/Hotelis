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
    }
}