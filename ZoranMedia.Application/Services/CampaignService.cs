using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZoranMedia.Application.Repositories;
using ZoranMedia.Domain.Entities;
using ZoranMedia.Domain.Interfaces;

namespace ZoranMedia.Application.Services
{
    public class CampaignService : ICampaignService
    {
        private readonly ICampaignRepository _campaignRepository;
        public CampaignService(ICampaignRepository campaignRepository)
        {
           _campaignRepository = campaignRepository;
        }
        public Task CreateCampaignAsync(Campaign campaign)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Campaign>> GetAllCampaignsAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<CampaignClientTemplateDTO>> GetAllCampaignsTemplateByClientIDAsync(int clientID)
        {
            return await _campaignRepository.GetAllCampaignsTemplateByClientIDAsync(clientID);
        }
    }
}
