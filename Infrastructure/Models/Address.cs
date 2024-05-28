namespace Infrastructure.Models
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

        public virtual City City { get; set; }

    }
}