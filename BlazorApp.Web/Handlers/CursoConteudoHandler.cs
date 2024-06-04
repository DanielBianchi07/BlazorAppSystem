using BlazorApp.Api.Data;
using BlazorApp.Shared.Handlers;
using BlazorApp.Shared.Models;
using BlazorApp.Shared.Requests.CursosConteudos;
using BlazorApp.Shared.Responses;

namespace BlazorApp.Api.Handlers
{
    public class CursoConteudoHandler(AppDbContext context) : ICursoConteudoHandler
    {
        public Task<Response<CursoConteudo?>> CreateAsync(CreateCursoConteudoRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<Response<CursoConteudo?>> DeleteAsync(DeleteCursoConteudoRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<PagedResponse<List<CursoConteudo>?>> GetAllAsync(GetAllCursoConteudoRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<Response<ConteudoProgramatico?>> GetByCursoAsync(GetConteudoByCursoRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<Response<CursoConteudo?>> GetByIdAsync(GetCursoConteudoByIdRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
