using BlazorApp.Shared.Handlers;
using BlazorApp.Shared.Models;
using BlazorApp.Shared.Requests.AlunosEmpresas;
using BlazorApp.Shared.Requests.Empresas;
using BlazorApp.Shared.Responses;

namespace BlazorApp.Api.Handlers
{
    public class AlunoEmpresaHandler : IAlunoEmpresaHandler
    {
        public async Task<Response<AlunoEmpresa?>> CreateAsync(CreateAlunoEmpresaRequest request)
        {
            throw new NotImplementedException();
        }

        public async Task<Response<AlunoEmpresa?>> DeleteAsync(DeleteAlunoEmpresaRequest request)
        {
            throw new NotImplementedException();
        }

        public async Task<PagedResponse<List<AlunoEmpresa>?>> GetAllAsync(GetAllAlunoEmpresaRequest request)
        {
            throw new NotImplementedException();
        }

        public async Task<Response<List<Aluno>?>> GetByEmpresaAsync(GetAlunosByEmpresaRequest request)
        {
            throw new NotImplementedException();
        }

        public async Task<Response<AlunoEmpresa?>> GetByIdAsync(GetAlunoEmpresaByIdRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
