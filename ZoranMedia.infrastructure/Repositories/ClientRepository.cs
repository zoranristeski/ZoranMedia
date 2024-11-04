using Microsoft.EntityFrameworkCore;
using ZoranMedia.Application.Repositories;
using ZoranMedia.Domain.Entities;


namespace ZoranMedia.Infrastructure.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly ZoranMediaDataContext _context;
        public ClientRepository(ZoranMediaDataContext context)
        {
            _context = context;
        }
        public async Task<Client> Add(Client client)
        {
            await _context.AddAsync(client);
            await _context.SaveChangesAsync();
            return client;
        }

        public async Task<bool> Delete(Client client)
        {
            try
            {
                _context.Clients.Remove(client);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex) { return false; }
        }

        public async Task<IEnumerable<Client>> GetAll()
        {
            return await _context.Clients.ToListAsync();
        }

        public async Task<IEnumerable<Client>> GetByGender(string gender)
        {
            return await _context.Clients.Where(c => c.Gender == gender).ToListAsync();
        }

        public async Task<Client> GetByID(int id)
        {
            return await _context.Clients.Where(e => e.ClientID == id).FirstOrDefaultAsync();
        }

        public async Task<bool> Update(Client client)
        {
            try
            {
                _context.Update(client);
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
