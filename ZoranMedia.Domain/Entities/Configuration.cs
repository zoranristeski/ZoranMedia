using System.ComponentModel.DataAnnotations;


namespace ZoranMedia.Domain.Entities
{
    public class Configuration
    {
        [Key]
        public int ConfigurationID { get; set; }
        public int ClientID { get; set; }
        public Client Client { get; set; }
        public bool ReceiveMarketingEmails { get; set; }
        public string Frequency { get; set; } //  Daily, Weekly, Monthly
        public DateTime? PreferredSendTime { get; set; }
    }
}
