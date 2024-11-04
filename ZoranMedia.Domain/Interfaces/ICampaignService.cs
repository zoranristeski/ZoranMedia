using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZoranMedia.Domain.Entities;

namespace ZoranMedia.Domain.Interfaces
{
    public interface ICampaignService
    {
        Task CreateCampaignAsync(Campaign campaign);
        Task<IEnumerable<Campaign>> GetAllCampaignsAsync();
        Task<IEnumerable<CampaignClientTemplateDTO>> GetAllCampaignsTemplateByClientIDAsync(int clientID);
    }
}
