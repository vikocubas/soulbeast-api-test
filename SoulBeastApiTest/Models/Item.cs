using Microsoft.AspNetCore.Mvc;

namespace SoulBeastApiTest.Models
{
    public class Item
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public string Description { get; set; }
        public string Rarity { get; set; }
        public Guid? SoulbeastId { get; set; }
        public Soulbeast Soulbeast { get; set; }
    }
}
