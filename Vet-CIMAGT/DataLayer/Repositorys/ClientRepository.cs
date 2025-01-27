using Vet_CIMAGT.Core.Models;
using Vet_CIMAGT.Data;
using Vet_CIMAGT.DataLayer.RepoBase;
using Vet_CIMAGT.DataLayer.Repositorys.Interface;

namespace Vet_CIMAGT.DataLayer.Repositorys
{
    public class ClientRepository : RepositoryBase<Client>, IClientRepository
    {
        public ClientRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
