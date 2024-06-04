using BlazorApp.Api.Common.Api;
using BlazorApp.Shared.Handlers;
using BlazorApp.Shared.Models;
using BlazorApp.Shared.Requests.Instrutores;
using BlazorApp.Shared.Responses;

namespace BlazorApp.Api.EndPoints.Instrutores
{
    public class GetInstrutorByIdEndPoint : IEndPoint
    {
        public static void Map(IEndpointRouteBuilder app)
            => app.MapGet("/{id}", HandleAsync)
                .WithName("Instrutor: Get By Id")
                .WithOrder(4)
                .Produces<Response<Instrutor?>>();
        private static async Task<IResult> HandleAsync(IInstrutorHandler handler, Guid id)
        {
            var request = new GetInstrutorByIdRequest { Id = id };

            var result = await handler.GetByIdAsync(request);
            return result.IsSuccess ? TypedResults.Ok(result) : TypedResults.BadRequest(result);
        }
    }
}