using BlazorApp.Api.Common.Api;
using BlazorApp.Shared.Handlers;
using BlazorApp.Shared.Models;
using BlazorApp.Shared.Requests.Treinamentos;
using BlazorApp.Shared.Responses;

namespace BlazorApp.Api.EndPoints.Treinamentos
{
    public class GetTreinamentoByIdEndPoint : IEndPoint
    {
        public static void Map(IEndpointRouteBuilder app)
            => app.MapGet("/{id}", HandleAsync)
                .WithName("Treinamento: Get By Id")
                .WithOrder(5)
                .Produces<Response<Treinamento?>>();
        private static async Task<IResult> HandleAsync(ITreinamentoHandler handler, Guid id)
        {
            var request = new GetTreinamentoByIdRequest { Id = id };

            var result = await handler.GetByIdAsync(request);
            return result.IsSuccess ? TypedResults.Ok(result) : TypedResults.BadRequest(result);
        }
    }
}
