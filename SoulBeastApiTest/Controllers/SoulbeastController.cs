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
    }
}
