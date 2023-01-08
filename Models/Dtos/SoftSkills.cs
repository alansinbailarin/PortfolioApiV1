namespace PortfolioApiV1.Models.Dtos
{
    public class SoftSkills
    {
        public Guid SoftSkillsId { get; set; }
        public string Name { get; set; }

        public IEnumerable<User>? Users { get; set; }
    }
}
