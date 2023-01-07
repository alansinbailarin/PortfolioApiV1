using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PortfolioApiV1.Models.Dtos;
using PortfolioApiV1.Repositories;
using PortfolioApiV1.Repositories.Trajectory;

namespace PortfolioApiV1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TrajectoryController : Controller
    {
        private readonly ITrajectoryRepository trajectoryRepository;
        private readonly IMapper mapper;

        public TrajectoryController(ITrajectoryRepository trajectoryRepository, IMapper mapper)
        {
            this.trajectoryRepository = trajectoryRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTrajectoriesAsync()
        {
            var trajectories = await trajectoryRepository.GetAllAsync();

            var trajectoriesDto = mapper.Map<List<Trajectory>>(trajectories);

            return Ok(trajectoriesDto);
        }

        [HttpGet]
        [Route("{TrajectoryId:guid}")]
        [ActionName("GetTrajectoriesAsync")]
        public async Task<IActionResult> GetTrajectoriesAsync(Guid TrajectoryId)
        {
            var trajectories = await trajectoryRepository.GetByIdAsync(TrajectoryId);

            if (trajectories == null)
            {
                return NotFound();
            }

            var trajectoriesDto = mapper.Map<Trajectory>(trajectories);

            return Ok(trajectoriesDto);
        }

        [HttpPost]
        public async Task<IActionResult> AddTrajectoryAsync([FromBody] AddTrajectoryRequest addTrajectoryRequest)
        {
            var trajectories = new Models.Domain.Trajectory
            {
                Title = addTrajectoryRequest.Title,
                Body = addTrajectoryRequest.Body,
                FromDate = addTrajectoryRequest.FromDate,
                ToDate = addTrajectoryRequest.ToDate,
                Visibility = addTrajectoryRequest.Visibility,
                Link = addTrajectoryRequest.Link,
                UserId = addTrajectoryRequest.UserId
            };

            trajectories = await trajectoryRepository.AddTrajectoryAsync(trajectories);

            var trajectoriesDto = new Models.Dtos.Trajectory
            {
                TrajectoryId = trajectories.TrajectoryId,
                Title = trajectories.Title,
                Body = trajectories.Body,
                FromDate = trajectories.FromDate,
                ToDate = trajectories.ToDate,
                Visibility = trajectories.Visibility,
                Link = trajectories.Link,
                UserId = trajectories.UserId,
                CreatedAt = trajectories.CreatedAt

            };

            return CreatedAtAction(nameof(GetTrajectoriesAsync), new { trajectoryId = trajectoriesDto.TrajectoryId }, trajectoriesDto);
        }

        [HttpPut]
        [Route("{TrajectoryId:guid}")]
        public async Task<IActionResult> UpdateTrajectoryAsync([FromRoute] Guid TrajectoryId, [FromBody]
        UpdateTrajectoryRequest updateTrajectoryRequest)
        {
            var trajectories = new Models.Domain.Trajectory
            {
                Title = updateTrajectoryRequest.Title,
                Body = updateTrajectoryRequest.Body,
                FromDate = updateTrajectoryRequest.FromDate,
                ToDate = updateTrajectoryRequest.ToDate,
                Visibility = updateTrajectoryRequest.Visibility,
                Link = updateTrajectoryRequest.Link,
                UserId = updateTrajectoryRequest.UserId
            };

            trajectories = await trajectoryRepository.UpdateTrajectoryAsync(TrajectoryId, trajectories);

            if (trajectories == null)
            {
                return NotFound();
            }

            var trajectoriesDto = new Models.Dtos.Trajectory
            {
                TrajectoryId = trajectories.TrajectoryId,
                Title = trajectories.Title,
                Body = trajectories.Body,
                FromDate = trajectories.FromDate,
                ToDate = trajectories.ToDate,
                Visibility = trajectories.Visibility,
                Link = trajectories.Link,
                UserId = trajectories.UserId,
                CreatedAt = trajectories.CreatedAt

            };

            return Ok(trajectoriesDto);
        }

        [HttpDelete]
        [Route("{TrajectoryId:guid}")]
        public async Task<IActionResult> DeleteTrajectoryAsync(Guid TrajectoryId)
        {
            var trajectory = await trajectoryRepository.DeleteTrajectoryAsync(TrajectoryId);

            if (trajectory == null)
            {
                return NotFound();
            }

            var trajectoryDto = mapper.Map<Trajectory>(trajectory);

            return Ok(trajectoryDto);
        }
    }
}
