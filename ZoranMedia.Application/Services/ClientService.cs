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
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;
        public ClientService(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }
        public async Task CreateClientAsync(Client client)
        {
            await _clientRepository.Add(client);
        }

        public async Task<IEnumerable<Client>> GetAllClientsAsync()
        {
            return await _clientRepository.GetAll();
        }

        public async Task<IEnumerable<Client>> GetClientsByGenderAsync(string gender)
        {
            return await _clientRepository.GetByGender(gender);
        }
    }
}
