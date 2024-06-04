using BlazorApp.Shared.Models;
using BlazorApp.Shared.Requests.Empresas;
using BlazorApp.Shared.Requests.Alunos;
using BlazorApp.Shared.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp.Shared.Handlers
{
    public interface IAlunoHandler
    {
        Task<Response<Aluno?>> CreateAsync(CreateAlunoRequest request);
        Task<Response<Aluno?>> DeleteAsync(DeleteAlunoRequest request);
        Task<PagedResponse<List<Aluno>?>> GetAllAsync(GetAllAlunoRequest request);
        Task<PagedResponse<List<Aluno>?>> GetAlunoByEmpresaAsync(GetAlunoByEmpresaRequest request);
        Task<PagedResponse<List<Aluno>?>> GetAlunoByTreinamentoAsync(GetAlunoByTreinamentoRequest request);
        Task<Response<Aluno?>> GetByIdAsync(GetAlunoByIdRequest request);
        Task<Response<Aluno?>> UpdateAsync(UpdateAlunoRequest request);
    }
}