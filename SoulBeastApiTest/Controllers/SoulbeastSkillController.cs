using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            var soulbeastSkills = _dbContext.SoulbeastSkills
                .Select(soulbeastSkill => new SoulbeastSkillDto
                {
                    Id = soulbeastSkill.Id,
                    SoulbeastId = soulbeastSkill.SoulbeastId,
                    SkillId = soulbeastSkill.SkillId,
                    Skills = soulbeastSkill.Skills.
                        Select(skills => new SkillDto
                        {
                            Id = skills.Id,
                            Name = skills.Name,
                            Level = skills.Level,
                            Description = skills.Description,
                        }).ToList(),
                })
                .ToList();

            return Ok(soulbeastSkills);

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

        //Método Delete para deletar um SoulbeastSkills por Id
        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteSoulbeastSkill([FromRoute] Guid id)
        {
            var item = await _dbContext.SoulbeastSkills.FindAsync(id);

            if (item != null)
            {
                _dbContext.Remove(item);
                await _dbContext.SaveChangesAsync();

                return Ok(item);
            }

            return NotFound();
        }
    }
}
