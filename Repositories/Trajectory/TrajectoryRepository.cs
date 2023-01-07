using Microsoft.EntityFrameworkCore;
using PortfolioApiV1.Data;
using PortfolioApiV1.Models.Domain;
using PortfolioApiV1.Models.Dtos;

namespace PortfolioApiV1.Repositories.Trajectory
{
    public class TrajectoryRepository: ITrajectoryRepository
    {
        private readonly PortfolioDbContext portfolioDbContext;

        public TrajectoryRepository(PortfolioDbContext portfolioDbContext)
        {
            this.portfolioDbContext = portfolioDbContext;
        }

        public async Task<Models.Domain.Trajectory> AddTrajectoryAsync(Models.Domain.Trajectory Trajectory)
        {
            Trajectory.TrajectoryId = Guid.NewGuid();
            Trajectory.CreatedAt = DateTime.Now;

            await portfolioDbContext.AddAsync(Trajectory);
            await portfolioDbContext.SaveChangesAsync();

            return Trajectory;
        }

        public async Task<Models.Domain.Trajectory> DeleteTrajectoryAsync(Guid TrajectoryId)
        {
            var existingTrajectory = await portfolioDbContext.Trajectories.FindAsync(TrajectoryId);

            if (existingTrajectory == null)
            {
                return null;
            }

            portfolioDbContext.Trajectories.Remove(existingTrajectory);
            await portfolioDbContext.SaveChangesAsync();

            return existingTrajectory;
        }

        public async Task<IEnumerable<Models.Domain.Trajectory>> GetAllAsync()
        {
            return await portfolioDbContext.Trajectories
                            .ToListAsync();
        }

        public async Task<Models.Domain.Trajectory> GetByIdAsync(Guid TrajectoryId)
        {
            return await portfolioDbContext.Trajectories
                            .FirstOrDefaultAsync(x => x.TrajectoryId == TrajectoryId);
        }

        public async Task<Models.Domain.Trajectory> UpdateTrajectoryAsync(Guid TrajectoryId, Models.Domain.Trajectory Trajectory)
        {
            var existingTrajectory = await portfolioDbContext.Trajectories.FindAsync(TrajectoryId);

            if (existingTrajectory != null)
            {
                existingTrajectory.Title = Trajectory.Title;
                existingTrajectory.Body = Trajectory.Body;
                existingTrajectory.FromDate = Trajectory.FromDate;
                existingTrajectory.ToDate = Trajectory.ToDate;
                existingTrajectory.Visibility = Trajectory.Visibility;
                existingTrajectory.Link = Trajectory.Link;
                existingTrajectory.UserId = Trajectory.UserId;

                await portfolioDbContext.SaveChangesAsync();

                return existingTrajectory;
            }

            return null;
        }
    }
}
