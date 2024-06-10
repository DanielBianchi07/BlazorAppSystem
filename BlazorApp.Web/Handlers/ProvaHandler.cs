using BlazorApp.Shared.Handlers;
using BlazorApp.Shared.Models;
using BlazorApp.Shared.Requests.Provas;
using BlazorApp.Shared.Responses;
using System.Net.Http.Json;

namespace BlazorApp.Web.Handlers
{
    public class ProvaHandler(IHttpClientFactory httpClientFactory) : IProvaHandler
    {
        private readonly HttpClient _httpClient = httpClientFactory.CreateClient(WebConfiguration.HttpClientName);
        public async Task<Response<Prova?>> CreateAsync(CreateProvaRequest request)
        {
            var result = await _httpClient.PostAsJsonAsync("v1/provas", request);
            return await result.Content.ReadFromJsonAsync<Response<Prova?>>()
                ?? new Response<Prova?>(null, 400, "Falha ao criar a prova.");
        }

        public async Task<Response<Prova?>> DeleteAsync(DeleteProvaRequest request)
        {
            var result = await _httpClient.DeleteAsync($"v1/provas/{request.Id}");
            return await result.Content.ReadFromJsonAsync<Response<Prova?>>()
                ?? new Response<Prova?>(null, 400, "Falha ao inativar a prova.");
        }

        public async Task<PagedResponse<List<Prova>?>> GetAllAsync(GetAllProvasRequest request)
            => await _httpClient.GetFromJsonAsync<PagedResponse<List<Prova>?>>($"v1/provas")
               ?? new PagedResponse<List<Prova>?>(null, 400, "Falha ao buscar as provas.");

        public async Task<Response<Prova?>> GetByIdAsync(GetProvaByIdRequest request)
             => await _httpClient.GetFromJsonAsync<Response<Prova?>>($"v1/provas/{request.Id}")
                 ?? new Response<Prova?>(null, 400, "Falha ao buscar a prova pelo id.");
        
        public async Task<PagedResponse<List<Prova>?>> GetByCursoAsync(GetProvaByCursoRequest request)
            => await _httpClient.GetFromJsonAsync<PagedResponse<List<Prova>?>>($"v1/listas-presenca/curso/{request.CursoId}")
                ?? new PagedResponse<List<Prova>?>(null, 400, "Falha ao buscar as provas pelo curso.");

        public async Task<Response<Prova?>> UpdateAsync(UpdateProvaRequest request)
        {
            var result = await _httpClient.PutAsJsonAsync($"v1/provas/{request.Id}", request);
            return await result.Content.ReadFromJsonAsync<Response<Prova?>>()
                ?? new Response<Prova?>(null, 400, "Falha ao atualizar a prova.");
        }
    }
}