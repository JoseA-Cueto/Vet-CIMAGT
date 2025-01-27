using AutoMapper;
using Vet_CIMAGT.Core.DTOs;
using Vet_CIMAGT.Core.Models;

namespace Vet_CIMAGT.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Configuración del mapeo 
            CreateMap<Client, ClientDTOs>().ReverseMap();
            CreateMap<Patient, PatientDTOs>().ReverseMap();
            CreateMap<Procedure, ProcedureDTOs>().ReverseMap();
            CreateMap<Consumption, ConsumptionDTOs>().ReverseMap();

        }
    }
}
