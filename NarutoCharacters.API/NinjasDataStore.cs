using NarutoCharacters.API.Models;

namespace NarutoCharacters.API
{
    public class NinjasDataStore
    {
        public List<NinjaDto> Ninjas { get; set; }
        public static NinjasDataStore Current { get; } = new NinjasDataStore();

        public NinjasDataStore()
        {
            Ninjas = new List<NinjaDto>
            {
                new NinjaDto 
                { 
                    Id = 1, 
                    Name = "Naruto Uzumaki",
                    Description = "The main protagonist of the series.",
                    Jutsus = new List<JutsuDto>()
                    {
                        new JutsuDto()
                        {
                            Id = 1,
                            Name = "Rasengan",
                            Description = "A spinning ball of chakra formed and held in the palm of the user's hand."
                        },
                        new JutsuDto()
                        {
                            Id = 2,
                            Name = "Shadow Clone Jutsu",
                            Description = "A jutsu that creates an identical copy of the user."
                        },
                        new JutsuDto()
                        {
                            Id = 3,
                            Name = "Sage Mode",
                            Description = "Enhances the user's physical abilities."
                        }
                    }
                },
                new NinjaDto
                {
                    Id = 2,
                    Name = "Sasuke Uchiha",
                    Description = "Naruto's rival and a skilled ninja.",
                    Jutsus = new List<JutsuDto>()
                    {
                        new JutsuDto()
                        {
                            Id = 4,
                            Name = "Chidori",
                            Description = "A high concentration of lightning chakra in the user's hand."
                        },
                        new JutsuDto()
                        {
                            Id = 5,
                            Name = "Sharingan",
                            Description = "A special eye technique granting advanced visual capabilities."
                        }
                    }
                },
                new NinjaDto
                {
                    Id = 3,
                    Name = "Sakura Haruno",
                    Description = "A member of Team 7 with medical ninja skills.",
                    Jutsus = new List<JutsuDto>()
                    {
                        new JutsuDto()
                        {
                            Id = 6,
                            Name = "Medical Ninjutsu",
                            Description = "Healing techniques using chakra to mend injuries."
                        },
                        
                    }

                }
            };
        }
    }
}
