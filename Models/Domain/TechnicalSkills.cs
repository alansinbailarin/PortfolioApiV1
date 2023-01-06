namespace PortfolioApiV1.Models.Domain
{
    public class TechnicalSkills
    {
        public Guid TechnicalSkillsId { get; set; }
        public string Name { get; set; }
        public int? Experience { get; set; }

        public IEnumerable<User>? Users { get; set; }
    }
}
