using PortfolioApiV1.Models.Domain;

namespace PortfolioApiV1.Repositories
{
    public interface ISkillsRepository
    {
        Task<IEnumerable<TechnicalSkills>> GetAllTechnicalSkillsAsync();
        Task<TechnicalSkills> GetTechnicalSkillsByIdAsync(Guid TechnicalSkillsId);
        Task<TechnicalSkills> AddTechnicalSkillsAsync(TechnicalSkills TechnicalSkills);
        Task<TechnicalSkills> UpdateTechnicalSkillsAsync(Guid TechnicalSkillsId, TechnicalSkills TechnicalSkills);
        Task<TechnicalSkills> DeleteTechnicalSkillsAsync(Guid TechnicalSkillsId);

        Task<IEnumerable<SoftSkills>> GetAllSoftSkillsAsync();
        Task<SoftSkills> GetSoftSkillsByIdAsync(Guid SoftSkillsId);
        Task<SoftSkills> AddSoftSkillsAsync(SoftSkills SoftSkills);
        Task<SoftSkills> UpdateSoftSkillsAsync(Guid SoftSkillsId, SoftSkills SoftSkills);
        Task<SoftSkills> DeleteSoftSkillsAsync(Guid SoftSkillsId);
    }
}
