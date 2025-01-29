using AutoMapper;
using Vet_CIMAGT.Core.DTOs;
using Vet_CIMAGT.Core.Models;
using Vet_CIMAGT.DataLayer.Repositorys;
using Vet_CIMAGT.DataLayer.Repositorys.Interface;
using Vet_CIMAGT.Service.Service.Interface;

namespace Vet_CIMAGT.Service.Service
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository _patientRepository;
        private readonly IMapper _mapper;

        public PatientService(IPatientRepository patientRepository, IMapper mapper)
        {
            _patientRepository = patientRepository;
            _mapper = mapper;
        }

        public async Task CreatePatientAsync(PatientDTOs patientDTOs)
        {
            try
            {
                var patients = _mapper.Map<Patient>(patientDTOs);
                await _patientRepository.AddAsync(patients);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al crear el Patient: {ex.Message}");
            }
        }

        public async Task DeletePatientAsync(Guid id)
        {
            try
            {
                var existingPatients = await _patientRepository.GetByIdAsync(id);

                if (existingPatients == null)
                {
                    throw new Exception("El Patient no existe.");
                }

                await _patientRepository.DeleteAsync(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al eliminar el Patient: {ex.Message}");
            }
        }

        public async Task<List<PatientDTOs>> GetAllPatientsAsync()
        {
            try
            {
                var patients = await _patientRepository.GetAllAsync();

                if (patients == null || !patients.Any())
                {
                    throw new Exception("No se encontraron patients.");
                }

                return _mapper.Map<List<PatientDTOs>>(patients);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener los patients: {ex.Message}");
            }
        }

        public async Task<PatientDTOs> GetPatientByIdAsync(Guid id)
        {
            try
            {
                var patients = await _patientRepository.GetByIdAsync(id);

                if (patients == null)
                {
                    throw new Exception("El patients no existe.");
                }

                return _mapper.Map<PatientDTOs>(patients);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener el patients: {ex.Message}");
            }
        }

        public async Task UpdatePatientAsync(PatientDTOs patientDTOs)
        {
            try
            {
                var existingPatients = await _patientRepository.GetByIdAsync(patientDTOs.Id);

                if (existingPatients == null)
                {
                    throw new Exception("El patients no existe.");
                }


                _mapper.Map(patientDTOs, existingPatients);


                await _patientRepository.UpdateAsync(existingPatients);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al actualizar el patients: {ex.Message}");
            }
        }
    }
}
