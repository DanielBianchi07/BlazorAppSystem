using BlazorApp.Api.Data;
using BlazorApp.Shared.Handlers;
using BlazorApp.Shared.Models;
using BlazorApp.Shared.Requests.Empresas;
using BlazorApp.Shared.Responses;

namespace BlazorApp.Api.Handlers
{
    public class EmpresaHandler(AppDbContext context) : IEmpresaHandler
    {
        public Task<Response<Empresa?>> CreateAsync(CreateEmpresaRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<Response<Empresa?>> DeleteAsync(DeleteEmpresaRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<PagedResponse<List<Empresa>?>> GetAllAsync(GetAllEmpresasRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<Response<Empresa?>> GetByIdAsync(GetEmpresaByIdRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<Response<Empresa?>> UpdateAsync(UpdateEmpresaRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
