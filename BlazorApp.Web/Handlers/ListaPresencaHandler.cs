using BlazorApp.Shared.Handlers;
using BlazorApp.Shared.Models;
using BlazorApp.Shared.Requests.ListasPresencas;
using BlazorApp.Shared.Responses;
using System.Net.Http.Json;

namespace BlazorApp.Web.Handlers
{
    public class ListaPresencaHandler(IHttpClientFactory httpClientFactory) : IListaPresencaHandler
    {
        private readonly HttpClient _httpClient = httpClientFactory.CreateClient(WebConfiguration.HttpClientName);
        public async Task<Response<ListaPresenca?>> CreateAsync(CreateListaPresencaRequest request)
        {
            var result = await _httpClient.PostAsJsonAsync("v1/listas-presenca", request);
            return await result.Content.ReadFromJsonAsync<Response<ListaPresenca?>>()
                ?? new Response<ListaPresenca?>(null, 400, "Falha ao criar a lista de presença.");
        }

        public async Task<Response<ListaPresenca?>> DeleteAsync(DeleteListaPresencaRequest request)
        {
            var result = await _httpClient.DeleteAsync($"v1/listas-presenca/{request.TreinamentoId}/{request.Codigo}");
            return await result.Content.ReadFromJsonAsync<Response<ListaPresenca?>>()
                ?? new Response<ListaPresenca?>(null, 400, "Falha ao inativar lista de presença.");
        }

        public async Task<PagedResponse<List<ListaPresenca>?>> GetAllAsync(GetAllListaPresencaRequest request)
            => await _httpClient.GetFromJsonAsync<PagedResponse<List<ListaPresenca>?>>($"v1/listas-presenca")
                ?? new PagedResponse<List<ListaPresenca>?>(null, 400, "Falha ao buscar as listas de presença.");

        public async Task<PagedResponse<List<ListaPresenca>?>> GetByDateAsync(GetListaPresencaByDateRequest request)
            => await _httpClient.GetFromJsonAsync<PagedResponse<List<ListaPresenca>?>>($"v1/listas-presenca/data/{request.StartDate}/{request.EndDate}")
                ?? new PagedResponse<List<ListaPresenca>?>(null, 400, "Falha ao buscar as listas de presença pela data.");

        public async Task<Response<ListaPresenca?>> GetByIdAsync(GetListaPresencaByIdRequest request)
             => await _httpClient.GetFromJsonAsync<Response<ListaPresenca?>>($"v1/listas-presenca/{request.TreinamentoId}/{request.Codigo}")
                 ?? new Response<ListaPresenca?>(null, 400, "Falha ao buscar a lista de presença pelo id.");

        public async Task<Response<ListaPresenca?>> UpdateAsync(UpdateListaPresencaRequest request)
        {
            var result = await _httpClient.PutAsJsonAsync($"v1/listas-presenca/{request.TreinamentoId}/{request.Codigo}", request);
            return await result.Content.ReadFromJsonAsync<Response<ListaPresenca?>>()
                ?? new Response<ListaPresenca?>(null, 400, "Falha ao atualizar a lista de presença.");
        }
    }
}