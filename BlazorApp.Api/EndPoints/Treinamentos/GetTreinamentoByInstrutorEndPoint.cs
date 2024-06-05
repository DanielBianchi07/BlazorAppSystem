using BlazorApp.Api.Common.Api;
using BlazorApp.Shared.Handlers;
using BlazorApp.Shared.Models;
using BlazorApp.Shared.Requests.Treinamentos;
using BlazorApp.Shared.Responses;

namespace BlazorApp.Api.EndPoints.Treinamentos
{
    public class GetTreinamentoByInstrutorEndPoint : IEndPoint
    {
        public static void Map(IEndpointRouteBuilder app)
            => app.MapGet("/instrutor/{instrutorId}", HandleAsync)
                .WithName("Treinamento: Get By Instrutor")
                .WithOrder(12)
                .Produces<PagedResponse<List<Treinamento>?>>();
        private static async Task<IResult> HandleAsync(ITreinamentoHandler handler, Guid instrutorId)
        {
            var request = new GetTreinamentoByInstrutorRequest { InstrutorId = instrutorId };

            var result = await handler.GetTreinamentoByInstrutorAsync(request);
            return result.IsSuccess ? TypedResults.Ok(result) : TypedResults.BadRequest(result);
        }
    }
}
