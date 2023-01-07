namespace PortfolioApiV1.Profiles
{
    public class WorkRecordsProfile: AutoMapper.Profile
    {
        public WorkRecordsProfile()
        {
            CreateMap<Models.Domain.WorkRecord, Models.Dtos.WorkRecords>()
                .ReverseMap();

        }
    }
}
