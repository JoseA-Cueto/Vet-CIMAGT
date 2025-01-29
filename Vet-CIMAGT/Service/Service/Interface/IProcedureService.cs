using Vet_CIMAGT.Core.DTOs;

namespace Vet_CIMAGT.Service.Service.Interface
{
    public interface IProcedureService
    {
        Task<List<ProcedureDTOs>> GetAllProceduresAsync();
        Task<ProcedureDTOs> GetProcedureByIdAsync(Guid id);
        Task CreateProcedureAsync(ProcedureDTOs procedureDTOs);
        Task UpdateProcedureAsync(ProcedureDTOs procedureDTOs);
        Task DeleteProcedureAsync(Guid id);
    }
}

