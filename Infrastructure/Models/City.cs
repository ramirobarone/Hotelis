using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Models
{
    public class City
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? Name { get; set; }
        public virtual Province? Province{get;set;}
    }
}