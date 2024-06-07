//using BlazorApp.Shared.Handlers;
//using BlazorApp.Shared.Models;
//using BlazorApp.Shared.Requests.Instrutores;
//using BlazorApp.Shared.Responses;
//using System.Net.Http.Json;

//namespace BlazorApp.Web.Handlers
//{
//    public class AlternativaHandler(IHttpClientFactory httpClientFactory) : IAlternativaHandler
//    {
//        private readonly HttpClient _httpClient = httpClientFactory.CreateClient(WebConfiguration.HttpClientName);
//        public async Task<Response<Alternativa?>> CreateAsync(CreateAlternativaRequest request)
//        {
//            var result = await _httpClient.PostAsJsonAsync("v1/alternativas", request);
//            return await result.Content.ReadFromJsonAsync<Response<Alternativa?>>()
//                ?? new Response<Alternativa?>(null, 400, "Falha ao criar alternativa");
//        }

//        public async Task<Response<Alternativa?>> DeleteAsync(DeleteAlternativaRequest request)
//        {
//            var result = await _httpClient.DeleteAsync($"v1/alternativas/{request.Id}");
//            return await result.Content.ReadFromJsonAsync<Response<Alternativa?>>()
//                ?? new Response<Alternativa?>(null, 400, "Falha ao inativar alternativa");
//        }

//        public async Task<Response<Alternativa?>> GetByIdAsync(GetAlternativaByIdRequest request)
//            => await _httpClient.GetFromJsonAsync<Response<Alternativa?>>($"v1/alternativas/{request.Id}")
//                ?? new Response<Alternativa?>(null, 400, "Falha ao buscar a alternativa");

//        public async Task<PagedResponse<List<Alternativa>?>> GetByQuestaoAsync(GetAlternativasByQuestaoRequest request)
//            => await _httpClient.GetFromJsonAsync<PagedResponse<List<Alternativa>?>>($"v1/alternativas/questao/{request.QuestaoId}")
//                ?? new PagedResponse<List<Alternativa>?>(null, 400, "Falha ao buscar alternativas");

//        public async Task<Response<Alternativa?>> UpdateAsync(UpdateAlternativaRequest request)
//        {
//            var result = await _httpClient.PutAsJsonAsync($"v1/alternativas/{request.Id}", request);
//            return await result.Content.ReadFromJsonAsync<Response<Alternativa?>>()
//                ?? new Response<Alternativa?>(null, 400, "Falha ao atualizar empresa");
//        }
//    }
//}