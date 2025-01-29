using AutoMapper;
using Vet_CIMAGT.Core.DTOs;
using Vet_CIMAGT.Core.Models;
using Vet_CIMAGT.DataLayer.Repositorys.Interface;
using Vet_CIMAGT.Service.Service.Interface;

namespace Vet_CIMAGT.Service.Service
{
    public class ProcedureService : IProcedureService
    {
        private readonly IProcedureRepository _procedureRepository;
        private readonly IMapper _mapper;

        public ProcedureService(IProcedureRepository procedureRepository, IMapper mapper)
        {
            _procedureRepository = procedureRepository;
            _mapper = mapper;
        }

        public async Task<List<ProcedureDTOs>> GetAllProceduresAsync()
        {
            try
            {
                var procedures = await _procedureRepository.GetAllAsync();

                if (procedures == null || !procedures.Any())
                {
                    throw new Exception("No se encontraron procedimientos.");
                }

                return _mapper.Map<List<ProcedureDTOs>>(procedures);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener los procedimientos: {ex.Message}");
            }
        }

        public async Task<ProcedureDTOs> GetProcedureByIdAsync(Guid id)
        {
            try
            {
                var procedure = await _procedureRepository.GetByIdAsync(id);

                if (procedure == null)
                {
                    throw new Exception("El procedimiento no existe.");
                }

                return _mapper.Map<ProcedureDTOs>(procedure);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener el procedimiento: {ex.Message}");
            }
        }

        public async Task CreateProcedureAsync(ProcedureDTOs procedureDTOs)
        {
            try
            {
                var procedure = _mapper.Map<Procedure>(procedureDTOs);
                await _procedureRepository.AddAsync(procedure);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al crear el procedimiento: {ex.Message}");
            }
        }

        public async Task UpdateProcedureAsync(ProcedureDTOs procedureDTOs)
        {
            try
            {
                var existingProcedure = await _procedureRepository.GetByIdAsync(procedureDTOs.Id);

                if (existingProcedure == null)
                {
                    throw new Exception("El procedimiento no existe.");
                }

                _mapper.Map(procedureDTOs, existingProcedure);

                await _procedureRepository.UpdateAsync(existingProcedure);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al actualizar el procedimiento: {ex.Message}");
            }
        }

        public async Task DeleteProcedureAsync(Guid id)
        {
            try
            {
                var existingProcedure = await _procedureRepository.GetByIdAsync(id);

                if (existingProcedure == null)
                {
                    throw new Exception("El procedimiento no existe.");
                }

                await _procedureRepository.DeleteAsync(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al eliminar el procedimiento: {ex.Message}");
            }
        }
    }
}

