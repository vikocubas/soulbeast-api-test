using SoulBeastApiTest.Dto;

namespace SoulBeastApiTest.Models
{
    public class SoulbeastSkill
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid SoulbeastId { get; set; }
        public Soulbeast Soulbeast { get; set; }
        public Guid SkillId { get; set; }
        public Skill Skill { get; set; }
    }
}
