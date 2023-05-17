using Microsoft.AspNetCore.Mvc;
using SoulBeastApiTest.Data;
using SoulBeastApiTest.Dto;
using SoulBeastApiTest.Models;

namespace SoulBeastApiTest.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SkillController : Controller
    {
        private readonly DataContext _dbContext;

        public SkillController(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        //Método Get pegando todos as Skills
        [HttpGet]
        public IActionResult GetSkills()
        {
            return Ok(_dbContext.Skills.ToList());
        }

        //Método Get por Id da Skill
        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetSkill([FromRoute] Guid id)
        {
            var skill = await _dbContext.Skills.FindAsync(id);

            if (skill == null)
            {
                return NotFound();
            }

            return Ok(skill);
        }

        //Método Post criando um Medal
        [HttpPost]
        public async Task<IActionResult> AddSkill(SkillDto skillCreate)
        {
            var skill = new Skill()
            {
                Name = skillCreate.Name,
                Level = skillCreate.Level,
                Description = skillCreate.Description,
            };

            await _dbContext.Skills.AddAsync(skill);
            await _dbContext.SaveChangesAsync();
            return Ok(skill);
        }

        //Método Put Update uma Medal por id
        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateSkill([FromRoute] Guid id, SkillDto skillUpdate)
        {
            var skill = await _dbContext.Skills.FindAsync(id);

            if (skill != null)
            {
                skill.Name = skillUpdate.Name;
                skill.Level = skillUpdate.Level;
                skill.Description = skillUpdate.Description;

                await _dbContext.SaveChangesAsync();

                return Ok(skill);
            }

            return NotFound();
        }

        //Método Put adicionando uma Skill a um SoulbeastSkill Id
        [HttpPut]
        [Route("{id:guid}/putSkill")]
        public async Task<IActionResult> PutMedal([FromRoute] Guid id, SkillDto putSkill)
        {
            var skill = await _dbContext.Skills.FindAsync(id);

            if (skill != null)
            {
                skill.SoulbeastSkillId = putSkill.SoulbeastSkillId;

                await _dbContext.SaveChangesAsync();

                return Ok(skill);
            }

            return NotFound();
        }


        //Método Delete para deletar Medal por Id
        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteSkill([FromRoute] Guid id)
        {
            var skill = await _dbContext.Skills.FindAsync(id);

            if (skill != null)
            {
                _dbContext.Remove(skill);
                await _dbContext.SaveChangesAsync();

                return Ok(skill);
            }

            return NotFound();
        }
    }
}
