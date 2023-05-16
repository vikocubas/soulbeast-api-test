using SoulBeastApiTest.Models;

namespace SoulBeastApiTest.Dto
{
    public class SoulbeastSkillDto
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid SoulbeastId { get; set; }
        public Guid SkillId { get; set; }

    }
}
