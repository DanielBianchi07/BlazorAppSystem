using BlazorApp.Shared.Handlers;
using BlazorApp.Shared.Models;
using BlazorApp.Shared.Requests.Cursos;
using BlazorApp.Shared.Responses;
using System.Net.Http.Json;

namespace BlazorApp.Web.Handlers
{
    public class CursoHandler(IHttpClientFactory httpClientFactory) : ICursoHandler
    {
        private readonly HttpClient _httpClient = httpClientFactory.CreateClient(WebConfiguration.HttpClientName);
        public async Task<Response<Curso?>> CreateAsync(CreateCursoRequest request)
        {
            var result = await _httpClient.PostAsJsonAsync("v1/cursos", request);
            return await result.Content.ReadFromJsonAsync<Response<Curso?>>()
                ?? new Response<Curso?>(null, 400, "Falha ao criar curso.");
        }

        public async Task<Response<Curso?>> DeleteAsync(DeleteCursoRequest request)
        {
            var result = await _httpClient.DeleteAsync($"v1/cursos/{request.Id}");
            return await result.Content.ReadFromJsonAsync<Response<Curso?>>()
                ?? new Response<Curso?>(null, 400, "Falha ao inativar curso.");
        }

        public async Task<PagedResponse<List<Curso>?>> GetAllAsync(GetAllCursosRequest request)
            => await _httpClient.GetFromJsonAsync<PagedResponse<List<Curso>?>>($"v1/cursos")
                ?? new PagedResponse<List<Curso>?>(null, 400, "Falha ao buscar os cursos.");

        public async Task<Response<Curso?>> GetByIdAsync(GetCursoByIdRequest request)
             => await _httpClient.GetFromJsonAsync<Response<Curso?>>($"v1/cursos/{request.Id}")
                 ?? new Response<Curso?>(null, 400, "Falha ao buscar o curso");


        public async Task<Response<Curso?>> UpdateAsync(UpdateCursoRequest request)
        {
            var result = await _httpClient.PutAsJsonAsync($"v1/cursos/{request.Id}", request);
            return await result.Content.ReadFromJsonAsync<Response<Curso?>>()
                ?? new Response<Curso?>(null, 400, "Falha ao atualizar o curso.");
        }
    }
}