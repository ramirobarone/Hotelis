using System.ComponentModel.DataAnnotations;

namespace Application.Models.Options
{
    public class JwtOptions
    {
        public const string JWTOPTIONS = "JwtOptions";
        [Required]
        public string? Key { get; set; }
        [Required]
        public int TokenDuration { get; set; }
        [Required]
        public string? Authority { get; set; }
        [Required]
        public string? Audience { get; set; }
    }
}