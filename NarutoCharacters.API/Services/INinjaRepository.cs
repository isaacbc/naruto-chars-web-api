using NarutoCharacters.API.Entities;

namespace NarutoCharacters.API.Services
{
    public interface INinjaRepository
    {

        //NINJAS
        //IQueryable<Ninja> GetNinjas();
        Task<IEnumerable<Ninja>> GetNinjasAsync();
        Task<Ninja?> GetNinjaAsync(int ninjaId, bool includeJutsus);
        void AddNinja(Ninja ninja);
        void DeleteNinja(Ninja ninja);

        //JUTSUS
        Task<IEnumerable<Jutsu>> GetJutsusAsync(int ninjaId);
        Task<Jutsu?> GetJutsuAsync(int ninjaId, int jutsuId);
        Task<bool> NinjaExistsAsync(int ninjaId);
        Task AddJutsuToNinjaAsync(int ninjaId, Jutsu jutsu);
        void DeleteJutsu(Jutsu jutsu);

        //GENERAL
        Task<bool> SaveChangesAsync();
    }
}
