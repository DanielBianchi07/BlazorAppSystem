using BlazorApp.Api.Common.Api;
using BlazorApp.Shared.Handlers;
using BlazorApp.Shared.Models;
using BlazorApp.Shared.Requests.Provas;
using BlazorApp.Shared.Responses;

namespace BlazorApp.Api.EndPoints.Provas
{
    public class GetProvasByCursoEndPoint : IEndPoint
    {
        public static void Map(IEndpointRouteBuilder app)
            => app.MapGet("/curso/{cursoId}", HandleAsync)
                .WithName("Prova: Get By Curso")
                .WithOrder(4)
                .Produces<PagedResponse<List<Prova>?>>();
        private static async Task<IResult> HandleAsync(IProvaHandler handler, Guid cursoId)
        {
            var request = new GetProvaByCursoRequest { CursoId = cursoId};
            var result = await handler.GetByCursoAsync(request);
            return result.IsSuccess ? TypedResults.Ok(result) : TypedResults.BadRequest(result);
        }
    }
}
