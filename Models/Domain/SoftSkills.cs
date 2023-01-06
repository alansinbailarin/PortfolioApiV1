namespace PortfolioApiV1.Models.Domain
{
    public class SoftSkills
    {
        public Guid SoftSkillsId { get; set; }
        public string Name { get; set; }
        public IEnumerable<User> Users { get; set; }
    }
}
