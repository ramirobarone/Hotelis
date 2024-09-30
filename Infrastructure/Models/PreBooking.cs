namespace Infrastructure.Models
{
    public class PreBooking
    {
        public int Id { get; set; }
        public DateTime TimeToExpire { get; set; }
        public int IdRoom { get; set; }
        public string UserId { get; set; }
        public virtual User User { get; set; }
    }
}
