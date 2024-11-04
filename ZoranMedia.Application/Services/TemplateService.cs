using ZoranMedia.Application.Repositories;
using ZoranMedia.Domain.Entities;
using ZoranMedia.Domain.Interfaces;

namespace ZoranMedia.Application.Services
{
    internal class TemplateService : ITemplateService
    {
        
        private readonly ITemplateRepository _templateRepository;

        public TemplateService(ITemplateRepository templateRepository)
        {
            _templateRepository = templateRepository;
        }

        public async Task CreateTemplateAsync(Template template)
        {
            await _templateRepository.Add(template);
        }

        public Task DeleteTemplateAsync(int templateId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Template>> GetAllTemplatesAsync()
        {
            return await _templateRepository.GetAll();
        }
        public async Task<Template> GetTemplateByIdAsync(int templateId)
        {
            return await _templateRepository.GetByID(templateId);
        }

        public async Task<Template> GetOrCreateTemplateAsync(int templateId, string templateName, string marketingData)
        {
            var existingTemplate = await _templateRepository.GetByID(templateId);

            if (existingTemplate != null)
            {
                return existingTemplate;
            }

            var newTemplate = new Template
            {
                TemplateID = templateId,
                Name = templateName,
                Content = marketingData
            };

            await _templateRepository.Add(newTemplate);

            return newTemplate;
        }

        public Task UpdateTemplateAsync(Template template)
        {
            throw new NotImplementedException();
        }
    }
}
