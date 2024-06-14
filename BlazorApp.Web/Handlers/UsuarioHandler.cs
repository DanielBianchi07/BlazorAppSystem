using BlazorApp.Shared.Handlers;
using BlazorApp.Shared.Models;
using BlazorApp.Shared.Requests.Instrutores;
using BlazorApp.Shared.Requests.Usuarios;
using BlazorApp.Shared.Responses;
using System.Net.Http;
using System.Net.Http.Json;

namespace BlazorApp.Web.Handlers
{
    public class UsuarioHandler(IHttpClientFactory httpClientFactory) : IUsuarioHandler
    {
        private readonly HttpClient _httpClient = httpClientFactory.CreateClient(WebConfiguration.HttpClientName);
        public async Task<Response<Usuario?>> CreateAsync(CreateUsuarioRequest request)
        {

        var result = await _httpClient.PostAsJsonAsync("v1/usuarios", request);
            return await result.Content.ReadFromJsonAsync<Response<Usuario?>>()
                ?? new Response<Usuario?>(null, 400, "Falha ao criar usuario.");
        }

        public Task<Response<Usuario?>> DeleteAsync(DeleteUsuarioRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<PagedResponse<List<Usuario>?>> GetAllAsync(GetAllUsuarioRequest request)
        {
            throw new NotImplementedException();
        }

        public async Task<Response<Usuario?>> GetByCredenciais(GetUsuarioBySenhaEmailRequest request)
            => await _httpClient.GetFromJsonAsync<Response<Usuario?>>($"v1/usuarios/{request.Email}")
                ?? new Response<Usuario?>(null, 400, "Falha ao buscar o usuario pelo email.");
        

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