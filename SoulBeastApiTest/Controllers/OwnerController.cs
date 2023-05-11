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

        //Método Get pegando todos os Owner e selecionando seus dados e seus Soulbeasts.
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
                            Element = soulbeast.Element
                        })
                        .ToList()
                })
                .ToList();



            return Ok(owners);
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
    }
}
