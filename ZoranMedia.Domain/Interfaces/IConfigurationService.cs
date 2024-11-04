
using ZoranMedia.Domain.Entities;

namespace ZoranMedia.Domain.Interfaces
{
    public interface IConfigurationService
    {
        Task<Configuration> GetConfigurationAsync(int clientId);
        Task<IEnumerable<Configuration>> GetAllConfigurationsAsync();
        Task CreateConfigurationAsync(Configuration configuration);
    }
}
