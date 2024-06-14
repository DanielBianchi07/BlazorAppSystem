using BlazorApp.Shared.Handlers;
using BlazorApp.Shared.Models;
using BlazorApp.Shared.Requests.Treinamentos;
using BlazorApp.Shared.Responses;
using System.Net.Http.Json;

namespace BlazorApp.Web.Handlers
{
    public class TreinamentoHandler(IHttpClientFactory httpClientFactory) : ITreinamentoHandler
    {
        private readonly HttpClient _httpClient = httpClientFactory.CreateClient(WebConfiguration.HttpClientName);
        public async Task<Response<Treinamento?>> CreateAsync(CreateTreinamentoRequest request)
        {
            var result = await _httpClient.PostAsJsonAsync("v1/treinamentos", request);
            return await result.Content.ReadFromJsonAsync<Response<Treinamento?>>()
                ?? new Response<Treinamento?>(null, 400, "Falha ao criar treinamento.");
        }

        public async Task<Response<Treinamento?>> DeleteAsync(DeleteTreinamentoRequest request)
        {
            var result = await _httpClient.DeleteAsync($"v1/treinamentos/{request.Id}");
            return await result.Content.ReadFromJsonAsync<Response<Treinamento?>>()
                ?? new Response<Treinamento?>(null, 400, "Falha ao inativar treinamento.");
        }

        public async Task<PagedResponse<List<Treinamento>?>> GetAllAsync(GetAllTreinamentosRequest request)
            => await _httpClient.GetFromJsonAsync<PagedResponse<List<Treinamento>?>>($"v1/treinamentos")
                ?? new PagedResponse<List<Treinamento>?>(null, 400, "Falha ao buscar os treinamentos.");

        public async Task<PagedResponse<List<Treinamento>?>> GetByDateAsync(GetTreinamentoByDateRequest request)
            => await _httpClient.GetFromJsonAsync<PagedResponse<List<Treinamento>?>>($"v1/treinamentos/data/{request.StartDate}-{request.EndDate}")
                ?? new PagedResponse<List<Treinamento>?>(null, 400, "Falha ao buscar os treinamentos pela data.");

        public async Task<PagedResponse<List<Treinamento>?>> GetTreinamentoByAlunoAsync(GetTreinamentoByAlunoRequest request)
            => await _httpClient.GetFromJsonAsync<PagedResponse<List<Treinamento>?>>($"v1/treinamentos/aluno/{request.AlunoId}")
                ?? new PagedResponse<List<Treinamento>?>(null, 400, "Falha ao buscar treinamentos do aluno.");

        public async Task<Response<Treinamento?>> GetByIdAsync(GetTreinamentoByIdRequest request)
            => await _httpClient.GetFromJsonAsync<Response<Treinamento?>>($"v1/treinamentos/{request.Id}")
                ?? new Response<Treinamento?>(null, 400, "Falha ao buscar o treinamento pelo id.");

        public async Task<PagedResponse<List<Treinamento>?>> GetTreinamentoByAlunoByDateAsync(GetTreinamentoByAlunoByDateRequest request)
            => await _httpClient.GetFromJsonAsync<PagedResponse<List<Treinamento>?>>($"v1/treinamentos/aluno/{request.AlunoId}/data/{request.StartDate}-{request.EndDate}")
                ?? new PagedResponse<List<Treinamento>?>(null, 400, "Falha ao buscar os treinamentos de um aluno pela data.");

        public async Task<PagedResponse<List<Treinamento>?>> GetTreinamentoByEmpresaAsync(GetTreinamentoByEmpresaRequest request)
            => await _httpClient.GetFromJsonAsync<PagedResponse<List<Treinamento>?>>($"v1/treinamentos/empresa/{request.EmpresaId}")
                ?? new PagedResponse<List<Treinamento>?>(null, 400, "Falha ao buscar treinamentos de uma empresa.");

        public async Task<PagedResponse<List<Treinamento>?>> GetTreinamentoByEmpresaByDateAsync(GetTreinamentoByEmpresaByDateRequest request)
            => await _httpClient.GetFromJsonAsync<PagedResponse<List<Treinamento>?>>($"v1/treinamentos/empresa/{request.EmpresaId}/data/{request.StartDate}-{request.EndDate}")
                ?? new PagedResponse<List<Treinamento>?>(null, 400, "Falha ao buscar os treinamentos de um empresa pela data.");

        public async Task<PagedResponse<List<Treinamento>?>> GetTreinamentoByInstrutorAsync(GetTreinamentoByInstrutorRequest request)
            => await _httpClient.GetFromJsonAsync<PagedResponse<List<Treinamento>?>>($"v1/treinamentos/instrutor/{request.InstrutorId}")
                ?? new PagedResponse<List<Treinamento>?>(null, 400, "Falha ao buscar treinamentos do instrutor.");

        public async Task<PagedResponse<List<Treinamento>?>> GetTreinamentoByInstrutorByDateAsync(GetTreinamentoByInstrutorByDateRequest request)
            => await _httpClient.GetFromJsonAsync<PagedResponse<List<Treinamento>?>>($"v1/treinamentos/instrutor/{request.InstrutorId}/data/{request.StartDate}-{request.EndDate}")
                ?? new PagedResponse<List<Treinamento>?>(null, 400, "Falha ao buscar os treinamentos de um instrutor pela data.");

        public async Task<PagedResponse<List<Treinamento>?>> GetTreinamentoBySitucaoAsync(GetTreinamentoBySituacaoRequest request)
            => await _httpClient.GetFromJsonAsync<PagedResponse<List<Treinamento>?>>($"v1/treinamentos/situacao/{request.Situacao}")
                ?? new PagedResponse<List<Treinamento>?>(null, 400, "Falha ao buscar treinamentos pela situação.");

        public async Task<Response<Treinamento?>> UpdateAsync(UpdateTreinamentoRequest request)
        {
            var result = await _httpClient.PutAsJsonAsync($"v1/treinamentos/{request.Id}", request);
            return await result.Content.ReadFromJsonAsync<Response<Treinamento?>>()
                ?? new Response<Treinamento?>(null, 400, "Falha ao atualizar o treinamento");
        }
    }
}