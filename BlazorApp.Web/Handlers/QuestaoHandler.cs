using BlazorApp.Api.Data;
using BlazorApp.Shared.Handlers;
using BlazorApp.Shared.Models;
using BlazorApp.Shared.Requests.Questoes;
using BlazorApp.Shared.Responses;

namespace BlazorApp.Api.Handlers
{
    public class QuestaoHandler(AppDbContext context) : IQuestaoHandler
    {
        public Task<Response<Questao?>> CreateAsync(CreateQuestaoRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<Response<Questao?>> DeleteAsync(DeleteQuestaoRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<Response<Questao?>> GetByIdAsync(GetQuestaoByIdRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<Response<Questao?>> UpdateAsync(UpdateQuestaoRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
