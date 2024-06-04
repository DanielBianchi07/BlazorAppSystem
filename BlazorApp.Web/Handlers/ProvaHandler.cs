using BlazorApp.Api.Data;
using BlazorApp.Shared.Handlers;
using BlazorApp.Shared.Models;
using BlazorApp.Shared.Requests.Provas;
using BlazorApp.Shared.Responses;

namespace BlazorApp.Api.Handlers
{
    public class ProvaHandler(AppDbContext context) : IProvaHandler
    {
        public Task<Response<Prova?>> CreateAsync(CreateProvaRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<Response<Prova?>> DeleteAsync(DeleteProvaRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<PagedResponse<List<Prova>?>> GetAllAsync(GetAllProvasRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<PagedResponse<List<Prova>?>> GetByCursoAsync(GetProvaByCursoRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<Response<Prova?>> GetByIdAsync(GetProvaByIdRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<Response<Prova?>> UpdateAsync(UpdateProvaRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
