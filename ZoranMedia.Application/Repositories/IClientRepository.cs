using ZoranMedia.Domain.Entities;

namespace ZoranMedia.Application.Repositories
{
    public interface IClientRepository
    {
        public Task<Client> Add(Client client);
        public Task<bool> Update(Client client);
        public Task<bool> Delete(Client client);
        public Task<IEnumerable<Client>> GetAll();
        public Task<IEnumerable<Client>> GetByGender(string gender);

        public Task<Client> GetByID(int id);

    }
}

