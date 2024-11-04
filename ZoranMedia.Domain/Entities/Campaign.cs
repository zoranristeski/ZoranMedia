using System.ComponentModel.DataAnnotations;

namespace ZoranMedia.Domain.Entities
{
    public class Campaign
    {
        [Key]
        public int CampaignID { get; set; }

        [StringLength(maximumLength: 100)]
        public string Name { get; set; }
        public DateTime ScheduledTime { get; set; }
        public int TemplateId { get; set; }


        public ICollection<Client> Clients { get; set; } = new List<Client>();
        public Template Template { get; set; }
        public ICollection<Email> Emails { get; set; } = new List<Email>();
    }
}
