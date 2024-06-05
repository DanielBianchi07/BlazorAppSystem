using BlazorApp.Api.Common.Api;
using BlazorApp.Shared.Handlers;
using BlazorApp.Shared.Models;
using BlazorApp.Shared.Requests.Treinamentos;
using BlazorApp.Shared.Responses;

namespace BlazorApp.Api.EndPoints.Treinamentos
{
    public class GetTreinamentoByDateEndPoint : IEndPoint
    {
        public static void Map(IEndpointRouteBuilder app)
            => app.MapGet("/data/{dataInicial}-{dataFinal}", HandleAsync)
                .WithName("Treinamento: Get By Date")
                .WithOrder(8)
                .Produces<PagedResponse<List<Treinamento>?>>();
        private static async Task<IResult> HandleAsync(ITreinamentoHandler handler, DateTime dataInicial, DateTime dataFinal)
        {
            var request = new GetTreinamentoByDateRequest { StartDate = dataInicial, EndDate = dataFinal };

            var result = await handler.GetByDateAsync(request);
            return result.IsSuccess ? TypedResults.Ok(result) : TypedResults.BadRequest(result);
        }
    }
}
