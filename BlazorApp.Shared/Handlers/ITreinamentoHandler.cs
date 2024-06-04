using BlazorApp.Shared.Models;
using BlazorApp.Shared.Requests.TelefonesEmpresas;
using BlazorApp.Shared.Requests.Treinamentos;
using BlazorApp.Shared.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp.Shared.Handlers
{
    public interface ITreinamentoHandler
    {
        Task<Response<Treinamento?>> CreateAsync(CreateTreinamentoRequest request);
        Task<Response<Treinamento?>> DeleteAsync(DeleteTreinamentoRequest request);
        Task<PagedResponse<List<Treinamento>?>> GetAllAsync(GetAllTreinamentosRequest request);
        Task<PagedResponse<List<Treinamento>?>> GetTreinamentoByAlunoAsync(GetTreinamentoByAlunoRequest request);
        Task<PagedResponse<List<Treinamento>?>> GetTreinamentoByAlunoByDateAsync(GetTreinamentoByAlunoByDateRequest request);
        Task<PagedResponse<List<Treinamento>?>> GetTreinamentoByEmpresaAsync(GetTreinamentoByEmpresaRequest request);
        Task<PagedResponse<List<Treinamento>?>> GetTreinamentoByEmpresaByDateAsync(GetTreinamentoByEmpresaByDateRequest request);
        Task<PagedResponse<List<Treinamento>?>> GetTreinamentoByInstrutorAsync(GetTreinamentoByInstrutorRequest request);
        Task<PagedResponse<List<Treinamento>?>> GetTreinamentoByInstrutorByDateAsync(GetTreinamentoByInstrutorByDateRequest request);
        Task<PagedResponse<List<Treinamento>?>> GetByDateAsync(GetTreinamentoByDateRequest request);
        Task<Response<Treinamento?>> GetByIdAsync(GetTreinamentoByIdRequest request);
        Task<PagedResponse<List<Treinamento>?>> GetTreinamentoBySitucaoAsync(GetTreinamentoBySituacaoRequest request);
        Task<Response<Treinamento?>> UpdateAsync(UpdateTreinamentoRequest request);
    }
}
