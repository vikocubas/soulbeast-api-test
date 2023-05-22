using Microsoft.AspNetCore.Mvc;
using SoulBeastApiTest.Data;
using SoulBeastApiTest.Dto;
using SoulBeastApiTest.Models;

namespace SoulBeastApiTest.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OwnerController : Controller
    {
        private readonly DataContext _dbContext;

        public OwnerController(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        //Método Get pegando todos os Owner e selecionando seus dados, seus Soulbeasts e suas Medalhas.
        [HttpGet]
        public IActionResult GetOwners()
        {
            var owners = _dbContext.Owners
                .Select(owner => new OwnerDto
                {
                    Id = owner.Id,
                    Name = owner.Name,
                    Age = owner.Age,
                    HomeTown = owner.HomeTown,
                    Soulbeasts = owner.Soulbeasts.
                        Select(soulbeast => new SoulbeastDto
                        {
                            Id = soulbeast.Id,
                            Name = soulbeast.Name,
                            Level = soulbeast.Level,
                            Element = soulbeast.Element,
                            OwnerId = soulbeast.OwnerId,
                        })
                        .ToList(),
                    Medals = owner.Medals.
                        Select(medals => new MedalDto
                        {
                            Id = medals.Id,
                            Name = medals.Name,
                            Dungeon = medals.Dungeon,
                            OwnerId = medals.OwnerId
                        })
                        .ToList(),
                })
                .OrderBy(owner => owner.Name)
                .ToList();

            return Ok(owners);
        }

        //Método Get por Owner Id mostrando dados, seus SoulBeasts e suas Medalhas.
        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetOwner([FromRoute] Guid id)
        {
            var owner = await _dbContext.Owners.FindAsync(id);

            if (owner != null)
            {
                var ownerselect = _dbContext.Owners
                 .Select(owner => new OwnerDto
                 {
                     Id = owner.Id,
                     Name = owner.Name,
                     Age = owner.Age,
                     HomeTown = owner.HomeTown,
                     Soulbeasts = owner.Soulbeasts.
                         Select(soulbeast => new SoulbeastDto
                         {
                             Id = soulbeast.Id,
                             Name = soulbeast.Name,
                             Level = soulbeast.Level,
                             Element = soulbeast.Element
                         })
                         .ToList(),
                    Medals = owner.Medals.
                        Select(medals => new MedalDto
                        {
                            Id = medals.Id,
                            Name = medals.Name,
                            Dungeon = medals.Dungeon,
                            OwnerId = medals.OwnerId
                        }).ToList()
                 }).Where(o => o.Id == id).FirstOrDefault();

                return Ok(ownerselect);
            }

            return NotFound();
        }



        //Método Post criando um Owner
        [HttpPost]
        public async Task<IActionResult> AddOwner(OwnerDto ownerCreate)
        {
            var owner = new Owner()
            {
                Name = ownerCreate.Name,
                Age = ownerCreate.Age,
                HomeTown = ownerCreate.HomeTown,
            };

            await _dbContext.Owners.AddAsync(owner);
            await _dbContext.SaveChangesAsync();
            return Ok(owner);
        }

        //Método Put Update um Owner por id
        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateOwner([FromRoute] Guid id, OwnerDto ownerUpdate)
        {
            var owner = await _dbContext.Owners.FindAsync(id);

            if (owner != null)
            {
                owner.Name = ownerUpdate.Name;
                owner.Age = ownerUpdate.Age;
                owner.HomeTown = ownerUpdate.HomeTown;

                await _dbContext.SaveChangesAsync();

                return Ok(owner);
            }

            return NotFound();
        }

        //Método Delete para deletar Owner por Id
        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteOwner([FromRoute] Guid id)
        {
            var owner = await _dbContext.Owners.FindAsync(id);
            
            if (owner != null)
            {
                _dbContext.Remove(owner);
                await _dbContext.SaveChangesAsync();

                return Ok(owner);
            }

            return NotFound();
        }
    }
}
