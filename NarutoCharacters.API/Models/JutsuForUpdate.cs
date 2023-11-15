using System.ComponentModel.DataAnnotations;

namespace NarutoCharacters.API.Models
{
    public class JutsuForUpdateDto
    {
        [MaxLength(50)]
        public string? Name { get; set; }
        [MaxLength(200)]
        public string? Description { get; set; }
    }
}
