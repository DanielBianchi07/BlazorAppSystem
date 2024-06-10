using BlazorApp.Shared.Models;
using BlazorApp.Shared.Requests.Empresas;
using BlazorApp.Shared.Responses;

namespace BlazorApp.Shared.Handlers
{
    public interface IEmpresaHandler
    {
        Task<Response<Empresa?>> CreateAsync(CreateEmpresaRequest request);
        Task<Response<Empresa?>> DeleteAsync(DeleteEmpresaRequest request);
        Task<PagedResponse<List<Empresa>?>> GetAllAsync(GetAllEmpresasRequest request);
        Task<PagedResponse<List<Empresa>?>> GetByRazaoSocial(GetEmpresaByRazaoSocialRequest request);
        Task<Response<Empresa?>> GetByIdAsync(GetEmpresaByIdRequest request);
        Task<Response<Empresa?>> UpdateAsync(UpdateEmpresaRequest request);
    }
}
