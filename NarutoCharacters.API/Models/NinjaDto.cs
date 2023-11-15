namespace NarutoCharacters.API.Models
{
    public class NinjaDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public ICollection<JutsuDto> Jutsus { get; set; } = new List<JutsuDto>();
        public int NumberOfJutsus { get { return Jutsus.Count; } }
    }
}
