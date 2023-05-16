using Microsoft.AspNetCore.Mvc;
using SoulBeastApiTest.Data;
using SoulBeastApiTest.Dto;
using SoulBeastApiTest.Models;

namespace SoulBeastApiTest.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SoulbeastSkillController : Controller
    {
        private readonly DataContext _dbContext;

        public SoulbeastSkillController(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        //Método Get pegando todos as SoulbeastSkills
        [HttpGet]
        public IActionResult GetSoulbeastSkills()
        {
            return Ok(_dbContext.SoulbeastSkills.ToList());
        }

        //Método Post criando um SoulbeastSkills
        [HttpPost]
        public async Task<IActionResult> AddSoulbeastSkill(SoulbeastSkillDto soulbeastskillCreate)
        {
            var soulbeastskill = new SoulbeastSkill()
            {
                SoulbeastId = soulbeastskillCreate.SoulbeastId,
                SkillId = soulbeastskillCreate.SkillId,
            };

            await _dbContext.SoulbeastSkills.AddAsync(soulbeastskill);
            await _dbContext.SaveChangesAsync();

            return Ok(soulbeastskill);
        }
    }
}
