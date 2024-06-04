using BlazorApp.Shared.Models;
using BlazorApp.Shared.Requests.Questoes;
using BlazorApp.Shared.Requests.TelefonesEmpresas;
using BlazorApp.Shared.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp.Shared.Handlers
{
    public interface ITelefoneEmpresaHandler
    {
        Task<Response<TelefoneEmpresa?>> CreateAsync(CreateTelefoneEmpresaRequest request);
        Task<Response<TelefoneEmpresa?>> DeleteAsync(DeleteTelefoneEmpresaRequest request);
        Task<PagedResponse<List<TelefoneEmpresa>?>> GetByEmpresaAsync(GetTelefonesByEmpresasRequest request);
        Task<Response<TelefoneEmpresa?>> GetByIdAsync(GetTelefoneEmpresaByIdRequest request);
        Task<Response<TelefoneEmpresa?>> UpdateAsync(UpdateTelefoneEmpresaRequest request);
    }
}
