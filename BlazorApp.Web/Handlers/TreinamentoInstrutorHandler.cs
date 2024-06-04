using BlazorApp.Api.Data;
using BlazorApp.Shared.Handlers;
using BlazorApp.Shared.Models;
using BlazorApp.Shared.Requests.TreinamentosInstrutores;
using BlazorApp.Shared.Responses;

namespace BlazorApp.Api.Handlers
{
    public class TreinamentoInstrutorHandler(AppDbContext context) : ITreinamentoInstrutorHandler
    {
        public Task<Response<TreinamentoInstrutor?>> CreateAsync(CreateTreinamentoInstrutorRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<Response<TreinamentoInstrutor?>> DeleteAsync(DeleteTreinamentoInstrutorRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<PagedResponse<List<TreinamentoInstrutor>?>> GetAllAsync(GetAllTreinamentoInstrutorRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<Response<TreinamentoInstrutor?>> GetByIdAsync(GetTreinamentoInstrutorByIdRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<PagedResponse<List<Treinamento>?>> GetByInstrutorAsync(GetTreinamentoByInstrutorRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<PagedResponse<List<Instrutor>?>> GetByTreinamentoAsync(GetInstrutorByTreinamentoRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
