using Vet_CIMAGT.Core.Models;
using Vet_CIMAGT.Data;
using Vet_CIMAGT.DataLayer.RepoBase;

namespace Vet_CIMAGT.DataLayer.Repositorys.Interface
{
    public class PatientRepository : RepositoryBase<Patient>, IPatientRepository
    {
        public PatientRepository(ApplicationDbContext context) : base(context)
        {
            
        }
    }
}
