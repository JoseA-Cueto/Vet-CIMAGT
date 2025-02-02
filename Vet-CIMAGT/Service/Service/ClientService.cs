using AutoMapper;
using Vet_CIMAGT.Core.DTOs;
using Vet_CIMAGT.Core.Models;
using Vet_CIMAGT.DataLayer.Repositorys.Interface;
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

        public async Task DeleteClientAsync(Guid id)
        {
            try
            {
                var existingClient = await _clientRepository.GetByIdAsync(id);

                if (existingClient == null)
                {
                    throw new Exception("El cliente no existe.");
                }

                await _clientRepository.DeleteAsync(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al eliminar el cliente: {ex.Message}");
            }
        }

        public async Task<List<ClientDTOs>> GetAllClientsAsync()
        {
            try
            {
                var clients = await _clientRepository.GetAllAsync();

                if (clients == null || !clients.Any())
                {
                    throw new Exception("No se encontraron clientes.");
                }

                return _mapper.Map<List<ClientDTOs>>(clients);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener los clientes: {ex.Message}");
            }
        }

        public async Task<ClientDTOs> GetClientByIdAsync(Guid id)
        {
            try
            {
                var client = await _clientRepository.GetByIdAsync(id);

                if (client == null)
                {
                    throw new Exception("El cliente no existe.");
                }

                return _mapper.Map<ClientDTOs>(client);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener el cliente: {ex.Message}");
            }
        }

        public async Task CreateCLientAsync(ClientDTOs clientDto)
        {
            try
            {
                    var client = _mapper.Map<Client>(clientDto);
                await _clientRepository.AddAsync(client);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al crear el cliente: {ex.Message}");
            }
        }

        public async Task UpdateClientAsync(ClientDTOs clientDto)
        {
            try
            {
                var existingClient = await _clientRepository.GetByIdAsync(clientDto.Id);

                if (existingClient == null)
                {
                    throw new Exception("El cliente no existe.");
                }

              
                _mapper.Map(clientDto, existingClient);

              
                await _clientRepository.UpdateAsync(existingClient);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al actualizar el cliente: {ex.Message}");
            }
        }
    }
}

