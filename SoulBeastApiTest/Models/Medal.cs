namespace SoulBeastApiTest.Models
{
    public class Medal
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public string Dungeon { get; set; }
        public Guid? OwnerId { get; set; }
        public Owner? Owner { get; set; }
    }
}
