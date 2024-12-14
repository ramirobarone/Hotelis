using Infrastructure.Models;

namespace Application.Models
{
    public class RoomDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int BedNumbers { get; set; }
        public bool AvialableNow { get; set; }
        public CostDto? Cost { get; set; }
        public IEnumerable<RoomPictures>? RoomPictures { get; set; }

        public static explicit operator RoomDto(Room room)
        {
            return new RoomDto()
            {
                AvialableNow = room.AvialableNow,
                Id = room.Id,
                Name = room.Name,
                Description = room.Description,
                BedNumbers = room.BedNumbers,
                RoomPictures = room.RoomPictures.Select(p => new RoomPictures() { Id = p.Id, Path= p.Name }).ToList(),
                Cost= room.Cost
            };
        }
    }
}