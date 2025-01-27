using AutoMapper;
using Vet_CIMAGT.Core.DTOs;
using Vet_CIMAGT.Core.Models;
using Vet_CIMAGT.DataLayer.Repositorys.IClientRepository;
using Vet_CIMAGT.Service.Service.Interface;

namespace Vet_CIMAGT.Service.Service
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;
        private readonly IMapper _mapper;

        public ClientService(IClientRepository clientRepository, IMapper mapper)
        {
            _clientRepository = clientRepository;
            _mapper = mapper;
        }

        public async Task DeleteArticleAsync(Guid id)
        {
            await _clientRepository.DeleteAsync(id);
        }

        public async Task<List<ClientDTOs>> GetAllArticlesAsync()
        {
            var client = await _clientRepository.GetAllAsync();
            return _mapper.Map<List<ClientDTOs>>(client);
        }

        public async Task<ClientDTOs> GetArticleByIdAsync(Guid id)
        {
            var client = await _clientRepository.GetByIdAsync(id);
            return _mapper.Map<ClientDTOs>(client);
        }

        public async Task CreateArticleAsync(ClientDTOs clientDto)
        {
            var client = _mapper.Map<Client>(clientDto);
            await _clientRepository.AddAsync(client);
        }

        public async Task UpdateArticleAsync(Guid Id, ClientDTOs clientDto)
        {
            var existingClient = await _clientRepository.GetByIdAsync(Id);
            await _clientRepository.UpdateAsync(existingClient);
        }
    }
}
