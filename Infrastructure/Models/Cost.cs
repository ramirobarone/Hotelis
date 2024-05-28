namespace Infrastructure.Models
{
    public class Cost
    {
        public int Id { get; set; }
        public int IdRoom { get; set; }
        public decimal CostPerTime { get; set; }
        public int Hour { get; set; }
    }
}