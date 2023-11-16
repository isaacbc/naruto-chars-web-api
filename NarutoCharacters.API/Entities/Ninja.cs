﻿using NarutoCharacters.API.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NarutoCharacters.API.Entities
{
    public class Ninja
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(200)]
        public string? Description { get; set; }
        public ICollection<Jutsu> Jutsus { get; set; } = new List<Jutsu>();

        public Ninja(string name)
        {
            Name = name;
        }
    }
}
