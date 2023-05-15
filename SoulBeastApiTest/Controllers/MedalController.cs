using Microsoft.AspNetCore.Mvc;
using SoulBeastApiTest.Data;
using SoulBeastApiTest.Dto;
using SoulBeastApiTest.Models;

namespace SoulBeastApiTest.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MedalController : Controller
    {
        private readonly DataContext _dbContext;

        public MedalController(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        //Método Get pegando todos os Medals
        [HttpGet]
        public IActionResult GetMedals()
        {
            return Ok(_dbContext.Medals.ToList());
        }

        //Método Get por Id do Medal
        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetMedals([FromRoute] Guid id)
        {
            var medal = await _dbContext.Medals.FindAsync(id);

            if (medal == null)
            {
                return NotFound();
            }

            return Ok(medal);
        }

        //Método Post criando um Medal
        [HttpPost]
        public async Task<IActionResult> AddMedal(MedalDto medalCreate)
        {
            var medal = new Medal()
            {
                Name = medalCreate.Name,
                Dungeon = medalCreate.Dungeon,
            };

            await _dbContext.Medals.AddAsync(medal);
            await _dbContext.SaveChangesAsync();
            return Ok(medal);
        }

        //Método Put Update uma Medal por id
        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateMedal([FromRoute] Guid id, MedalDto medalUpdate)
        {
            var medal = await _dbContext.Medals.FindAsync(id);

            if (medal != null)
            {
                medal.Name = medalUpdate.Name;
                medal.Dungeon = medalUpdate.Dungeon;

                await _dbContext.SaveChangesAsync();

                return Ok(medal);
            }

            return NotFound();
        }

        //Método Put adicionando uma Medalha a um Owner Id
        [HttpPut]
        [Route("{id:guid}/putMedal")]
        public async Task<IActionResult> PutMedal([FromRoute] Guid id, MedalDto putMedal)
        {
            var medal = await _dbContext.Medals.FindAsync(id);

            if (medal != null)
            {
                medal.OwnerId = putMedal.OwnerId;

                await _dbContext.SaveChangesAsync();

                return Ok(medal);
            }

            return NotFound();
        }


        //Método Delete para deletar Medal por Id
        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteMedal([FromRoute] Guid id)
        {
            var medal = await _dbContext.Medals.FindAsync(id);

            if (medal != null)
            {
                _dbContext.Remove(medal);
                await _dbContext.SaveChangesAsync();

                return Ok(medal);
            }

            return NotFound();
        }
    }
}
