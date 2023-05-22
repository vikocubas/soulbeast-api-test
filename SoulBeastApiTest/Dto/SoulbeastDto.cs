namespace SoulBeastApiTest.Dto
{
    public class SoulbeastDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Level { get; set; }
        public string Element { get; set; }
        public Guid OwnerId { get; set; }
        public List<ItemDto> Items { get; set; } = new();
        public List<SkillDto> Skills { get; set; } = new();
    }
}
