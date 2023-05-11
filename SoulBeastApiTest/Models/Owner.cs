namespace SoulBeastApiTest.Models
{
    public class Owner
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string HomeTown { get; set; }

        // Relação que 1 Owner pode ter vários SoulBeast
        public List<Soulbeast> Soulbeasts { get; set; }
    }
}
