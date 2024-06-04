using BlazorApp.Shared.Models;
using BlazorApp.Shared.Requests.Instrutores;
using BlazorApp.Shared.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp.Shared.Handlers
{
    public interface IInstrutorHandler
    {
        Task<Response<Instrutor?>> CreateAsync(CreateInstrutorRequest request);
        Task<Response<Instrutor?>> DeleteAsync(DeleteInstrutorRequest request);
        Task<PagedResponse<List<Instrutor>?>> GetAllAsync(GetAllInstrutorRequest request);
        Task<PagedResponse<List<Instrutor>?>> GetByEspecializacaoAsync(GetInstrutorByEspecializacaoRequest request);
        Task<Response<Instrutor?>> GetByIdAsync(GetInstrutorByIdRequest request);
        Task<PagedResponse<List<Instrutor>?>> GetByTreinamentoAsync(GetInstrutorByTreinamentoRequest request);
        Task<Response<Instrutor?>> UpdateAsync(UpdateInstrutorRequest request);
    }
}