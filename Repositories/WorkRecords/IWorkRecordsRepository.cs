using PortfolioApiV1.Models.Domain;


namespace PortfolioApiV1.Repositories.WorkRecords
{
    public interface IWorkRecordsRepository
    {
        Task<IEnumerable<WorkRecord>> GetAllAsync();
        Task<WorkRecord> GetByIdAsync(Guid WorkRecordId);
        Task<WorkRecord> AddWorkRecordAsync(WorkRecord WorkRecord);
        Task<WorkRecord> UpdateWorkRecordAsync(Guid WorkRecordId, WorkRecord WorkRecord);
        Task<WorkRecord> DeleteWorkRecordAsync(Guid WorkRecordId);
    }
}
