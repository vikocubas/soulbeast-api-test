using System;

namespace SoulBeastApiTest.Models
{
    public class Skill
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public int Level { get; set; }
        public string Description { get; set; }
    }
}
