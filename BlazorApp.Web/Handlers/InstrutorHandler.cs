using BlazorApp.Shared.Handlers;
using BlazorApp.Shared.Models;
using BlazorApp.Shared.Requests.Instrutores;
using BlazorApp.Shared.Responses;
using System.Net.Http.Json;

namespace BlazorApp.Web.Handlers
{
   public class InstrutorHandler(IHttpClientFactory httpClientFactory) : IInstrutorHandler
   {
       private readonly HttpClient _httpClient = httpClientFactory.CreateClient(WebConfiguration.HttpClientName);
       public async Task<Response<Instrutor?>> CreateAsync(CreateInstrutorRequest request)
       {
           var result = await _httpClient.PostAsJsonAsync("v1/instrutores", request);
           return await result.Content.ReadFromJsonAsync<Response<Instrutor?>>()
               ?? new Response<Instrutor?>(null, 400, "Falha ao criar instrutor.");
       }       
        
       public async Task<Response<Instrutor?>> DeleteAsync(DeleteInstrutorRequest request)
       {
           var result = await _httpClient.DeleteAsync($"v1/instrutores/{request.Id}");
           return await result.Content.ReadFromJsonAsync<Response<Instrutor?>>()
               ?? new Response<Instrutor?>(null, 400, "Falha ao inativar instrutor.");
       }       
        
       public async Task<PagedResponse<List<Instrutor>?>> GetAllAsync(GetAllInstrutorRequest request)
           => await _httpClient.GetFromJsonAsync<PagedResponse<List<Instrutor>?>>($"v1/instrutores")
               ?? new PagedResponse<List<Instrutor>?>(null, 400, "Falha ao buscar os instrutores.");
        
       public async Task<PagedResponse<List<Instrutor>?>> GetByEspecializacaoAsync(GetInstrutorByEspecializacaoRequest request)
           => await _httpClient.GetFromJsonAsync<PagedResponse<List<Instrutor>?>>($"v1/instrutores/especializacao/{request.Especializacao}")
               ?? new PagedResponse<List<Instrutor>?>(null, 400, "Falha ao buscar instrutores pela especialização.");

       public async Task<Response<Instrutor?>> GetByIdAsync(GetInstrutorByIdRequest request)
            => await _httpClient.GetFromJsonAsync<Response<Instrutor?>>($"v1/instrutores/{request.Id}")
                ?? new Response<Instrutor?>(null, 400, "Falha ao buscar o instrutor por id.");

       public async Task<PagedResponse<List<Instrutor>?>> GetByTreinamentoAsync(GetInstrutorByTreinamentoRequest request)
           => await _httpClient.GetFromJsonAsync<PagedResponse<List<Instrutor>?>>($"v1/instrutores/treinamento/{request.TreinamentoId}")
               ?? new PagedResponse<List<Instrutor>?>(null, 400, "Falha ao buscar instrutores por treinamento.");

        public async Task<Response<Instrutor?>> UpdateAsync(UpdateInstrutorRequest request)
       {
           var result = await _httpClient.PutAsJsonAsync($"v1/instrutores/{request.Id}", request);
           return await result.Content.ReadFromJsonAsync<Response<Instrutor?>>()
               ?? new Response<Instrutor?>(null, 400, "Falha ao atualizar instrutor.");
       }
   }
}