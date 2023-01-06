namespace PortfolioApiV1.Models.Dtos
{
    public class AddUserRequest
    {
        public string? Avatar { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Salt { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string? Phone { get; set; }
        public DateTime? Birthday { get; set; }
        public bool IsAdmin { get; set; }
        public string? About { get; set; }
    }
}
