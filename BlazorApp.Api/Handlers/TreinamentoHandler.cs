using BlazorApp.Shared.Handlers;
using BlazorApp.Shared.Models;
using BlazorApp.Shared.Requests.Treinamentos;
using BlazorApp.Shared.Responses;

namespace BlazorApp.Api.Handlers
{
    public class TreinamentoHandler : ITreinamentoHandler
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

        public Task<PagedResponse<List<Treinamento>?>> GetTreinamentoByAlunoAsync(GetTreinamentoByAlunoRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<PagedResponse<List<Treinamento>?>> GetTreinamentoByAlunoByDateAsync(GetTreinamentoByAlunoByDateRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<PagedResponse<List<Treinamento>?>> GetTreinamentoByEmpresaAsync(GetTreinamentoByEmpresaRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<PagedResponse<List<Treinamento>?>> GetTreinamentoByEmpresaByDateAsync(GetTreinamentoByEmpresaByDateRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<PagedResponse<List<Treinamento>?>> GetTreinamentoByInstrutorAsync(GetTreinamentoByInstrutorRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<PagedResponse<List<Treinamento>?>> GetTreinamentoByInstrutorByDateAsync(GetTreinamentoByInstrutorByDateRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<PagedResponse<List<Treinamento>?>> GetTreinamentoBySitucaoAsync(GetTreinamentoBySituacaoRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<Response<Treinamento?>> UpdateAsync(UpdateTreinamentoRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
