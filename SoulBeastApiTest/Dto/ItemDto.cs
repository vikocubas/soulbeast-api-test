namespace SoulBeastApiTest.Dto
{
    public class ItemDto
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public string Description { get; set; }
        public string Rarity { get; set; }
        public Guid? SoulbeastId { get; set; }
    }
}
