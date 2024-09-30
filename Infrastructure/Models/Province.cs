using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Models
{
    public class Province
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int Id { get; set; }
        public string Name { get; set; }
        public Country Country {get;set;}
    }
}