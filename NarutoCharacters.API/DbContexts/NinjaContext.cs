using Microsoft.EntityFrameworkCore;
using NarutoCharacters.API.Entities;

namespace NarutoCharacters.API.DbContexts
{
    public class NinjaContext: DbContext
    {

        public NinjaContext(DbContextOptions<NinjaContext> options)
            : base(options)
        {
        }

        public DbSet<Ninja> Ninjas { get; set; } = null!;
        public DbSet<Jutsu> Jutsus { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ninja>().HasData(
                new Ninja("Naruto Uzumaki")
                {
                    Id = 1,
                    Description = "The main protagonist of the series."
                },
                new Ninja("Sasuke Uchiha")
                {
                    Id = 2,
                    Description = "Naruto's rival and a skilled ninja."
                },
                new Ninja("Sakura Haruno")
                {
                    Id = 3,
                    Description = "A member of Team 7."
                });
            modelBuilder.Entity<Jutsu>().HasData(
                new Jutsu("Rasengan")
                {
                    Id = 1,
                    NinjaId = 1,
                    Description = "A spinning ball of chakra formed and held in the palm of the user's hand."
                },
                new Jutsu("Shadow Clone Jutsu")
                {
                    Id = 2,
                    NinjaId = 1,
                    Description = "A jutsu that creates an identical copy of the user."
                },
                new Jutsu("Sage Mode")
                {
                    Id = 3,
                    NinjaId = 1,
                    Description = "Enhances the user's physical abilities."
                },
                new Jutsu("Chidori")
                {
                    Id = 4,
                    NinjaId = 2,
                    Description = "A high concentration of lightning chakra in the user's hand."
                },
                new Jutsu("Sharingan")
                {
                    Id = 5,
                    NinjaId = 2,
                    Description = "A special eye technique granting advanced visual capabilities."
                },
                new Jutsu("Medical Ninjutsu")
                {
                    Id = 6,
                    NinjaId = 3,
                    Description = "A jutsu that heals injuries."
                });
            base.OnModelCreating(modelBuilder);
        }
    }
}
