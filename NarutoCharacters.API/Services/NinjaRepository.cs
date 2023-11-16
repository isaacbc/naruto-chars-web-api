using Microsoft.EntityFrameworkCore;
using NarutoCharacters.API.DbContexts;
using NarutoCharacters.API.Entities;

namespace NarutoCharacters.API.Services
{
    public class NinjaRepository : INinjaRepository
    {
        private readonly NinjaContext _context;

        public NinjaRepository(NinjaContext context)
        {
            _context = context ?? throw new System.ArgumentNullException(nameof(context));
        }


        //NINJAS
        public async Task<bool> NinjaExistsAsync(int ninjaId)
        {
            return await _context.Ninjas.AnyAsync(c => c.Id == ninjaId);
        }
        public async Task<IEnumerable<Ninja>> GetNinjasAsync()
        {
            return await _context.Ninjas.OrderBy(c => c.Name).ToListAsync();
        }
        public async Task<Ninja?> GetNinjaAsync(int ninjaId, bool includeJutsus)
        {
            if (includeJutsus)
            {
                return await _context.Ninjas.Include(c => c.Jutsus).Where(c => c.Id == ninjaId).FirstOrDefaultAsync();

            }
            return await _context.Ninjas.Where(c => c.Id == ninjaId).FirstOrDefaultAsync();
        }
        public void AddNinja(Ninja ninja)
        {
            if (ninja != null)
            {
                _context.Ninjas.Add(ninja);
            }
        }
        public void DeleteNinja(Ninja ninja)
        {
            _context.Ninjas.Remove(ninja);
        }

        //JUTSUS
        public async Task<Jutsu?> GetJutsuAsync(int ninjaId, int jutsuId)
        {
            return await _context.Jutsus.Where(c => c.NinjaId == ninjaId && c.Id == jutsuId).FirstOrDefaultAsync();
        }
        public async Task<IEnumerable<Jutsu>> GetJutsusAsync(int ninjaId)
        {
            return await _context.Jutsus.Where(c => c.NinjaId == ninjaId).ToListAsync();
        }
        public async Task AddJutsuToNinjaAsync(int ninjaId, Jutsu jutsu)
        {
            var ninja = await GetNinjaAsync(ninjaId, false);
            if (ninja != null)
            {
                ninja.Jutsus.Add(jutsu);
            }
        }
        public void DeleteJutsu(Jutsu jutsu)
        {
            _context.Jutsus.Remove(jutsu);
        }

        //GENERAL
        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() >= 0;
        }

    }
}
