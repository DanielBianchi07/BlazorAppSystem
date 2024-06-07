using BlazorApp.Shared.Handlers;
using BlazorApp.Shared.Models;
using BlazorApp.Shared.Requests.Empresas;
using BlazorApp.Shared.Responses;
using System.Net.Http.Json;

namespace BlazorApp.Web.Handlers
{
    public class EmpresaHandler(IHttpClientFactory httpClientFactory) : IEmpresaHandler
    {
        private readonly HttpClient _httpClient = httpClientFactory.CreateClient(WebConfiguration.HttpClientName);
        public async Task<Response<Empresa?>> CreateAsync(CreateEmpresaRequest request)
        {
            var result = await _httpClient.PostAsJsonAsync("v1/empresas", request);
            return await result.Content.ReadFromJsonAsync<Response<Empresa?>>()
                ?? new Response<Empresa?>(null, 400, "Falha ao criar empresa");
        }

        public async Task<Response<Empresa?>> DeleteAsync(DeleteEmpresaRequest request)
        {
            var result = await _httpClient.DeleteAsync($"v1/empresas/{request.Id}");
            return await result.Content.ReadFromJsonAsync<Response<Empresa?>>()
                ?? new Response<Empresa?>(null, 400, "Falha ao inativar empresa");
        }

        public async Task<PagedResponse<List<Empresa>?>> GetAllAsync(GetAllEmpresasRequest request)
            => await _httpClient.GetFromJsonAsync<PagedResponse<List<Empresa>?>>("v1/empresas/")
                ?? new PagedResponse<List<Empresa>?>(null, 400, "Falha ao buscar empresas");


        public async Task<Response<Empresa?>> GetByIdAsync(GetEmpresaByIdRequest request)
            => await _httpClient.GetFromJsonAsync<Response<Empresa?>>($"v1/empresas/{request.Id}")
                ?? new Response<Empresa?>(null, 400, "Falha ao buscar a empresa");

        public async Task<Response<Empresa?>> UpdateAsync(UpdateEmpresaRequest request)
        {
            var result = await _httpClient.PutAsJsonAsync($"v1/empresas/{request.Id}", request);
            return await result.Content.ReadFromJsonAsync<Response<Empresa?>>()
                ?? new Response<Empresa?>(null, 400, "Falha ao atualizar empresa");
        }
    }
}
