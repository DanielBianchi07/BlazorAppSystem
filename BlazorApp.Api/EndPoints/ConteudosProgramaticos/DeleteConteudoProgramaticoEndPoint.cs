using BlazorApp.Api.Common.Api;
using BlazorApp.Shared.Handlers;
using BlazorApp.Shared.Models;
using BlazorApp.Shared.Requests.ConteudosProgramaticos;
using BlazorApp.Shared.Responses;

namespace BlazorApp.Api.EndPoints.ConteudosProgramaticos
{
    public class DeleteConteudoProgramaticoEndPoint : IEndPoint
    {
        public static void Map(IEndpointRouteBuilder app)
            => app.MapDelete("/{id}", HandleAsync)
            .WithName("ConteudoProgramatico: Delete")
            .WithOrder(3)
            .Produces<Response<ConteudoProgramatico?>>();

        private static async Task<IResult> HandleAsync(IConteudoProgramaticoHandler handler, Guid id)
        {
            var request = new DeleteConteudoProgramaticoRequest { Id = id };

            var result = await handler.DeleteAsync(request);
            return result.IsSuccess ? TypedResults.Ok(result) : TypedResults.BadRequest(result);
        }
    }
}
