using System.ComponentModel.DataAnnotations;


namespace ZoranMedia.Domain.Entities
{
    public class Template
    {
        [Key]
        public int TemplateID { get; set; }

        [StringLength(maximumLength: 100)]
        public string Name { get; set; }
        public string FilePath { get; set; }
        public string Content { get; set; }

        public Campaign Campaign { get; set; }
    }
}
