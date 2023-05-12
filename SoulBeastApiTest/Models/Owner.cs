namespace SoulBeastApiTest.Models
{
    public class Owner
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public int Age { get; set; }
        public string HomeTown { get; set; }

        // Relação que 1 Owner pode ter vários SoulBeast (Sempre colocar quando criar lista: = new();)
        public List<Soulbeast> Soulbeasts { get; set; } = new();
    }
}
