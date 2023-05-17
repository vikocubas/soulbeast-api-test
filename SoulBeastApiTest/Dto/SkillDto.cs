using SoulBeastApiTest.Models;

namespace SoulBeastApiTest.Dto
{
    public class SkillDto
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public int Level { get; set; }
        public string Description { get; set; }
        public Guid? SoulbeastSkillId { get; set; }
    }
}
