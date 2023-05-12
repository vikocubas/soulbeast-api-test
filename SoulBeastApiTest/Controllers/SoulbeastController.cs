using Microsoft.AspNetCore.Mvc;
using SoulBeastApiTest.Data;
using SoulBeastApiTest.Dto;
using SoulBeastApiTest.Models;

namespace SoulBeastApiTest.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SoulbeastController : Controller
    {
        private readonly DataContext _dbContext;

        public SoulbeastController(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        //Método Get pegando todos os SoulBeasts
        [HttpGet]
        public IActionResult GetSoulbeasts()
        {
            return Ok(_dbContext.Soulbeasts.ToList());        
        }

        //Método Get por Id Soulbeast
        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetSoulbeast([FromRoute] Guid id)
        {
            var soulbeast = await _dbContext.Soulbeasts.FindAsync(id);

            if(soulbeast == null)
            {
                return NotFound();
            }

            return Ok(soulbeast);
        }

        //Método Post criando um SoulBeast
        [HttpPost]
        public async Task<IActionResult> AddSoulbeast(SoulbeastDto soulbeastCreate)
        {
            var soulbeast = new Soulbeast()
            {
                Name = soulbeastCreate.Name,
                Level = soulbeastCreate.Level,
                Element = soulbeastCreate.Element,
                OwnerId = soulbeastCreate.OwnerId,
            };

            await _dbContext.Soulbeasts.AddAsync(soulbeast);
            await _dbContext.SaveChangesAsync();
            return Ok(soulbeast);
            
        }

        //Método Put Update um Soulbeast por id
        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateSoulbeast([FromRoute] Guid id, SoulbeastDto soulbeastUpdate)
        {
            var soulbeast = await _dbContext.Soulbeasts.FindAsync(id);

            if (soulbeast != null)
            {
                soulbeast.Name = soulbeastUpdate.Name;
                soulbeast.Level = soulbeastUpdate.Level;
                soulbeast.Element = soulbeastUpdate.Element;
                soulbeast.OwnerId = soulbeastUpdate.OwnerId;

                await _dbContext.SaveChangesAsync();

                return Ok(soulbeast);
            }

            return NotFound();
        }

        //Método Delete para deletar SoulBeast por Id
        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteSoulbeast([FromRoute] Guid id)
        {
            var soulbeast = await _dbContext.Soulbeasts.FindAsync(id);

            if (soulbeast != null)
            {
                _dbContext.Remove(soulbeast);
                await _dbContext.SaveChangesAsync();

                return Ok(soulbeast);
            }

            return NotFound();
        }
    }
}
