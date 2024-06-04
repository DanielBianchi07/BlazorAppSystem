using BlazorApp.Api.Data;
using BlazorApp.Shared.Handlers;
using BlazorApp.Shared.Models;
using BlazorApp.Shared.Requests.Alternativas;
using BlazorApp.Shared.Requests.Certificados;
using BlazorApp.Shared.Responses;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;

namespace BlazorApp.Api.Handlers
{
    public class CertificadoHandler(AppDbContext context) : ICertificadoHandler
    {
        public Task<Response<Certificado?>> CreateAsync(CreateCertificadoRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<Response<Certificado?>> DeleteAsync(DeleteCertificadoRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<PagedResponse<List<Certificado>?>> GetAllAsync(GetAllCertificadosRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<Response<List<Certificado>?>> GetByDateAsync(GetCertificadosByDateRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<Response<Certificado?>> GetByIdAsync(GetCertificadoByIdRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<Response<Certificado?>> UpdateAsync(UpdateCertificadoRequest request)
        {
            throw new NotImplementedException();
        }
    }

}
