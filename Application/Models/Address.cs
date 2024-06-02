namespace Application.Models
{
    public class Address
    {
        public int Id { get; set; }
        public int IdHotel { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string PostalCode { get; set; }
        public string Latitud { get; set; }
        public string Longitud { get; set; }
        public int IdCity { get; set; }

        public static implicit operator Address(Infrastructure.Models.Address address)
        {
            return new Address()
            {
                Id = address.Id,
                IdCity = address.IdCity,
                Latitud = address.Latitud,
                Longitud = address.Longitud,
                Number = address.Number,
                PostalCode = address.PostalCode,
                Street = address.Street
            };
        }
        public static implicit operator Infrastructure.Models.Address(Address address)
        {
            return new Infrastructure.Models.Address()
            {
                Id = address.Id,
                IdCity = address.IdCity,
                Latitud = address.Latitud,
                Longitud = address.Longitud,
                Number = address.Number,
                PostalCode = address.PostalCode,
                Street = address.Street
            };
        }

    }
}