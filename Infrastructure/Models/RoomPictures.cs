using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Models
{
    public class RoomPicture
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? Name { get; set; }
    }
}