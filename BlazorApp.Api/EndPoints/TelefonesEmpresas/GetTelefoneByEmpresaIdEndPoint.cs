using BlazorApp.Api.Common.Api;
using BlazorApp.Shared.Handlers;
using BlazorApp.Shared.Models;
using BlazorApp.Shared.Requests.TelefonesEmpresas;
using BlazorApp.Shared.Requests.Empresas;
using BlazorApp.Shared.Responses;

namespace BlazorApp.Api.EndPoints.TelefonesEmpresas
{
    public class GetTelefoneByEmpresaEndPoint : IEndPoint
    {
        public static void Map(IEndpointRouteBuilder app)
        => app.MapGet("/empresa/{empresaId}", HandleAsync)
            .WithName("Telefones: Get By Empresa")
            .WithOrder(5)
            .Produces<PagedResponse<List<TelefoneEmpresa>?>>();

        private static async Task<IResult> HandleAsync(ITelefoneEmpresaHandler handler, Guid empresaId)
        {
            var request = new GetTelefonesByEmpresasRequest();
            request.EmpresaId = empresaId;
            var result = await handler.GetByEmpresaAsync(request);
            return result.IsSuccess ? TypedResults.Ok(result) : TypedResults.BadRequest(result);
        }
    }
}