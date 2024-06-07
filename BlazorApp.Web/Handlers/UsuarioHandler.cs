using BlazorApp.Shared.Handlers;
using BlazorApp.Shared.Models;
using BlazorApp.Shared.Requests.Usuarios;
using BlazorApp.Shared.Responses;
using System.Net.Http.Json;

namespace BlazorApp.Web.Handlers
{
    public class UsuarioHandler : IUsuarioHandler
    {
        public Task<Response<Usuario?>> CreateAsync(CreateUsuarioRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<Response<Usuario?>> DeleteAsync(DeleteUsuarioRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<PagedResponse<List<Usuario>?>> GetAllAsync(GetAllUsuarioRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<Response<Usuario?>> GetByCredenciais(GetUsuarioBySenhaEmailRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<Response<Usuario?>> GetByIdAsync(GetusuarioByIdRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<PagedResponse<List<Usuario>?>> GetUsuarioAdminAsync(GetUsuarioAdminRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<Response<Usuario?>> UpdateAsync(UpdateUsuarioRequest request)
        {
            throw new NotImplementedException();
        }
    }
}