namespace PortfolioApiV1.Profiles
{
    public class UsersProfile: AutoMapper.Profile
    {
        public UsersProfile()
        {
            CreateMap<Models.Domain.User, Models.Dtos.User>().ReverseMap();
        }
    }
}
