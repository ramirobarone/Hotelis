namespace Infrastructure.Models
{
    public class Room
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int BedNumbers { get; set; }
        public bool AvialableNow { get; set; }
        public ICollection< RoomPicture> RoomPictures { get; set; }
    }
}