using BlazorApp.Api.Common.Api;
using BlazorApp.Shared.Handlers;
using BlazorApp.Shared.Models;
using BlazorApp.Shared.Requests.Treinamentos;
using BlazorApp.Shared.Responses;

namespace BlazorApp.Api.EndPoints.Treinamentos
{
    public class GetTreinamentoByEmpresaByDateEndPoint : IEndPoint
    {
        public static void Map(IEndpointRouteBuilder app)
            => app.MapGet("/empresa/{empresaId}/data/{dataInicial}-{dataFinal}", HandleAsync)
                .WithName("Treinamento: Get By Empresa By Date")
                .WithOrder(9)
                .Produces<PagedResponse<List<Treinamento>?>>();
        private static async Task<IResult> HandleAsync(ITreinamentoHandler handler, Guid empresaId, DateTime dataInicial, DateTime dataFinal)
        {
            var request = new GetTreinamentoByEmpresaByDateRequest { EmpresaId = empresaId, StartDate = dataInicial, EndDate = dataFinal };

            var result = await handler.GetTreinamentoByEmpresaByDateAsync(request);
            return result.IsSuccess ? TypedResults.Ok(result) : TypedResults.BadRequest(result);
        }
    }
}
