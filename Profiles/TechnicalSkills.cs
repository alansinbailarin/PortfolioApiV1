namespace PortfolioApiV1.Profiles
{
    public class TechnicalSkills : AutoMapper.Profile
    {
        public TechnicalSkills()
        {
            CreateMap<Models.Domain.TechnicalSkills, Models.Dtos.TechnicalSkills>().ReverseMap();
        }
    }
}
