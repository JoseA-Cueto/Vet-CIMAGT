using Vet_CIMAGT.Core.DTOs;

namespace Vet_CIMAGT.Service.Service.Interface
{
    public interface IPatientService
    {
        Task<List<PatientDTOs>> GetAllPatientsAsync();
        Task<PatientDTOs> GetPatientByIdAsync(Guid id);
        Task CreatePatientAsync(PatientDTOs patientDTOs);
        Task UpdatePatientAsync(PatientDTOs patientDTOs);
        Task DeletePatientAsync(Guid id);
    }
}
