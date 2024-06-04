using BlazorApp.Api.Common.Api;
using BlazorApp.Shared.Handlers;
using BlazorApp.Shared.Models;
using BlazorApp.Shared.Requests.Cursos;
using BlazorApp.Shared.Responses;
using Microsoft.AspNetCore.Mvc;

namespace BlazorApp.Api.EndPoints.Cursos
{
    public class GetCursoByIdEndPoint : IEndPoint
    {
        public static void Map(IEndpointRouteBuilder app)
            => app.MapGet("/{id}", HandleAsync)
                .WithName("Curso: Get By Id")
                .WithOrder(5)
                .Produces<Response<Curso?>>();
        private static async Task<IResult> HandleAsync(ICursoHandler handler, Guid id)
        {
            var request = new GetCursoByIdRequest { Id = id };

            var result = await handler.GetByIdAsync(request);
            return result.IsSuccess ? TypedResults.Ok(result) : TypedResults.BadRequest(result);
        }
    }
}