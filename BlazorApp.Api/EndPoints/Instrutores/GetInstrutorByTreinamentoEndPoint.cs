using BlazorApp.Api.Common.Api;
using BlazorApp.Shared.Handlers;
using BlazorApp.Shared.Models;
using BlazorApp.Shared.Requests.Instrutores;
using BlazorApp.Shared.Responses;

namespace BlazorApp.Api.EndPoints.Instrutores
{
    public class GetInstrutorByTreinamentoEndPoint : IEndPoint
    {
        public static void Map(IEndpointRouteBuilder app)
            => app.MapGet("/treinamento/{treinamentoId}", HandleAsync)
                .WithName("Instrutor: Get By Treinamento")
                .WithOrder(7)
                .Produces<PagedResponse<List<Instrutor>?>>();
        private static async Task<IResult> HandleAsync(IInstrutorHandler handler, Guid treinamentoId)
        {
            var request = new GetInstrutorByTreinamentoRequest { TreinamentoId = treinamentoId };

            var result = await handler.GetByTreinamentoAsync(request);
            return result.IsSuccess ? TypedResults.Ok(result) : TypedResults.BadRequest(result);
        }
    }
}