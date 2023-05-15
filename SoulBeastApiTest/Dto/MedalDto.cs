namespace SoulBeastApiTest.Dto
{
    public class MedalDto
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public string Dungeon { get; set; }
        public Guid? OwnerId { get; set; }
    }
}
