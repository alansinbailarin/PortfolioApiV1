using Microsoft.EntityFrameworkCore;
using PortfolioApiV1.Data;
using PortfolioApiV1.Models.Domain;
using PortfolioApiV1.Models.Dtos;

namespace PortfolioApiV1.Repositories.WorkRecords
{
    public class WorkRecordsRepository: IWorkRecordsRepository
    {
        private readonly PortfolioDbContext portfolioDbContext;

        public WorkRecordsRepository(PortfolioDbContext portfolioDbContext)
        {
            this.portfolioDbContext = portfolioDbContext;
        }

        public async Task<WorkRecord> AddWorkRecordAsync(WorkRecord WorkRecord)
        {
            WorkRecord.WorkRecordId = Guid.NewGuid();
            WorkRecord.CreatedAt = DateTime.Now;

            await portfolioDbContext.AddAsync(WorkRecord);
            await portfolioDbContext.SaveChangesAsync();

            return WorkRecord;
        }

        public async Task<WorkRecord> DeleteWorkRecordAsync(Guid WorkRecordId)
        {
            var existingWorkRecord = await portfolioDbContext.WorkRecords.FindAsync(WorkRecordId);

            if (existingWorkRecord == null)
            {
                return null;
            }

            portfolioDbContext.WorkRecords.Remove(existingWorkRecord);
            await portfolioDbContext.SaveChangesAsync();

            return existingWorkRecord;
        }

        public async Task<IEnumerable<WorkRecord>> GetAllAsync()
        {
            return await portfolioDbContext.WorkRecords
                .ToListAsync();
        }

        public async Task<WorkRecord> GetByIdAsync(Guid WorkRecordId)
        {
            return await portfolioDbContext.WorkRecords
                .FirstOrDefaultAsync(x => x.WorkRecordId == WorkRecordId);
        }

        public async Task<WorkRecord> UpdateWorkRecordAsync(Guid WorkRecordId, WorkRecord WorkRecord)
        {
            var existingWorkRecord = await portfolioDbContext.WorkRecords.FindAsync(WorkRecordId);

            if (existingWorkRecord != null)
            {
                existingWorkRecord.Title = WorkRecord.Title;
                existingWorkRecord.FromDate = WorkRecord.FromDate;
                existingWorkRecord.ToDate = WorkRecord.ToDate;
                existingWorkRecord.IsEnded = WorkRecord.IsEnded;
                existingWorkRecord.UserId = WorkRecord.UserId;

                await portfolioDbContext.SaveChangesAsync();

                return existingWorkRecord;
            }

            return null;
        }
    }
}
