using BlazorApp.Shared.Models;
using BlazorApp.Shared.Responses;
using System.Net.Http.Json;
using BlazorApp.Shared.Handlers;
using BlazorApp.Shared.Requests.EnderecosEmpresas;

namespace BlazorApp.Web.Handlers
{
    public class EnderecoEmpresaHandler(IHttpClientFactory httpClientFactory) : IEnderecoEmpresaHandler
    {
        private readonly HttpClient _httpClient = httpClientFactory.CreateClient(WebConfiguration.HttpClientName);
        public async Task<Response<EnderecoEmpresa?>> CreateAsync(CreateEnderecoEmpresaRequest request)
        {
            var result = await _httpClient.PostAsJsonAsync("v1/endereco-empresa", request);
            return await result.Content.ReadFromJsonAsync<Response<EnderecoEmpresa?>>()
                ?? new Response<EnderecoEmpresa?>(null, 400, "Falha ao criar endereço");
        }

        public async Task<Response<EnderecoEmpresa?>> DeleteAsync(DeleteEnderecoEmpresaRequest request)
        {
            var result = await _httpClient.DeleteAsync($"v1/endereco-emrpesa/{request.EmpresaId}");
            return await result.Content.ReadFromJsonAsync<Response<EnderecoEmpresa?>>()
                ?? new Response<EnderecoEmpresa?>(null, 400, "Falha ao inativar endereço");
        }

        public async Task<Response<EnderecoEmpresa?>> GetByIdAsync(GetEnderecoEmpresaByIdRequest request)
        => await _httpClient.GetFromJsonAsync<Response<EnderecoEmpresa?>>($"v1/endereco-empresa/{request.EmpresaId}")
                ?? new Response<EnderecoEmpresa?>(null, 400, "Falha ao buscar a endereço");

        public async Task<Response<EnderecoEmpresa?>> UpdateAsync(UpdateEnderecoEmpresaRequest request)
        {
            var result = await _httpClient.PutAsJsonAsync($"v1/endereco-empresa/{request.EmpresaId}", request);
            return await result.Content.ReadFromJsonAsync<Response<EnderecoEmpresa?>>()
                ?? new Response<EnderecoEmpresa?>(null, 400, "Falha ao atualizar endereço");
        }
    }
}
