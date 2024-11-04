using ZoranMedia.Domain.Entities;

namespace ZoranMedia.Domain.Interfaces
{
    public interface IClientService
    {
        Task CreateClientAsync(Client client);
        Task<IEnumerable<Client>> GetAllClientsAsync();

        Task <IEnumerable<Client>> GetClientsByGenderAsync(string gender);
    }
}
