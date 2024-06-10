using BlazorApp.Shared.Handlers;
using BlazorApp.Shared.Models;
using BlazorApp.Shared.Requests.Alunos;
using BlazorApp.Shared.Responses;
using System.Net.Http.Json;

namespace BlazorApp.Web.Handlers
{
    public class AlunoHandler(IHttpClientFactory httpClientFactory) : IAlunoHandler
    {
        private readonly HttpClient _httpClient = httpClientFactory.CreateClient(WebConfiguration.HttpClientName);
        public async Task<Response<Aluno?>> CreateAsync(CreateAlunoRequest request)
        {
            var result = await _httpClient.PostAsJsonAsync("v1/alunos", request);
            return await result.Content.ReadFromJsonAsync<Response<Aluno?>>()
                ?? new Response<Aluno?>(null, 400, "Falha ao criar aluno.");
        }

        public async Task<Response<Aluno?>> DeleteAsync(DeleteAlunoRequest request)
        {
            var result = await _httpClient.DeleteAsync($"v1/alunos/{request.Id}");
            return await result.Content.ReadFromJsonAsync<Response<Aluno?>>()
                ?? new Response<Aluno?>(null, 400, "Falha ao inativar aluno.");
        }

        public async Task<PagedResponse<List<Aluno>?>> GetAllAsync(GetAllAlunoRequest request)
            => await _httpClient.GetFromJsonAsync<PagedResponse<List<Aluno>?>>($"v1/alunos")
                ?? new PagedResponse<List<Aluno>?>(null, 400, "Falha ao buscar o aluno");
        
        public async Task<PagedResponse<List<Aluno>?>> GetAlunoByEmpresaAsync(GetAlunoByEmpresaRequest request)
            => await _httpClient.GetFromJsonAsync<PagedResponse<List<Aluno>?>>($"v1/alunos/empresa/{request.EmpresaId}")
                ?? new PagedResponse<List<Aluno>?>(null, 400, "Falha ao buscar os alunos de uma empresa.");

        public async Task<PagedResponse<List<Aluno>?>> GetAlunoByTreinamentoAsync(GetAlunoByTreinamentoRequest request)
            => await _httpClient.GetFromJsonAsync<PagedResponse<List<Aluno>?>>($"v1/alunos/treinamento/{request.TreinamentoId}")
                ?? new PagedResponse<List<Aluno>?>(null, 400, "Falha ao buscar alunos do treinamento.");

        public async Task<Response<Aluno?>> GetByIdAsync(GetAlunoByIdRequest request)
            => await _httpClient.GetFromJsonAsync<Response<Aluno?>>($"v1/alunos/{request.Id}")
                ?? new Response<Aluno?>(null, 400, "Falha ao buscar o aluno");

        public async Task<Response<Aluno?>> UpdateAsync(UpdateAlunoRequest request)
        {
            var result = await _httpClient.PutAsJsonAsync($"v1/alunos/{request.Id}", request);
            return await result.Content.ReadFromJsonAsync<Response<Aluno?>>()
                ?? new Response<Aluno?>(null, 400, "Falha ao atualizar aluno");
        }
    }
}