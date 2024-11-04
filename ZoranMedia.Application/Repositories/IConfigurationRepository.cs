using ZoranMedia.Domain.Entities;

namespace ZoranMedia.Application.Repositories
{
    public interface IConfigurationRepository 
    {
        public Task<Configuration> Add(Configuration configuration);
        public Task<bool> Update(Configuration configuration);
        public Task<bool> Delete(Configuration configuration);
        public Task<IEnumerable<Configuration>> GetAll();
        public Task<Configuration> GetByID(int id);
    }
}
