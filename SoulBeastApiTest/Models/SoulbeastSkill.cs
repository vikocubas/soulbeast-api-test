using SoulBeastApiTest.Dto;

namespace SoulBeastApiTest.Models
{
    public class SoulbeastSkill
    {
        public Guid SoulbeastId { get; set; }
        public Soulbeast Soulbeasts { get; set; }
        public Guid SkillId { get; set; }
        public Skill Skills { get; set; }
    }
}
