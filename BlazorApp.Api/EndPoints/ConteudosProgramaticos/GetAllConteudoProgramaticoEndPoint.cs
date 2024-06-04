using BlazorApp.Api.Common.Api;
using BlazorApp.Shared.Handlers;
using BlazorApp.Shared.Models;
using BlazorApp.Shared.Requests.Certificados;
using BlazorApp.Shared.Requests.ConteudosProgramaticos;
using BlazorApp.Shared.Responses;

namespace BlazorApp.Api.EndPoints.ConteudosProgramaticos
{
    public class GetAllConteudoProgramaticoEndPoint : IEndPoint
    {
        public static void Map(IEndpointRouteBuilder app)
            => app.MapGet("/", HandleAsync)
                .WithName("ConteudoProgramatico: Get All Conteudos")
                .WithOrder(4)
                .Produces<PagedResponse<List<ConteudoProgramatico>?>>();
        private static async Task<IResult> HandleAsync(IConteudoProgramaticoHandler handler)
        {
            var request = new GetAllConteudosProgramaticosRequest();

            var result = await handler.GetAllAsync(request);
            return result.IsSuccess ? TypedResults.Ok(result) : TypedResults.BadRequest(result);
        }
    }
}
