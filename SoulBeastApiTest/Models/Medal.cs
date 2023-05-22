using Microsoft.AspNetCore.Mvc;

namespace SoulBeastApiTest.Models
{
    public class Medal
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public string Dungeon { get; set; }

        // Relação que 1 Medal por ter somente 1 OwnerId porém não é obrigatório
        public Guid? OwnerId { get; set; }
        public Owner Owner { get; set; }
    }
}
