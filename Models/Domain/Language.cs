namespace PortfolioApiV1.Models.Domain
{
    public class Language
    {
        public Guid LanguageId { get; set; }
        public string Name { get; set; }
        public string? Level { get; set; }

        public IEnumerable<User> Users { get; set; }
    }
}
