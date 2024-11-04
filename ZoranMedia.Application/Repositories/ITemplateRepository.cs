
using ZoranMedia.Domain.Entities;

namespace ZoranMedia.Application.Repositories
{ 
    public interface ITemplateRepository
    {
        public Task<Template> Add(Template template);
        public Task<bool> Update(Template template);
        public Task<bool> Delete(Template template);
        public Task<IEnumerable<Template>> GetAll();
        public Task<Template> GetByID(int id);
    }
}
