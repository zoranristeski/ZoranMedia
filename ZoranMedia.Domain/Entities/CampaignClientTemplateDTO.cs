using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZoranMedia.Domain.Entities
{
    public class CampaignClientTemplateDTO
    {
        public int CampaignID { get; set; }
        public string CampaignName { get; set; }
        public DateTime ScheduledTime { get; set; }
        public int TemplateId { get; set; }
        public int ClientID { get; set; }
        public string ClientName { get; set; }
        public string Gender { get; set; }
        public string EmailAddress { get; set; }
        public bool IsSubscribed { get; set; }
        public string TemplateName { get; set; }
        public string FilePath { get; set; }
        public string Content { get; set; }
    }
}
