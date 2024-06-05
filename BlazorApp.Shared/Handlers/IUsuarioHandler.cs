

using BlazorApp.Shared.Models;
using BlazorApp.Shared.Requests.Usuarios;
using BlazorApp.Shared.Responses;

namespace BlazorApp.Shared.Handlers
{
    public interface IUsuarioHandler
    {
        Task<Response<Usuario?>> CreateAsync(CreateUsuarioRequest request);
        Task<Response<Usuario?>> DeleteAsync(DeleteUsuarioRequest request);
        Task<PagedResponse<List<Usuario>?>> GetAllAsync(GetAllUsuarioRequest request);
        Task<PagedResponse<List<Usuario>?>> GetUsuarioAdminAsync(GetUsuarioAdminRequest request);
        Task<Response<Usuario?>> GetByIdAsync(GetusuarioByIdRequest request);
        Task<Response<Usuario?>> UpdateAsync(UpdateUsuarioRequest request);
        Task<Response<Usuario?>> GetByCredenciais(GetUsuarioBySenhaEmailRequest request);
    }
}
