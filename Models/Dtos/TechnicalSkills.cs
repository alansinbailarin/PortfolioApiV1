namespace PortfolioApiV1.Models.Dtos
{
    public class TechnicalSkills
    {
        public Guid TechnicalSkillsId { get; set; }
        public string Name { get; set; }
        public int? Experience { get; set; }

        public IEnumerable<User>? Users { get; set; }
    }
}
