namespace PortfolioApiV1.Repositories.Trajectory
{
    public interface ITrajectoryRepository
    {
        Task<IEnumerable<Models.Domain.Trajectory>> GetAllAsync();
        Task<Models.Domain.Trajectory> GetByIdAsync(Guid TrajectoryId);
        Task<Models.Domain.Trajectory> AddTrajectoryAsync(Models.Domain.Trajectory Trajectory);
        Task<Models.Domain.Trajectory> UpdateTrajectoryAsync(Guid TrajectoryId, Models.Domain.Trajectory Trajectory);
        Task<Models.Domain.Trajectory> DeleteTrajectoryAsync(Guid TrajectoryId);
    }
}
