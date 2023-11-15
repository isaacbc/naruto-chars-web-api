using NarutoCharacters.API.Entities;

namespace NarutoCharacters.API.Services
{
    public interface INinjaRepository
    {

        //IQueryable<Ninja> GetNinjas();
        Task<IEnumerable<Ninja>> GetNinjasAsync();
        Task<Ninja?> GetNinjaAsync(int ninjaId, bool includeJutsus);
        Task<IEnumerable<Jutsu>> GetJutsusAsync(int ninjaId);
        Task<Jutsu?> GetJutsuAsync(int ninjaId, int jutsuId);
    }
}
