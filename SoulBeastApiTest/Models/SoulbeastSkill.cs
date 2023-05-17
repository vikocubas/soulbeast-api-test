using SoulBeastApiTest.Dto;

namespace SoulBeastApiTest.Models
{
    public class SoulbeastSkill
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid SoulbeastId { get; set; }
        public Guid SkillId { get; set; }
        public List<Skill>? Skills { get; set; }
    }
}
