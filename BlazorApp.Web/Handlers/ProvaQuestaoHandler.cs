using BlazorApp.Api.Data;
using BlazorApp.Shared.Handlers;
using BlazorApp.Shared.Models;
using BlazorApp.Shared.Requests.ProvasQuestoes;
using BlazorApp.Shared.Responses;

namespace BlazorApp.Api.Handlers
{
    public class ProvaQuestaoHandler(AppDbContext context) : IProvaQuestaoHandler
    {
        public Task<Response<ProvaQuestao?>> CreateAsync(CreateProvaQuestaoRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<Response<ProvaQuestao?>> DeleteAsync(DeleteProvaQuestaoRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<PagedResponse<List<ProvaQuestao>?>> GetAllAsync(GetAllProvaQuestaoRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<Response<ProvaQuestao?>> GetByIdAsync(GetProvaQuestaoByIdRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<Response<List<Questao>?>> GetByProvaAsync(GetQuestoesByProvaRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<Response<ProvaQuestao?>> UpdateAsync(UpdateProvaQuestaoRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
