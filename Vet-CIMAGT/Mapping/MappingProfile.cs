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

            // Mapeo de User
            CreateMap<User, UserDTOs>().ReverseMap();
            CreateMap<UserCreateDTO, User>().ReverseMap();  // Para la creación de usuarios
            CreateMap<UserUpdateDTO, User>().ReverseMap();  // Para la actualización de usuarios

            // Si es necesario el mapeo de LoginDTO
            // Pero generalmente no se mapea, solo se usa para el login
            CreateMap<LoginDTO, User>().ReverseMap();  // No necesariamente se necesita, pero se incluye si tienes algún caso especial
        }
    }
}

