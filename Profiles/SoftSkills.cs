namespace PortfolioApiV1.Profiles
{
    public class SoftSkills : AutoMapper.Profile
    {
        public SoftSkills()
        {
            CreateMap<Models.Domain.SoftSkills, Models.Dtos.SoftSkills>().ReverseMap();
        }
    }
}
