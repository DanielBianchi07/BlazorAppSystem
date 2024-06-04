using BlazorApp.Api.Common.Api;
using BlazorApp.Shared.Handlers;
using BlazorApp.Shared.Models;
using BlazorApp.Shared.Requests.Cursos;
using BlazorApp.Shared.Responses;
using Microsoft.AspNetCore.Builder;

namespace BlazorApp.Api.EndPoints.Cursos
{
    public class CreateCursoEndPoint : IEndPoint
    {
        public static void Map(IEndpointRouteBuilder app)
            => app.MapPost("/", HandleAsync)
            .WithName("Cursos: Create")
            .WithOrder(1)
            .Produces<Response<Curso?>>();

        private static async Task<IResult> HandleAsync(ICursoHandler handler, CreateCursoRequest request)
        {
            var response = await handler.CreateAsync(request);
            return response.IsSuccess ? TypedResults.Created($"v1/cursos/{response.Dados?.Id}", response) : TypedResults.BadRequest(response);
        }
    }
}