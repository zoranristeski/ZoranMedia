using Microsoft.EntityFrameworkCore;
using ZoranMedia.Application.Repositories;
using ZoranMedia.Domain.Entities;

namespace ZoranMedia.Infrastructure.Repositories
{
    public class ConfigurationRepository : IConfigurationRepository
    {
        private readonly ZoranMediaDataContext _context;
        public ConfigurationRepository(ZoranMediaDataContext context)
        {
            _context = context;
        }
        public async Task<Configuration> Add(Configuration configuration)
        {
            await _context.AddAsync(configuration);
            await _context.SaveChangesAsync();
            return configuration;
        }

        public async Task<bool> Delete(Configuration configuration)
        {
            try
            {
                _context.Configurations.Remove(configuration);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex) { return false; }
        }

        public async Task<IEnumerable<Configuration>> GetAll()
        {
            return await _context.Configurations.ToListAsync();
        }

        public async Task<Configuration> GetByID(int id)
        {
            return await _context.Configurations.Where(e => e.ConfigurationID == id).FirstOrDefaultAsync();
        }

        public async Task<bool> Update(Configuration configuration)
        {
            try
            {
                _context.Update(configuration);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
