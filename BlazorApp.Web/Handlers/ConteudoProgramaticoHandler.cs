using BlazorApp.Api.Data;
using BlazorApp.Shared.Handlers;
using BlazorApp.Shared.Models;
using BlazorApp.Shared.Requests.ConteudosProgramaticos;
using BlazorApp.Shared.Responses;

namespace BlazorApp.Api.Handlers
{
    public class ConteudoProgramaticoHandler(AppDbContext context) : IConteudoProgramaticoHandler
    {
        public Task<Response<ConteudoProgramatico?>> CreateAsync(CreateConteudoProgramaticoRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<Response<ConteudoProgramatico?>> DeleteAsync(DeleteConteudoProgramaticoRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<PagedResponse<List<ConteudoProgramatico>?>> GetAllAsync(GetAllConteudosProgramaticosRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<Response<List<ConteudoProgramatico>?>> GetByCursoAsync(GetConteudoProgramaticoByCurso request)
        {
            throw new NotImplementedException();
        }

        public Task<Response<ConteudoProgramatico?>> GetByIdAsync(GetConteudoProgramaticoByIdRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<Response<ConteudoProgramatico?>> UpdateAsync(UpdateConteudoProgramaticoRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
