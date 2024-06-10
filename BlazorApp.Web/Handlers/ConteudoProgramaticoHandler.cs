using BlazorApp.Shared.Handlers;
using BlazorApp.Shared.Models;
using BlazorApp.Shared.Requests.ConteudosProgramaticos;
using BlazorApp.Shared.Responses;
using System.Net.Http.Json;

namespace BlazorApp.Web.Handlers
{
    public class ConteudoProgramaticoHandler(IHttpClientFactory httpClientFactory) : IConteudoProgramaticoHandler
    {
        private readonly HttpClient _httpClient = httpClientFactory.CreateClient(WebConfiguration.HttpClientName);
        public async Task<Response<ConteudoProgramatico?>> CreateAsync(CreateConteudoProgramaticoRequest request)
        {
            var result = await _httpClient.PostAsJsonAsync("v1/conteudo-programatico", request);
            return await result.Content.ReadFromJsonAsync<Response<ConteudoProgramatico?>>()
                ?? new Response<ConteudoProgramatico?>(null, 400, "Falha ao criar conteúdo programático.");
        }

        public async Task<Response<ConteudoProgramatico?>> DeleteAsync(DeleteConteudoProgramaticoRequest request)
        {
            var result = await _httpClient.DeleteAsync($"v1/conteudo-programatico/{request.Id}");
            return await result.Content.ReadFromJsonAsync<Response<ConteudoProgramatico?>>()
                ?? new Response<ConteudoProgramatico?>(null, 400, "Falha ao inativar conteúdo programático.");
        }

        public async Task<PagedResponse<List<ConteudoProgramatico>?>> GetAllAsync(GetAllConteudosProgramaticosRequest request)
            => await _httpClient.GetFromJsonAsync<PagedResponse<List<ConteudoProgramatico>?>>($"v1/conteudo-programatico")
                ?? new PagedResponse<List<ConteudoProgramatico>?>(null, 400, "Falha ao buscar os conteúdos programáticos.");

        public async Task<PagedResponse<List<ConteudoProgramatico>?>> GetByCursoAsync(GetConteudoProgramaticoByCursoRequest request)
            => await _httpClient.GetFromJsonAsync<PagedResponse<List<ConteudoProgramatico>?>>($"v1/conteudo-programatico/{request.CursoId}")
                ?? new PagedResponse<List<ConteudoProgramatico>?>(null, 400, "Falha ao buscar conteúdos programáticos pelo curso.");


        public async Task<Response<ConteudoProgramatico?>> UpdateAsync(UpdateConteudoProgramaticoRequest request)
        {
            var result = await _httpClient.PutAsJsonAsync($"v1/conteudo-programatico/{request.Id}", request);
            return await result.Content.ReadFromJsonAsync<Response<ConteudoProgramatico?>>()
                ?? new Response<ConteudoProgramatico?>(null, 400, "Falha ao atualizar o conteúdo prográmatico");
        }
    }
}