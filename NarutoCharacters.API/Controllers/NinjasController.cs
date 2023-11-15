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
        public NinjasController(INinjaRepository ninjaRepository)
        {
            _ninjaRepository = ninjaRepository ?? throw new System.ArgumentNullException(nameof(ninjaRepository));
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NinjaWithoutJutsusDto>>> GetNinjas()
        {
            var ninjaEntities = await _ninjaRepository.GetNinjasAsync();
            var results = new List<NinjaWithoutJutsusDto>();
            foreach (var ninjaEntity in ninjaEntities)
            {
                results.Add(new NinjaWithoutJutsusDto()
                {
                    Id = ninjaEntity.Id,
                    Name = ninjaEntity.Name,
                    Description = ninjaEntity.Description
                });
            }
            return Ok(results);
        }

        [HttpGet("{id}", Name = "GetNinja")]
        public ActionResult<NinjaDto> GetNinja(int id)
        {
            //var ninja = NinjasDataStore.Current.Ninjas.FirstOrDefault(n => n.Id == id);
            //if(ninja == null)
            //{
            //    return NotFound();
            //}

            //return Ok(ninja);
            return Ok();
        }

        [HttpPost]
        public ActionResult<NinjaDto> CreateNinja(NinjaForCreationDto ninja)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            //create id for new ninja
            var nextId = 1;
            if (NinjasDataStore.Current.Ninjas.Count > 0)
            {
                nextId = NinjasDataStore.Current.Ninjas.Max(n => n.Id) + 1;
            }

            var newNinja = new NinjaDto()
            {
                Id = nextId,
                Name = ninja.Name,
                Description = ninja.Description
            };

            NinjasDataStore.Current.Ninjas.Add(newNinja);

            return CreatedAtRoute("GetNinja", new { id = newNinja.Id }, newNinja);

        }

        [HttpPut("{ninjaId}")]
        public ActionResult<NinjaDto> UpdateNinja(int ninjaId, NinjaForUpdateDto ninja)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var ninjaFromStore = NinjasDataStore.Current.Ninjas.FirstOrDefault(n => n.Id == ninjaId);
            if (ninjaFromStore == null)
            {
                return NotFound();
            }

            ninjaFromStore.Name = ninja.Name ?? ninjaFromStore.Name;
            ninjaFromStore.Description = ninja.Description ?? ninjaFromStore.Description;

            return CreatedAtRoute("GetNinja", new { id = ninjaFromStore.Id }, ninjaFromStore);
        }

        [HttpDelete("{ninjaId}")]
        public ActionResult DeleteNinja(int ninjaId)
        {
            var ninjaFromStore = NinjasDataStore.Current.Ninjas.FirstOrDefault(n => n.Id == ninjaId);
            if (ninjaFromStore == null)
            {
                return NotFound();
            }

            NinjasDataStore.Current.Ninjas.Remove(ninjaFromStore);

            return NoContent();
        }
    }

}
