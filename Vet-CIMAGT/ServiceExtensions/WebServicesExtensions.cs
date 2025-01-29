using Vet_CIMAGT.DataLayer.Repositorys;
using Vet_CIMAGT.DataLayer.Repositorys.Interface;
using Vet_CIMAGT.Service.Service;
using Vet_CIMAGT.Service.Service.Interface;

namespace Vet_CIMAGT.ServiceExtensions
{
    public static class WebServicesExtensions
    {
        public static void AddWebServices(this IServiceCollection services)
        {
            services.AddScoped<IClientRepository, ClientRepository>();
            services.AddScoped<IClientService, ClientService>();

            services.AddScoped<IConsumptionRepository, ConsumptionRepository>();
            services.AddScoped<IConsumptionService, ConsumptionService>();

            services.AddScoped<IPatientRepository, PatientRepository>();
            services.AddScoped<IPatientService, PatientService>();
        }
    }
}
