using Vet_CIMAGT.Core.DTOs;

namespace Vet_CIMAGT.Service.Service.Interface
{
  
    public interface IClientService
    {
        Task<List<ClientDTOs>> GetAllArticlesAsync();
        Task<ClientDTOs> GetArticleByIdAsync(Guid id);
        Task CreateArticleAsync(ClientDTOs article);
        Task UpdateArticleAsync(Guid Id, ClientDTOs article);
        Task DeleteArticleAsync(Guid id);
    }
}
