using BlazorApp.Shared.Handlers;
using BlazorApp.Shared.Models;
using BlazorApp.Shared.Requests.TelefonesEmpresas;
using BlazorApp.Shared.Responses;
using System.Net.Http.Json;

namespace BlazorApp.Web.Handlers
{
    public class TelefoneEmpresaHandler(IHttpClientFactory httpClientFactory) : ITelefoneEmpresaHandler
    {
        private readonly HttpClient _httpClient = httpClientFactory.CreateClient(WebConfiguration.HttpClientName);
        public async Task<Response<TelefoneEmpresa?>> CreateAsync(CreateTelefoneEmpresaRequest request)
        {
            var result = await _httpClient.PostAsJsonAsync("v1/telefones-empresas", request);
            return await result.Content.ReadFromJsonAsync<Response<TelefoneEmpresa?>>()
                ?? new Response<TelefoneEmpresa?>(null, 400, "Falha ao criar o telefone.");
        }

        public async Task<Response<TelefoneEmpresa?>> DeleteAsync(DeleteTelefoneEmpresaRequest request)
        {
            var result = await _httpClient.DeleteAsync($"v1/telefones-empresas/{request.Id}");
            return await result.Content.ReadFromJsonAsync<Response<TelefoneEmpresa?>>()
                ?? new Response<TelefoneEmpresa?>(null, 400, "Falha ao inativar o telefone.");
        }

        public async Task<Response<TelefoneEmpresa?>> GetByIdAsync(GetTelefoneEmpresaByIdRequest request)
            => await _httpClient.GetFromJsonAsync<Response<TelefoneEmpresa?>>($"v1/telefones-empresas/{request.Id}")
                ?? new Response<TelefoneEmpresa?>(null, 400, "Falha ao buscar o telefone pelo id.");

        public async Task<PagedResponse<List<TelefoneEmpresa>?>> GetByEmpresaAsync(GetTelefonesByEmpresasRequest request)
            => await _httpClient.GetFromJsonAsync<PagedResponse<List<TelefoneEmpresa>?>>($"v1/telefones-empresas/empresa/{request.EmpresaId}")
                ?? new PagedResponse<List<TelefoneEmpresa>?>(null, 400, "Falha ao buscar os telefones da empresa.");

        public async Task<Response<TelefoneEmpresa?>> UpdateAsync(UpdateTelefoneEmpresaRequest request)
        {
            var result = await _httpClient.PutAsJsonAsync($"v1/telefones-empresa/{request.Id}", request);
            return await result.Content.ReadFromJsonAsync<Response<TelefoneEmpresa?>>()
                ?? new Response<TelefoneEmpresa?>(null, 400, "Falha ao atualizar o telefone.");
        }
    }
}