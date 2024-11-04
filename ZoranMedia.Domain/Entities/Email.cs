using System.ComponentModel.DataAnnotations;
using ZoranMedia.Domain.Entities.Enums;

namespace ZoranMedia.Domain.Entities
{
    public class Email
    {
        [Key]
        public int EmailID { get; set; }
        public int ClientID { get; set; }
        public int CampaignId { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public DateTime SentDate { get; set; }
        public EmailStatus Status { get; set; }

        public Client Client { get; set; }
        public Campaign Campaign { get; set; }
    }
}
