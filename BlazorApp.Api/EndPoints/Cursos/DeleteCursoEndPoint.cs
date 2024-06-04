using BlazorApp.Api.Common.Api;
using BlazorApp.Shared.Handlers;
using BlazorApp.Shared.Models;
using BlazorApp.Shared.Requests.Cursos;
using BlazorApp.Shared.Responses;

namespace BlazorApp.Api.EndPoints.Cursos
{
    public class DeleteCursoEndPoint : IEndPoint
    {
        public static void Map(IEndpointRouteBuilder app)
            => app.MapDelete("/{id}", HandleAsync)
            .WithName("Curso: Delete")
            .WithOrder(3)
            .Produces<Response<Curso?>>();

        private static async Task<IResult> HandleAsync(ICursoHandler handler, Guid id)
        {
            var request = new DeleteCursoRequest { Id = id };

            var result = await handler.DeleteAsync(request);
            return result.IsSuccess ? TypedResults.Ok(result) : TypedResults.BadRequest(result);
        }
    }
}