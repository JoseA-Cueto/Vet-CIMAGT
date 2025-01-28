using Vet_CIMAGT.Core.DTOs;

namespace Vet_CIMAGT.Service.Service.Interface
{
    public interface IConsumptionService
    {
        Task<List<ConsumptionDTOs>> GetAllConsumptionsAsync();
        Task<ConsumptionDTOs> GetConsumptionByIdAsync(Guid id);
        Task CreateConsumptionAsync(ConsumptionDTOs consumptionDTOs);
        Task UpdateConsumptionAsync(ConsumptionDTOs consumptionDTOs);
        Task DeleteConsumptionAsync(Guid id);
    }
}
