using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NarutoCharacters.API.Models;

namespace NarutoCharacters.API.Controllers
{
    [Route("api/ninjas/{ninjaId}/jutsu")]
    [ApiController]
    public class JutsuController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<JutsuDto>> GetJutsus(int ninjaId)
        {
            var ninja = NinjasDataStore.Current.Ninjas.FirstOrDefault(n => n.Id == ninjaId);
            if(ninja == null)
            {
                return NotFound();
            }
            return Ok(ninja.Jutsus);
        }

        [HttpGet("{id}", Name = "GetJutsu")]
        public ActionResult<JutsuDto> GetJutsu(int ninjaId, int id)
        {
            var ninja = NinjasDataStore.Current.Ninjas.FirstOrDefault(n => n.Id == ninjaId);
            if(ninja== null)
            {
                return NotFound();
            }

            //find jutsu
            var jutsu = ninja.Jutsus.FirstOrDefault(j => j.Id == id);
            if(jutsu == null)
            {
                return NotFound();
            }
            return Ok(jutsu);
        }

        [HttpPost]
        public ActionResult<JutsuDto> CreateJutsu(int ninjaId, JutsuForCreationDto jutsu)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var ninja = NinjasDataStore.Current.Ninjas.FirstOrDefault(n => n.Id == ninjaId);
            if(ninja == null)
            {
                return NotFound();
            }

            //create id for new jutsu
            var nextId = 1;
            if(ninja.Jutsus.Count > 0)
            {
                nextId = ninja.Jutsus.Max(j => j.Id) + 1;
            }

            var newJutsu = new JutsuDto()
            {
                Id = nextId,
                Name = jutsu.Name,
                Description = jutsu.Description
            };

            ninja.Jutsus.Add(newJutsu);

            return CreatedAtRoute("GetJutsu", new { ninjaId= ninjaId, id= newJutsu.Id}, newJutsu );  
        }

        [HttpPut("{id}")]
        public ActionResult<JutsuDto> UpdateJutsu(int ninjaId, int id, JutsuForUpdateDto jutsu)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }

            var ninja = NinjasDataStore.Current.Ninjas.FirstOrDefault(n => n.Id == ninjaId);
            if(ninja == null)
            {
                return NotFound();
            }

            var jutsuFromStore = ninja.Jutsus.FirstOrDefault(j => j.Id == id);
            if(jutsuFromStore == null)
            {
                return NotFound();
            }

            jutsuFromStore.Name = jutsu.Name ?? jutsuFromStore.Name;
            jutsuFromStore.Description = jutsu.Description ?? jutsuFromStore.Description;

            return CreatedAtRoute("GetJutsu", new { ninjaId = ninjaId, id = jutsuFromStore.Id }, jutsuFromStore);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteJutsu(int ninjaId, int id)
        {
            var ninja = NinjasDataStore.Current.Ninjas.FirstOrDefault(n => n.Id == ninjaId);
            if(ninja == null)
            {
                return NotFound();
            }

            var jutsuFromStore = ninja.Jutsus.FirstOrDefault(j => j.Id == id);
            if(jutsuFromStore == null)
            {
                return NotFound();
            }

            ninja.Jutsus.Remove(jutsuFromStore);

            return NoContent();
        }
    }
}
