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

        public async Task<Jutsu?> GetJutsuAsync(int ninjaId, int jutsuId)
        {
            return await _context.Jutsus.Where(c => c.NinjaId == ninjaId && c.Id == jutsuId).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Jutsu>> GetJutsusAsync(int ninjaId)
        {
            return await _context.Jutsus.Where(c => c.NinjaId == ninjaId).ToListAsync();
        }

        public async Task<Ninja?> GetNinjaAsync(int ninjaId, bool includeJutsus)
        {
            if (includeJutsus)
            {
                return await _context.Ninjas.Include(c => c.Jutsus).Where(c => c.Id == ninjaId).FirstOrDefaultAsync();

            }
            return await _context.Ninjas.Where(c => c.Id == ninjaId).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Ninja>> GetNinjasAsync()
        {
            return await _context.Ninjas.OrderBy(c => c.Name).ToListAsync();
        }
    }
}
