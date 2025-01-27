using Vet_CIMAGT.Core.DTOs;

namespace Vet_CIMAGT.Service.Service.Interface
{
  
    public interface IClientService
    {
        Task<List<ClientDTOs>> GetAllClientsAsync();
        Task<ClientDTOs> GetClientByIdAsync(Guid id);
        Task CreateCLientAsync(ClientDTOs clientDTOs);
        Task UpdateClientAsync(Guid Id, ClientDTOs clientDTOs);
        Task DeleteClientAsync(Guid id);
    }
}
