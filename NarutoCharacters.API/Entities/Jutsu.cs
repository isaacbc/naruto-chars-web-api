using NarutoCharacters.API.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NarutoCharacters.API.Entities
{
    public class Jutsu
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(200)]
        public string? Description { get; set; }

        [ForeignKey("NinjaId")]
        public int NinjaId { get; set; }
        public Ninja? Ninja { get; set; }

        public Jutsu(string name)
        {
            Name = name;
        }
    }
}
