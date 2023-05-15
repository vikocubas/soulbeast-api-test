namespace SoulBeastApiTest.Dto
{
    public class OwnerDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string HomeTown { get; set; }
        public List<SoulbeastDto> Soulbeasts { get; set; } = new();
        public List<MedalDto>? Medals { get; set; } = new();
    }
}
