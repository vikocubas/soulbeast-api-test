﻿namespace SoulBeastApiTest.Models
{
    public class Soulbeast
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public int Level { get; set; }
        public string Element { get; set; }

        // Relação de 1 SoulBeast pode ter 1 Owner
        public Guid OwnerId { get; set; }
        public Owner Owner { get; set; }

        // Relação de 1 SoulBeast pode ter 1 Item ou mais items (Sempre colocar quando criar lista: = new();)
        public List<Item> Items { get; set; } = new();
        public List<Skill> Skills { get; set; } = new();
    }
}
