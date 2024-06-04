using BlazorApp.Api.Data;
using BlazorApp.Shared.Handlers;
using BlazorApp.Shared.Models;
using BlazorApp.Shared.Requests.TelefonesEmpresas;
using BlazorApp.Shared.Responses;

namespace BlazorApp.Api.Handlers
{
    public class TelefoneEmpresaHandler(AppDbContext context) : ITelefoneEmpresaHandler
    {
        public Task<Response<TelefoneEmpresa?>> CreateAsync(CreateTelefoneEmpresaRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<Response<TelefoneEmpresa?>> DeleteAsync(DeleteTelefoneEmpresaRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<PagedResponse<List<TelefoneEmpresa>?>> GetByCursoAsync(GetTelefonesByEmpresasRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<Response<TelefoneEmpresa?>> GetByIdAsync(GetTelefoneEmpresaByIdRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<Response<TelefoneEmpresa?>> UpdateAsync(UpdateTelefoneEmpresaRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
