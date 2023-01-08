using Microsoft.EntityFrameworkCore;
using PortfolioApiV1.Data;
using PortfolioApiV1.Models.Domain;
using System.Collections.Immutable;

namespace PortfolioApiV1.Repositories
{
    public class SkillsRepository: ISkillsRepository
    {
        private readonly PortfolioDbContext portfolioDbContext;

        public SkillsRepository(PortfolioDbContext portfolioDbContext)
        {
            this.portfolioDbContext = portfolioDbContext;
        }

        public async Task<SoftSkills> AddSoftSkillsAsync(SoftSkills SoftSkills)
        {
            SoftSkills.SoftSkillsId = Guid.NewGuid();

            await portfolioDbContext.AddAsync(SoftSkills);
            await portfolioDbContext.SaveChangesAsync();

            return SoftSkills;
        }

        public async Task<TechnicalSkills> AddTechnicalSkillsAsync(TechnicalSkills TechnicalSkills)
        {
            TechnicalSkills.TechnicalSkillsId = Guid.NewGuid();

            await portfolioDbContext.AddAsync(TechnicalSkills);
            await portfolioDbContext.SaveChangesAsync();

            return TechnicalSkills;
        }

        public async Task<SoftSkills> DeleteSoftSkillsAsync(Guid SoftSkillsId)
        {
            var existingSoftSkill = await portfolioDbContext.SoftSkills.FindAsync(SoftSkillsId);

            if(existingSoftSkill == null)
            {
                return null;
            }

            portfolioDbContext.SoftSkills.Remove(existingSoftSkill);
            await portfolioDbContext.SaveChangesAsync();

            return existingSoftSkill;
        }

        public async Task<TechnicalSkills> DeleteTechnicalSkillsAsync(Guid TechnicalSkillsId)
        {
            var existingTechnicalSkills = await portfolioDbContext.TechnicalSkills.FindAsync(TechnicalSkillsId);

            if (existingTechnicalSkills == null)
            {
                return null;
            }

            portfolioDbContext.TechnicalSkills.Remove(existingTechnicalSkills);
            await portfolioDbContext.SaveChangesAsync();

            return existingTechnicalSkills;
        }

        public async Task<IEnumerable<SoftSkills>> GetAllSoftSkillsAsync()
        {
            return await portfolioDbContext.SoftSkills
                .Include(x => x.Users)
                .ToListAsync();
        }

        public async Task<IEnumerable<TechnicalSkills>> GetAllTechnicalSkillsAsync()
        {
            return await portfolioDbContext.TechnicalSkills
                .Include(x => x.Users)
                .ToListAsync();
        }

        public async Task<SoftSkills> GetSoftSkillsByIdAsync(Guid SoftSkillsId)
        {
            return await portfolioDbContext.SoftSkills
                .Include(x => x.Users)
                .FirstOrDefaultAsync(x => x.SoftSkillsId == SoftSkillsId);
        }

        public async Task<TechnicalSkills> GetTechnicalSkillsByIdAsync(Guid TechnicalSkillsId)
        {
            return await portfolioDbContext.TechnicalSkills
                .Include(x => x.Users)
                .FirstOrDefaultAsync(x => x.TechnicalSkillsId == TechnicalSkillsId);
        }

        public async Task<SoftSkills> UpdateSoftSkillsAsync(Guid SoftSkillsId, SoftSkills SoftSkills)
        {
            var existingSoftSkill = await portfolioDbContext.SoftSkills.FindAsync(SoftSkillsId);

            if (existingSoftSkill != null)
            {
                existingSoftSkill.Name = SoftSkills.Name;

                await portfolioDbContext.SaveChangesAsync();

                return existingSoftSkill;
            }

            return null;
        }

        public async Task<TechnicalSkills> UpdateTechnicalSkillsAsync(Guid TechnicalSkillsId, TechnicalSkills TechnicalSkills)
        {
            var existingTechnicalSkill = await portfolioDbContext.TechnicalSkills.FindAsync(TechnicalSkillsId);

            if (existingTechnicalSkill != null)
            {
                existingTechnicalSkill.Name = TechnicalSkills.Name;
                existingTechnicalSkill.Experience = TechnicalSkills.Experience;

                await portfolioDbContext.SaveChangesAsync();

                return existingTechnicalSkill;
            }

            return null;
        }
    }
}
