using BlazorApp.Shared.Handlers;
using BlazorApp.Shared.Models;
using BlazorApp.Shared.Requests.Questoes;
using BlazorApp.Shared.Responses;
using System.Net.Http.Json;

namespace BlazorApp.Web.Handlers
{
    public class QuestaoHandler(IHttpClientFactory httpClientFactory) : IQuestaoHandler
    {
        private readonly HttpClient _httpClient = httpClientFactory.CreateClient(WebConfiguration.HttpClientName);
        public async Task<Response<Questao?>> CreateAsync(CreateQuestaoRequest request)
        {
            var result = await _httpClient.PostAsJsonAsync("v1/questao", request);
            return await result.Content.ReadFromJsonAsync<Response<Questao?>>()
                ?? new Response<Questao?>(null, 400, "Falha ao criar a questão.");
        }

        public async Task<Response<Questao?>> DeleteAsync(DeleteQuestaoRequest request)
        {
            var result = await _httpClient.DeleteAsync($"v1/questao/{request.Id}");
            return await result.Content.ReadFromJsonAsync<Response<Questao?>>()
                ?? new Response<Questao?>(null, 400, "Falha ao inativar a questão.");
        }

        public async Task<Response<Questao?>> GetByIdAsync(GetQuestaoByIdRequest request)
            => await _httpClient.GetFromJsonAsync<Response<Questao?>>($"v1/questao/{request.Id}")
                ?? new Response<Questao?>(null, 400, "Falha ao buscar a questão pelo id.");

        public async Task<PagedResponse<List<Questao>?>> GetByProvaAsync(GetQuestaoByProvaRequest request)
            => await _httpClient.GetFromJsonAsync<PagedResponse<List<Questao>?>>($"v1/alunos/prova/{request.ProvaId}")
                ?? new PagedResponse<List<Questao>?>(null, 400, "Falha ao buscar as questões da prova.");

        public async Task<Response<Questao?>> UpdateAsync(UpdateQuestaoRequest request)
        {
            var result = await _httpClient.PutAsJsonAsync($"v1/alunos/{request.Id}", request);
            return await result.Content.ReadFromJsonAsync<Response<Questao?>>()
                ?? new Response<Questao?>(null, 400, "Falha ao atualizar a questão.");
        }
    }
}