using BlazorApp.Api.Common.Api;
using BlazorApp.Shared.Handlers;
using BlazorApp.Shared.Models;
using BlazorApp.Shared.Requests.ConteudosProgramaticos;
using BlazorApp.Shared.Responses;

namespace BlazorApp.Api.EndPoints.ConteudosProgramaticos
{
    public class GetConteudoProgramaticoByCursoEndPoint : IEndPoint
    {
        public static void Map(IEndpointRouteBuilder app)
        => app.MapGet("/curso/{cursoId}", HandleAsync)
            .WithName("ConteudoProgramatico: Get By Curso")
            .WithOrder(5)
            .Produces<PagedResponse<List<ConteudoProgramatico>?>>();
            
        private static async Task<IResult> HandleAsync(IConteudoProgramaticoHandler handler, Guid cursoId)
        {
            var request = new GetConteudoProgramaticoByCursoRequest { CursoId = cursoId };

            var result = await handler.GetByCursoAsync(request);
            return result.IsSuccess ? TypedResults.Ok(result) : TypedResults.BadRequest(result);
        }
    }
}
