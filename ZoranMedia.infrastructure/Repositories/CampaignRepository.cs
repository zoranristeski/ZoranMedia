using Microsoft.EntityFrameworkCore;
using ZoranMedia.Application.Repositories;
using ZoranMedia.Domain.Entities;

namespace ZoranMedia.Infrastructure.Repositories
{
    public class CampaignRepository : ICampaignRepository
    {
        private readonly ZoranMediaDataContext _context;
        public CampaignRepository(ZoranMediaDataContext context)
        {
            _context = context;
        }
        public async Task<Campaign> Add(Campaign campaign)
        {
            await _context.AddAsync(campaign);
            await _context.SaveChangesAsync();
            return campaign;
        }

        public async Task<bool> Delete(Campaign campaign)
        {
            try
            {
                _context.Campaigns.Remove(campaign);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex) { return false; }
        }

        public async Task<IEnumerable<Campaign>> GetAll()
        {
            return await _context.Campaigns.ToListAsync();
        }

        public async Task<IEnumerable<CampaignClientTemplateDTO>> GetAllCampaignsTemplateByClientIDAsync(int clientID)
        {
            var query = await _context.Clients
                .Where(c => c.ClientID == clientID)
                .SelectMany(c => c.Campaigns.Select(cam => new CampaignClientTemplateDTO
                {
                    CampaignID = cam.CampaignID,
                    CampaignName = cam.Name,
                    ScheduledTime = cam.ScheduledTime,
                    TemplateId = cam.TemplateId,
                    TemplateName = cam.Template.Name,
                    FilePath = cam.Template.FilePath,
                    Content = cam.Template.Content,
                    ClientID = c.ClientID,
                    ClientName = c.Name,
                    Gender = c.Gender,
                    EmailAddress = c.EmailAddress,
                    IsSubscribed = c.IsSubscribed
                })).ToListAsync();
            return query.ToList();
        }

        public async Task<Campaign> GetByID(int id)
        {
            return await _context.Campaigns.Where(e => e.CampaignID == id).FirstOrDefaultAsync();
        }

        public async Task<bool> Update(Campaign campaign)
        {
            try
            {
                _context.Update(campaign);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
