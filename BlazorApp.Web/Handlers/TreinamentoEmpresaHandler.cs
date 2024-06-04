using BlazorApp.Api.Data;
using BlazorApp.Shared.Handlers;
using BlazorApp.Shared.Models;
using BlazorApp.Shared.Requests.Treinamentos;
using BlazorApp.Shared.Requests.TreinamentosEmpresas;
using BlazorApp.Shared.Responses;

namespace BlazorApp.Api.Handlers
{
    public class TreinamentoEmpresaHandler(AppDbContext context) : ITreinamentoEmpresaHandler
    {
        public Task<Response<TreinamentoEmpresa?>> CreateAsync(CreateTreinamentoEmpresaRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<Response<TreinamentoEmpresa?>> DeleteAsync(DeleteTreinamentoEmpresaRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<PagedResponse<List<TreinamentoEmpresa>?>> GetAllAsync(GetAllTreinamentoEmpresaRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<PagedResponse<List<Treinamento>?>> GetByEmpresaAsync(GetTreinamentoByEmpresaRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<Response<TreinamentoEmpresa?>> GetByIdAsync(GetTreinamentoEmpresaByIdRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<PagedResponse<List<Empresa>?>> GetByTreinamentoAsync(GetEmpresaByTreinamentoRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
