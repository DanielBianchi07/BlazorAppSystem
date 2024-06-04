using BlazorApp.Api.Data;
using BlazorApp.Shared.Handlers;
using BlazorApp.Shared.Models;
using BlazorApp.Shared.Requests.Treinamentos;
using BlazorApp.Shared.Responses;

namespace BlazorApp.Api.Handlers
{
    public class TreinamentoHandler(AppDbContext context) : ITreinamentoHandler
    {
        public Task<Response<Treinamento?>> CreateAsync(CreateTreinamentoRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<Response<Treinamento?>> DeleteAsync(DeleteTreinamentoRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<PagedResponse<List<Treinamento>?>> GetAllAsync(GetAllTreinamentosRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<PagedResponse<List<Treinamento>?>> GetByDateAsync(GetTreinamentoByDateRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<Response<Treinamento?>> GetByIdAsync(GetTreinamentoByIdRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<Response<Treinamento?>> UpdateAsync(UpdateTreinamentoRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
