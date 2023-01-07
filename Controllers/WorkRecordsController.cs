using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PortfolioApiV1.Models.Dtos;
using PortfolioApiV1.Repositories;
using PortfolioApiV1.Repositories.WorkRecords;

namespace PortfolioApiV1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WorkRecordsController : Controller
    {
        private readonly IWorkRecordsRepository workRecordsRepository;
        private readonly IMapper mapper;

        public WorkRecordsController(IWorkRecordsRepository workRecordsRepository, IMapper mapper)
        {
            this.workRecordsRepository = workRecordsRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllWorkRecordsAsync()
        {
            var workRecords = await workRecordsRepository.GetAllAsync();

            var WorkRecordsDto = mapper.Map<List<Models.Dtos.WorkRecords>>(workRecords);

            return Ok(WorkRecordsDto);
        }

        [HttpGet]
        [Route("{WorkRecordId:guid}")]
        [ActionName("GetWorkRecordAsync")]
        public async Task<IActionResult> GetWorkRecordAsync(Guid WorkRecordId)
        {
            var workRecord = await workRecordsRepository.GetByIdAsync(WorkRecordId);

            if (workRecord == null)
            {
                return NotFound();
            }

            var workRecordsDto = mapper.Map<Models.Dtos.WorkRecords>(workRecord);

            return Ok(workRecordsDto);
        }

        [HttpPost]
        public async Task<IActionResult> AddWorkRecordAsync([FromBody] AddWorkRecordRequest addWorkRecordRequest)
        {
            var workRecord = new Models.Domain.WorkRecord
            {
                Title = addWorkRecordRequest.Title,
                FromDate = addWorkRecordRequest.FromDate,
                ToDate = addWorkRecordRequest.ToDate,
                IsEnded = addWorkRecordRequest.IsEnded,
                UserId = addWorkRecordRequest.UserId
            };

            workRecord = await workRecordsRepository.AddWorkRecordAsync(workRecord);

            var workRecordsDto = new Models.Dtos.WorkRecords
            {
                WorkRecordId = workRecord.WorkRecordId,
                Title = workRecord.Title,
                FromDate = workRecord.FromDate,
                ToDate = workRecord.ToDate,
                IsEnded = workRecord.IsEnded,
                UserId = workRecord.UserId,
                CreatedAt = workRecord.CreatedAt
            };

            return CreatedAtAction(nameof(GetWorkRecordAsync), new { WorkRecordId = workRecordsDto.WorkRecordId }, workRecordsDto);
        }

        [HttpPut]
        [Route("{WorkRecordId:guid}")]
        public async Task<IActionResult> UpdateWorkRecordAsync([FromRoute] Guid WorkRecordId, [FromBody]
        Models.Dtos.UpdateWorkRecordRequest updateWorkRecordRequest)
        {
            var workRecord = new Models.Domain.WorkRecord
            {
                Title = updateWorkRecordRequest.Title,
                FromDate = updateWorkRecordRequest.FromDate,
                ToDate = updateWorkRecordRequest.ToDate,
                IsEnded = updateWorkRecordRequest.IsEnded,
                UserId = updateWorkRecordRequest.UserId
            };

            workRecord = await workRecordsRepository.UpdateWorkRecordAsync(WorkRecordId, workRecord);

            if (workRecord == null)
            {
                return NotFound();
            }

            var workRecordDto = new Models.Dtos.WorkRecords
            {
                WorkRecordId = workRecord.WorkRecordId,
                Title = workRecord.Title,
                FromDate = workRecord.FromDate,
                ToDate = workRecord.ToDate,
                IsEnded = workRecord.IsEnded,
                UserId = workRecord.UserId,
                CreatedAt = workRecord.CreatedAt
            };

            return Ok(workRecordDto);
        }

        [HttpDelete]
        [Route("{WorkRecordId:guid}")]
        public async Task<IActionResult> DeleteWorkRecordAsync(Guid WorkRecordId)
        {
            var workRecord = await workRecordsRepository.DeleteWorkRecordAsync(WorkRecordId);

            if (workRecord == null)
            {
                return NotFound();
            }

            var workRecordDto = mapper.Map<Models.Dtos.WorkRecords>(workRecord);

            return Ok(workRecordDto);
        }
    }
}
