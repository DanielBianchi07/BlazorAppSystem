using BlazorApp.Shared.Handlers;
using BlazorApp.Shared.Models;
using BlazorApp.Shared.Requests.Certificados;
using BlazorApp.Shared.Responses;
using System.Net.Http.Json;

namespace BlazorApp.Web.Handlers
{
    public class CertificadoHandler(IHttpClientFactory httpClientFactory) : ICertificadoHandler
    {
        private readonly HttpClient _httpClient = httpClientFactory.CreateClient(WebConfiguration.HttpClientName);
        public async Task<Response<Certificado?>> CreateAsync(CreateCertificadoRequest request)
        {
            var result = await _httpClient.PostAsJsonAsync("v1/certificados", request);
            return await result.Content.ReadFromJsonAsync<Response<Certificado?>>()
                ?? new Response<Certificado?>(null, 400, "Falha ao criar certificado.");
        }

        public async Task<Response<Certificado?>> DeleteAsync(DeleteCertificadoRequest request)
        {
            var result = await _httpClient.DeleteAsync($"v1/certificados/{request.TreinamentoId}/{request.Codigo}");
            return await result.Content.ReadFromJsonAsync<Response<Certificado?>>()
                ?? new Response<Certificado?>(null, 400, "Falha ao inativar certificado.");
        }

        public async Task<PagedResponse<List<Certificado>?>> GetAllAsync(GetAllCertificadosRequest request)
            => await _httpClient.GetFromJsonAsync<PagedResponse<List<Certificado>?>>($"v1/certificados")
                ?? new Response<PagedResponse<List<Certificado>?>>(null, 400, "Falha ao buscar os certificados");

        public async Task<Response<Certificado?>> GetByIdAsync(GetCertificadoByIdRequest request)
            => await _httpClient.GetFromJsonAsync<Response<Certificado?>>($"v1/certificados/{request.TreinamentoId}/{request.Codigo}")
                ?? new Response<Certificado?>(null, 400, "Falha ao buscar o certificado");

     .public async Task<PagedResponse<List<Certificado>?>> GetByDateAsync(GetCertificadosByDateRequest request)
            => await _httpClient.GetFromJsonAsync<PagedResponse<List<Certificado>?>>($"v1/certificados/data/{request.StartDate}/{request.EndDate}")
                ?? new Response<PagedResponse<List<Certificado>?>>(null, 400, "Falha ao buscar certificados pela data.");


        public async Task<Response<Certificado?>> UpdateAsync(UpdateCertificadoRequest request)
        {
            var result = await _httpClient.PutAsJsonAsync($"v1/certificados/{request.TreinamentoId}", request);
            return await result.Content.ReadFromJsonAsync<Response<Certificado?>>()
                ?? new Response<Certificado?>(null, 400, "Falha ao atualizar certificado");
        }
    }
}