using BlazorApp.Api.Common.Api;
using BlazorApp.Shared.Handlers;
using BlazorApp.Shared.Models;
using BlazorApp.Shared.Requests.Certificados;
using BlazorApp.Shared.Requests.ConteudosProgramaticos;
using BlazorApp.Shared.Responses;

namespace BlazorApp.Api.EndPoints.ConteudosProgramaticos
{
    public class UpdateConteudoProgramaticoEndPoint : IEndPoint
    {
        public static void Map(IEndpointRouteBuilder app)
            => app.MapPut("/{id}", HandleAsync)
            .WithName("ConteudoProgramatico: Update")
            .WithOrder(2)
            .Produces<Response<ConteudoProgramatico?>>();
        private static async Task<IResult> HandleAsync(IConteudoProgramaticoHandler handler, UpdateConteudoProgramaticoRequest request, Guid id)
        {
            request.Id = id;
            var result = await handler.UpdateAsync(request);
            return result.IsSuccess ? TypedResults.Ok(result) : TypedResults.BadRequest(result);
        }
    }
}
