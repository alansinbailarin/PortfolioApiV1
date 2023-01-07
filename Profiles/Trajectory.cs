namespace PortfolioApiV1.Profiles
{
    public class Trajectory : AutoMapper.Profile
    {
        public Trajectory()
        {
            CreateMap<Models.Domain.Trajectory, Models.Dtos.Trajectory>().ReverseMap();

        }
    }
}
