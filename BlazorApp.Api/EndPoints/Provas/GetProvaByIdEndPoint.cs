using BlazorApp.Api.Common.Api;
using BlazorApp.Shared.Handlers;
using BlazorApp.Shared.Models;
using BlazorApp.Shared.Requests.Provas;
using BlazorApp.Shared.Responses;

namespace BlazorApp.Api.EndPoints.Provas
{
    public class GetProvaByIdEndPoint : IEndPoint
    {
        public static void Map(IEndpointRouteBuilder app)
            => app.MapGet("/{id}", HandleAsync)
                .WithName("Prova: Get By Id")
                .WithOrder(5)
                .Produces<Response<Prova?>>();
        private static async Task<IResult> HandleAsync(IProvaHandler handler, Guid id)
        {
            var request = new GetProvaByIdRequest { Id = id };

            var result = await handler.GetByIdAsync(request);
            return result.IsSuccess ? TypedResults.Ok(result) : TypedResults.BadRequest(result);
        }
    }
}
