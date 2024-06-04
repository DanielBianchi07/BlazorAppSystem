using BlazorApp.Api.Common.Api;
using BlazorApp.Shared.Handlers;
using BlazorApp.Shared.Models;
using BlazorApp.Shared.Requests.Cursos;
using BlazorApp.Shared.Responses;

namespace BlazorApp.Api.EndPoints.Cursos
{
    public class GetAllCursosEndPoint : IEndPoint
    {
        public static void Map(IEndpointRouteBuilder app)
            => app.MapGet("/", HandleAsync)
                .WithName("Curso: Get All Curso")
                .WithOrder(4)
                .Produces<PagedResponse<List<Curso>?>>();
        private static async Task<IResult> HandleAsync(ICursoHandler handler)
        {
            var request = new GetAllCursosRequest();

            var result = await handler.GetAllAsync(request);
            return result.IsSuccess ? TypedResults.Ok(result) : TypedResults.BadRequest(result);
        }
    }
}