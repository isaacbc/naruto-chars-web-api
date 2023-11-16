using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NarutoCharacters.API.Models;
using NarutoCharacters.API.Services;

namespace NarutoCharacters.API.Controllers
{
    [Route("api/ninjas/{ninjaId}/jutsu")]
    [ApiController]
    public class JutsuController : ControllerBase
    {
        private readonly INinjaRepository _ninjaRepository;
        private readonly IMapper _mapper;
        public JutsuController(INinjaRepository ninjaRepository, IMapper mapper)
        {
            _ninjaRepository = ninjaRepository ??
                throw new System.ArgumentNullException(nameof(ninjaRepository));
            _mapper = mapper ??
                throw new System.ArgumentNullException(nameof(mapper));

        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<JutsuDto>>> GetJutsus(int ninjaId)
        {
            if (!await _ninjaRepository.NinjaExistsAsync(ninjaId))
            {
                return NotFound();
            }
            var jutsus = await _ninjaRepository.GetJutsusAsync(ninjaId);
            return Ok(_mapper.Map<IEnumerable<JutsuDto>>(jutsus));
        }

        [HttpGet("{id}", Name = "GetJutsu")]
        public async Task<ActionResult<JutsuDto>> GetJutsu(int ninjaId, int id)
        {
            if (!await _ninjaRepository.NinjaExistsAsync(ninjaId))
            {
                return NotFound();
            }

            var jutsu = await _ninjaRepository.GetJutsuAsync(ninjaId, id);
            if (jutsu == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<JutsuDto>(jutsu));
        }

        [HttpPost]
        public async Task<ActionResult<JutsuDto>> CreateJutsu(int ninjaId, JutsuForCreationDto jutsu)
        {
            if (!await _ninjaRepository.NinjaExistsAsync(ninjaId) || jutsu == null)
            {
                return NotFound();
            }
            var jutsuFinal = _mapper.Map<Entities.Jutsu>(jutsu);

            await _ninjaRepository.AddJutsuToNinjaAsync(ninjaId, jutsuFinal);
            await _ninjaRepository.SaveChangesAsync();

            var createdJutsuToReturn = _mapper.Map<Models.JutsuDto>(jutsuFinal);
            return CreatedAtRoute("GetJutsu", new
            {
                ninjaId = ninjaId,
                id = createdJutsuToReturn.Id,

            }, createdJutsuToReturn);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<JutsuDto>> UpdateJutsu(int ninjaId, int id, JutsuForUpdateDto jutsu)
        {
            if (!await _ninjaRepository.NinjaExistsAsync(ninjaId))
            {
                return NotFound();
            }

            var jutsuEntity = await _ninjaRepository.GetJutsuAsync(ninjaId, id);
            if (jutsuEntity == null)
            {
                return NotFound();
            }

            _mapper.Map(jutsu, jutsuEntity);
            await _ninjaRepository.SaveChangesAsync();

            var updatedJutsuToReturn = _mapper.Map<Models.JutsuDto>(jutsuEntity);
            return CreatedAtRoute("GetJutsu", new { ninjaId = ninjaId, id = jutsuEntity.Id }, updatedJutsuToReturn);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteJutsu(int ninjaId, int id)
        {
            if(!await _ninjaRepository.NinjaExistsAsync(ninjaId))
            {
                return NotFound();
            }
            var jutsuForDel = await _ninjaRepository.GetJutsuAsync(ninjaId, id);
            if (jutsuForDel == null)
            {
                return NotFound();
            }

            _ninjaRepository.DeleteJutsu(jutsuForDel);
            await _ninjaRepository.SaveChangesAsync();

            return NoContent();
        }
    }
}
