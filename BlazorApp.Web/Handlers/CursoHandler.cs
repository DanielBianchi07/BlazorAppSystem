using BlazorApp.Api.Data;
using BlazorApp.Shared.Handlers;
using BlazorApp.Shared.Models;
using BlazorApp.Shared.Requests.Cursos;
using BlazorApp.Shared.Responses;

namespace BlazorApp.Api.Handlers
{
    public class CursoHandler(AppDbContext context) : ICursoHandler
    {
        public Task<Response<Curso?>> CreateAsync(CreateCursoRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<Response<Curso?>> DeleteAsync(DeleteCursoRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<PagedResponse<List<Curso>?>> GetAllAsync(GetAllCursosRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<Response<Curso?>> GetByIdAsync(GetCursoByIdRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<Response<Curso?>> UpdateAsync(UpdateCursoRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
