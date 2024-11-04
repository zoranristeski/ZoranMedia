using System.ComponentModel.DataAnnotations;

namespace ZoranMedia.Domain.Entities
{
    public class Client
    {
        [Key]
        public int ClientID { get; set; } 

        [StringLength(maximumLength: 100)]
        public string Name { get; set; }
        public string  Gender { get; set; }
        public string EmailAddress { get; set; }
        public bool IsSubscribed { get; set; }

        public ICollection<Campaign> Campaigns { get; set; } = new List<Campaign>();
        public ICollection<Configuration> Configurations { get; set; } = new List<Configuration>();
    }
}
