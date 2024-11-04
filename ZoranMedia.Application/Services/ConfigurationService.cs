using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZoranMedia.Application.Repositories;
using ZoranMedia.Domain.Entities;
using ZoranMedia.Domain.Interfaces;

namespace ZoranMedia.Application.Services
{
    public class ConfigurationService : IConfigurationService
    {
        private readonly IConfigurationRepository _configurationRepository;
        public ConfigurationService(IConfigurationRepository configurationRepository)
        {
            _configurationRepository = configurationRepository;
        }

        public async Task CreateConfigurationAsync(Configuration configuration)
        {
            await _configurationRepository.Add(configuration);
        }

        public async Task<IEnumerable<Configuration>> GetAllConfigurationsAsync()
        {
           return await _configurationRepository.GetAll();
        }

        public async Task<Configuration> GetConfigurationAsync(int configurationId)
        {
            return await _configurationRepository.GetByID(configurationId);
        }
    }
}
