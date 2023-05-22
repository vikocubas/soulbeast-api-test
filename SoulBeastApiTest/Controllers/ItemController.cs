using Microsoft.AspNetCore.Mvc;
using SoulBeastApiTest.Data;
using SoulBeastApiTest.Dto;
using SoulBeastApiTest.Models;

namespace SoulBeastApiTest.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ItemController : Controller
    {
        private readonly DataContext _dbContext;

        public ItemController(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        //Método Get pegando todos os Items
        [HttpGet]
        public IActionResult GetItems()
        {
            return Ok(_dbContext.Items.ToList());
        }

        //Método Get por Id do Item
        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetItems([FromRoute] Guid id)
        {
            var item = await _dbContext.Medals.FindAsync(id);

            if (item == null)
            {
                return NotFound();
            }

            return Ok(item);
        }

        //Método Post criando um Item
        [HttpPost]
        public async Task<IActionResult> AddItem(ItemDto itemCreate)
        {
            var item = new Item()
            {
                Name = itemCreate.Name,
                Description = itemCreate.Description,
                Rarity = itemCreate.Rarity,
            };

            await _dbContext.Items.AddAsync(item);
            await _dbContext.SaveChangesAsync();
            return Ok(item);
        }

        //Método Put Update um Item por id
        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateItem([FromRoute] Guid id, ItemDto itemUpdate)
        {
            var item = await _dbContext.Items.FindAsync(id);

            if (item != null)
            {
                item.Name = itemUpdate.Name;
                item.Description = itemUpdate.Description;
                item.Rarity = itemUpdate.Rarity;

                await _dbContext.SaveChangesAsync();

                return Ok(item);
            }

            return NotFound();
        }

        //Método Delete para deletar Item por Id
        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteItem([FromRoute] Guid id)
        {
            var item = await _dbContext.Items.FindAsync(id);

            if (item != null)
            {
                _dbContext.Remove(item);
                await _dbContext.SaveChangesAsync();

                return Ok(item);
            }

            return NotFound();
        }

        //Método Post adicionando um Item a um Soulbeast Id
        [HttpPost]
        [Route("{id:guid}/assign-item")]
        public async Task<IActionResult> PutItem([FromRoute] Guid id, ItemDto assignItem)
        {
            var item = await _dbContext.Items.FindAsync(id);

            if (item != null)
            {
                item.SoulbeastId = assignItem.SoulbeastId;

                await _dbContext.SaveChangesAsync();

                return Ok(item);
            }

            return NotFound();
        }
    }
}
