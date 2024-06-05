using BlazorApp.Api.Common.Api;
using BlazorApp.Shared.Handlers;
using BlazorApp.Shared.Models;
using BlazorApp.Shared.Requests.Treinamentos;
using BlazorApp.Shared.Responses;

namespace BlazorApp.Api.EndPoints.Treinamentos
{
    public class GetTreinamentoByInstrutorByDateEndPoint : IEndPoint
    {
        public static void Map(IEndpointRouteBuilder app)
            => app.MapGet("/instrutor/{instrutorId}/data/{dataInicial}-{dataFinal}", HandleAsync)
                .WithName("Treinamento: Get By Instrutor By Date")
                .WithOrder(11)
                .Produces<PagedResponse<List<Treinamento>?>>();
        private static async Task<IResult> HandleAsync(ITreinamentoHandler handler, Guid instrutorId, DateTime dataInicial, DateTime dataFinal)
        {
            var request = new GetTreinamentoByInstrutorByDateRequest { InstrutorId = instrutorId, StartDate = dataInicial, EndDate = dataFinal };

            var result = await handler.GetTreinamentoByInstrutorByDateAsync(request);
            return result.IsSuccess ? TypedResults.Ok(result) : TypedResults.BadRequest(result);
        }
    }
}
