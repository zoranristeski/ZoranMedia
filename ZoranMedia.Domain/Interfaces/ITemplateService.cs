using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZoranMedia.Domain.Entities;

namespace ZoranMedia.Domain.Interfaces
{
    public interface ITemplateService
    {
        Task<Template> GetTemplateByIdAsync(int templateId);
        Task<IEnumerable<Template>> GetAllTemplatesAsync();
        Task CreateTemplateAsync(Template template);
        Task UpdateTemplateAsync(Template template);
        Task DeleteTemplateAsync(int templateId);
        Task<Template> GetOrCreateTemplateAsync(int templateId, string templateName, string marketingData);
    }
}
