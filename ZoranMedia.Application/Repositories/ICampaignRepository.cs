using ZoranMedia.Domain.Entities;

namespace ZoranMedia.Application.Repositories
{
    public interface ICampaignRepository
    {
        public Task<Campaign> Add(Campaign campaign);
        public Task<bool> Update(Campaign campaign);
        public Task<bool> Delete(Campaign campaign);
        public Task<IEnumerable<Campaign>> GetAll();
        public Task<Campaign> GetByID(int id);
        public Task<IEnumerable<CampaignClientTemplateDTO>> GetAllCampaignsTemplateByClientIDAsync(int clientID);
    }
}
