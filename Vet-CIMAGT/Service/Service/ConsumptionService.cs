using AutoMapper;
using Vet_CIMAGT.Core.DTOs;
using Vet_CIMAGT.Core.Models;
using Vet_CIMAGT.DataLayer.Repositorys;
using Vet_CIMAGT.DataLayer.Repositorys.Interface;
using Vet_CIMAGT.Service.Service.Interface;

namespace Vet_CIMAGT.Service.Service
{
    public class ConsumptionService : IConsumptionService
    {
        private readonly IConsumptionRepository _consumptionRepository;
        private readonly IMapper _mapper;

        public ConsumptionService(IConsumptionRepository consumptionRepository, IMapper mapper)
        {
            _consumptionRepository = consumptionRepository;
            _mapper = mapper;
        }

        public async Task CreateConsumptionAsync(ConsumptionDTOs consumptionDTOs)
        {
            try
            {
                var consumptions = _mapper.Map<Consumption>(consumptionDTOs);
                await _consumptionRepository.AddAsync(consumptions);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al crear el Consumptions: {ex.Message}");
            }
        }

        public async Task DeleteConsumptionAsync(Guid id)
        {
            try
            {
                var existingConsumptions = await _consumptionRepository.GetByIdAsync(id);

                if (existingConsumptions == null)
                {
                    throw new Exception("El Consumptions no existe.");
                }

                await _consumptionRepository.DeleteAsync(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al eliminar el Consumptions: {ex.Message}");
            }
        }

        public async Task<List<ConsumptionDTOs>> GetAllConsumptionsAsync()
        {
            try
            {
                var consumptions = await _consumptionRepository.GetAllAsync();

                if (consumptions == null || !consumptions.Any())
                {
                    throw new Exception("No se encontraron Consumption.");
                }

                return _mapper.Map<List<ConsumptionDTOs>>(consumptions);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener los Consumption: {ex.Message}");
            }
        }

        public async Task<ConsumptionDTOs> GetConsumptionByIdAsync(Guid id)
        {
            try
            {
                var consumption = await _consumptionRepository.GetByIdAsync(id);

                if (consumption == null)
                {
                    throw new Exception("El Consumption no existe.");
                }

                return _mapper.Map<ConsumptionDTOs>(consumption);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener el Consumption: {ex.Message}");
            }
        }

        public async Task UpdateConsumptionAsync(ConsumptionDTOs consumptionDTOs)
        {
            try
            {
                var existingConsumption = await _consumptionRepository.GetByIdAsync(consumptionDTOs.Id);

                if (existingConsumption == null)
                {
                    throw new Exception("El Consumption no existe.");
                }


                _mapper.Map(consumptionDTOs, existingConsumption);


                await _consumptionRepository.UpdateAsync(existingConsumption);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al actualizar el Consumption: {ex.Message}");
            }
        }
    }
}
