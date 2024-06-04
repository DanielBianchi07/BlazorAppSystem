using BlazorApp.Shared.Models;
using BlazorApp.Shared.Requests.Certificados;
using BlazorApp.Shared.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp.Shared.Handlers
{
    public interface ICertificadoHandler
    {
        Task<Response<Certificado?>> CreateAsync(CreateCertificadoRequest request);
        Task<Response<Certificado?>> DeleteAsync(DeleteCertificadoRequest request);
        Task<PagedResponse<List<Certificado>?>> GetAllAsync(GetAllCertificadosRequest request);
        Task<Response<Certificado?>> GetByIdAsync(GetCertificadoByIdRequest request);
        Task<PagedResponse<List<Certificado>?>> GetByDateAsync(GetCertificadosByDateRequest request);
        Task<Response<Certificado?>> UpdateAsync(UpdateCertificadoRequest request);
    }
}
