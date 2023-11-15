using System.ComponentModel.DataAnnotations;

namespace NarutoCharacters.API.Models
{
    public class JutsuForCreationDto
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;
        [Required]
        [MaxLength(200)]
        public string Description { get; set; } = string.Empty;
    }
}
