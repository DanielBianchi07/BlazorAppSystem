using BlazorApp.Api.Data;
using BlazorApp.Shared.Handlers;
using BlazorApp.Shared.Models;
using BlazorApp.Shared.Requests.CursosQuestoes;
using BlazorApp.Shared.Responses;

namespace BlazorApp.Api.Handlers
{
    public class CursoQuestaoHandler(AppDbContext context) : ICursoQuestaoHandler
    {
        public Task<Response<CursoQuestao?>> CreateAsync(CreateCursoQuestaoRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<Response<CursoQuestao?>> DeleteAsync(DeleteCursoQuestaoRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<PagedResponse<List<CursoQuestao>?>> GetAllAsync(GetAllCursoQuestaoRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<Response<List<CursoQuestao>?>> GetByCursoAsync(GetQuestaoByCursoRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<Response<CursoQuestao?>> GetByIdAsync(GetCursoQuestaoByIdRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
