using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PortfolioApiV1.Models.Domain;
using PortfolioApiV1.Models.Dtos;
using PortfolioApiV1.Repositories;

namespace PortfolioApiV1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SkillsController : Controller
    {
        private readonly ISkillsRepository skillsRepository;
        private readonly IMapper mapper;

        public SkillsController(ISkillsRepository skillsRepository, IMapper mapper)
        {
            this.skillsRepository = skillsRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        [Route("soft")]
        public async Task<IActionResult> GetAllSoftSkillsAsync()
        {
            var softSkills = await skillsRepository.GetAllSoftSkillsAsync();

            var softSkillsDto = mapper.Map<List<Models.Dtos.SoftSkills>>(softSkills);

            return Ok(softSkillsDto);
        }

        [HttpGet]
        [Route("technical")]
        public async Task<IActionResult> GetAllTechnicalSkillsAsync()
        {
            var technicalSkills = await skillsRepository.GetAllTechnicalSkillsAsync();

            var technicalSkillsDto = mapper.Map<List<Models.Dtos.TechnicalSkills>>(technicalSkills);

            return Ok(technicalSkillsDto);
        }

        [HttpGet]
        [Route("soft/id/{SoftSkillsId:guid}")]
        [ActionName("GetSoftSkillsAsync")]
        public async Task<IActionResult> GetSoftSkillsAsync(Guid SoftSkillsId)
        {
            var softSkills = await skillsRepository.GetSoftSkillsByIdAsync(SoftSkillsId);

            if (softSkills == null)
            {
                return NotFound();
            }

            var softSkillsDto = mapper.Map<Models.Dtos.SoftSkills>(softSkills);

            return Ok(softSkillsDto);
        }

        [HttpGet]
        [Route("technical/id/{TechnicalSkillsId:guid}")]
        [ActionName("GetTechnicalSkillsAsync")]
        public async Task<IActionResult> GetTechnicalSkillsAsync(Guid TechnicalSkillsId)
        {
            var technicalSkills = await skillsRepository.GetTechnicalSkillsByIdAsync(TechnicalSkillsId);

            if (technicalSkills == null)
            {
                return NotFound();
            }

            var technicalSkillsDto = mapper.Map<Models.Dtos.TechnicalSkills>(technicalSkills);

            return Ok(technicalSkillsDto);
        }

        [HttpPost]
        [Route("add/soft")]
        public async Task<IActionResult> AddSoftSkillsAsync([FromBody] AddSoftSkillsRequest addSoftSkillsRequest)
        {
            var softSkills = new Models.Domain.SoftSkills
            {
                Name = addSoftSkillsRequest.Name
            };

            softSkills = await skillsRepository.AddSoftSkillsAsync(softSkills);

            var softSkillsDto = new Models.Dtos.SoftSkills
            {
                SoftSkillsId = softSkills.SoftSkillsId,
                Name = softSkills.Name
            };

            return CreatedAtAction(nameof(GetSoftSkillsAsync), new { SoftSkillsId = softSkillsDto.SoftSkillsId }, softSkillsDto);
        }

        [HttpPost]
        [Route("add/technical")]
        public async Task<IActionResult> AddTechnicallSkillsAsync([FromBody] AddTechnicalSkillsRequest addTechnicalSkillsRequest)
        {
            var technicalSkill = new Models.Domain.TechnicalSkills
            {
                Name = addTechnicalSkillsRequest.Name,
                Experience = addTechnicalSkillsRequest.Experience
            };

            technicalSkill = await skillsRepository.AddTechnicalSkillsAsync(technicalSkill);

            var technicalSkillsDto = new Models.Dtos.TechnicalSkills
            {
                TechnicalSkillsId = technicalSkill.TechnicalSkillsId,
                Name = technicalSkill.Name,
                Experience = technicalSkill.Experience
            };

            return CreatedAtAction(nameof(GetTechnicalSkillsAsync), new { TechnicalSkillsId = technicalSkillsDto.TechnicalSkillsId }, technicalSkillsDto);
        }
    }
}
