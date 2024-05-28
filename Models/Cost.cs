namespace Models
{
    public class Cost
    {
        public int Id { get; set; }
        public int IdRoom { get; set; }
        public decimal CostPerHour { get; set; }
        public int Hour { get; set; }
    }
}