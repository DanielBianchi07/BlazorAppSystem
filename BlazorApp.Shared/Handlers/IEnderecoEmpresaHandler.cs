using BlazorApp.Shared.Models;
using BlazorApp.Shared.Requests.EnderecosEmpresas;
using BlazorApp.Shared.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp.Shared.Handlers
{
    public interface IEnderecoEmpresaHandler
    {
        Task<Response<EnderecoEmpresa?>> CreateAsync(CreateEnderecoEmpresaRequest request);
        Task<Response<EnderecoEmpresa?>> DeleteAsync(DeleteEnderecoEmpresaRequest request);
        Task<Response<EnderecoEmpresa?>> GetByIdAsync(GetEnderecoEmpresaByIdRequest request);
        Task<Response<EnderecoEmpresa?>> UpdateAsync(UpdateEnderecoEmpresaRequest request);
    }
}
