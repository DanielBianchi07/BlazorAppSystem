using BlazorApp.Api.Common.Api;
using BlazorApp.Shared.Handlers;
using BlazorApp.Shared.Models;
using BlazorApp.Shared.Requests.Provas;
using BlazorApp.Shared.Responses;

namespace BlazorApp.Api.EndPoints.Provas
{
    public class DeleteProvaEndPoint : IEndPoint
    {
        public static void Map(IEndpointRouteBuilder app)
            => app.MapDelete("/{id}", HandleAsync)
            .WithName("Prova: Delete")
            .WithOrder(3)
            .Produces<Response<Prova?>>();

        private static async Task<IResult> HandleAsync(IProvaHandler handler, Guid id)
        {
            var request = new DeleteProvaRequest { Id = id };

            var result = await handler.DeleteAsync(request);
            return result.IsSuccess ? TypedResults.Ok(result) : TypedResults.BadRequest(result);
        }
    }
}
