namespace Infrastructure.Models
{
    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual Province Province{get;set;}
    }
}