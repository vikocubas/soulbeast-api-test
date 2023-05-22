﻿using Microsoft.AspNetCore.Mvc;
using SoulBeastApiTest.Data;
using SoulBeastApiTest.Dto;
using SoulBeastApiTest.Models;

namespace SoulBeastApiTest.Controllers
{
    [ApiController]
    [Route("api/soulbeasts")]
    public class SoulbeastController : Controller
    {
        private readonly DataContext _dbContext;

        public SoulbeastController(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        //Método Get mostrando todos os SoulBeasts, seus Items e suas skills.
        [HttpGet]
        public IActionResult GetSoulbeasts()
        {
            var soulbeast = _dbContext.Soulbeasts
                .Select(soulbeast => new SoulbeastDto
                {
                    Id = soulbeast.Id,
                    Name = soulbeast.Name,
                    Level = soulbeast.Level,
                    Element = soulbeast.Element,
                    OwnerId = soulbeast.OwnerId,
                    Items = soulbeast.Items
                        .Select(items => new ItemDto
                        {
                            Id = items.Id,
                            Name = items.Name,
                            Description = items.Description,
                            Rarity = items.Rarity,
                            SoulbeastId = items.SoulbeastId,
                        })
                        .ToList(),
                    Skills = soulbeast.Skills
                        .Select(skill => new SkillDto
                        {
                            Id = skill.Id,
                            Name = skill.Name,
                            Level = skill.Level,
                            Description = skill.Description
                        })
                        .OrderBy(skill => skill.Level)
                        .ToList(),
                })
                .OrderBy(soulbeast => soulbeast.Name)
                .ToList();

            return Ok(soulbeast);
        }

        //Método Get por SoulBeast Id mostrando dados, seus Items e suas skills.
        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetSoulbeast([FromRoute] Guid id)
        {
            var soulbeast = await _dbContext.Soulbeasts.FindAsync(id);

            if (soulbeast != null)
            {
                var soulbeastselect = _dbContext.Soulbeasts
                 .Select(soulbeast => new SoulbeastDto
                 {
                     Id = soulbeast.Id,
                     Name = soulbeast.Name,
                     Level = soulbeast.Level,
                     Element = soulbeast.Element,
                     OwnerId = soulbeast.OwnerId,
                     Items = soulbeast.Items.
                        Select(items => new ItemDto
                        {
                            Id = items.Id,
                            Name = items.Name,
                            Description = items.Description,
                            Rarity = items.Rarity,
                            SoulbeastId = items.SoulbeastId,
                        })
                        .ToList(),
                     Skills = soulbeast.Skills
                        .Select(skill => new SkillDto
                        {
                            Id = skill.Id,
                            Name = skill.Name,
                            Level = skill.Level,
                            Description = skill.Description
                        })
                        .OrderBy(skill => skill.Level)
                        .ToList(),
                 }).Where(s => s.Id == id).FirstOrDefault();

                return Ok(soulbeastselect);
            }

            return NotFound();
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

        [HttpPost]
        [Route("{id:guid}/skills/{skillId:guid}")]
        public async Task<IActionResult> AssignSkill([FromRoute] Guid id, [FromRoute] Guid skillId)
        {
            var soulbeastskill = new SoulbeastSkill()
            {
                SoulbeastId = id,
                SkillId = skillId,
            };

            await _dbContext.SoulbeastSkills.AddAsync(soulbeastskill);
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete]
        [Route("{id:guid}/skills/{skillId:guid}")]
        public async Task<IActionResult> UnAssignSkill([FromRoute] Guid id, [FromRoute] Guid skillId)
        {
            var soulbeastskill = new SoulbeastSkill()
            {
                SoulbeastId = id,
                SkillId = skillId,
            };

            _dbContext.SoulbeastSkills.Remove(soulbeastskill);
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }
    }
}
