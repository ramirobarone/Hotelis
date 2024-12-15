using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Models
{
    public class HotelPicture
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? Path { get; set; }
    }
}
