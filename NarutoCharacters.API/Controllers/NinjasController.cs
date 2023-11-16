using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NarutoCharacters.API.Models;
using NarutoCharacters.API.Services;
using System.Collections.Generic;

namespace NarutoCharacters.API.Controllers
{
    [Route("api/ninjas")]
    [ApiController]
    public class NinjasController : ControllerBase
    {

        private readonly INinjaRepository _ninjaRepository;
        private readonly IMapper _mapper;
        public NinjasController(INinjaRepository ninjaRepository, IMapper mapper)
        {
            _ninjaRepository = ninjaRepository ?? throw new System.ArgumentNullException(nameof(ninjaRepository));
            _mapper = mapper ?? throw new System.ArgumentNullException();
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NinjaWithoutJutsusDto>>> GetNinjas()
        {
            var ninjaEntities = await _ninjaRepository.GetNinjasAsync();
            return Ok(_mapper.Map<IEnumerable<NinjaWithoutJutsusDto>>(ninjaEntities));
        }

        [HttpGet("{id}", Name = "GetNinja")]
        public async Task<IActionResult> GetNinja(int id, bool includeJutsus = false)
        {
            var ninja = await _ninjaRepository.GetNinjaAsync(id, includeJutsus);
            if (ninja == null)
            {
                return NotFound();
            }
            if (includeJutsus)
            {
                return Ok(_mapper.Map<NinjaDto>(ninja));
            }
            return Ok(_mapper.Map<NinjaWithoutJutsusDto>(ninja));
        }

        [HttpPost]
        public ActionResult<NinjaDto> CreateNinja(NinjaForCreationDto ninja)
        {
            var ninjaForCreation = _mapper.Map<Entities.Ninja>(ninja);
            _ninjaRepository.AddNinja(ninjaForCreation);
            _ninjaRepository.SaveChangesAsync();
            _mapper.Map<NinjaWithoutJutsusDto>(ninjaForCreation);
            return CreatedAtRoute("GetNinja", new { id = ninjaForCreation.Id }, ninjaForCreation);
        }

        [HttpPut("{ninjaId}")]
        public async Task<ActionResult<NinjaDto>> UpdateNinja(int ninjaId, NinjaForUpdateDto ninja)
        {
            var ninjaEntity = await _ninjaRepository.GetNinjaAsync(ninjaId, false);
            if (ninja == null)
            {
                return NotFound();
            }
            _mapper.Map(ninja, ninjaEntity);
            await _ninjaRepository.SaveChangesAsync();

            var updateNinjaToReturn = _mapper.Map<Models.NinjaWithoutJutsusDto>(ninjaEntity);
            return CreatedAtRoute("GetNinja", new { id = ninjaId }, ninjaEntity);
        }


        [HttpDelete("{ninjaId}")]
        public async Task<ActionResult> DeleteNinja(int ninjaId)
        {
            var ninjaEntityForDel = await _ninjaRepository.GetNinjaAsync(ninjaId, true);
            if (ninjaEntityForDel == null)
            {
                return NotFound();
            }
            _ninjaRepository.DeleteNinja(ninjaEntityForDel);
            await _ninjaRepository.SaveChangesAsync();
            return NoContent();
        }
    }

}
