using BlazorApp.Api.Common.Api;
using BlazorApp.Shared.Handlers;
using BlazorApp.Shared.Models;
using BlazorApp.Shared.Requests.Alunos;
using BlazorApp.Shared.Responses;
using Microsoft.AspNetCore.Builder;


namespace BlazorApp.Api.EndPoints.Alunos
{
    public class CreateAlunoEndPoint : IEndPoint
    {
        public static void Map(IEndpointRouteBuilder app)
            => app.MapPost("/", HandleAsync)
            .WithName("Alunos: Create")
            .WithOrder(1)
            .Produces<Response<Aluno?>>();

        private static async Task<IResult> HandleAsync(IAlunoHandler handler, CreateAlunoRequest request)
        {
            var response = await handler.CreateAsync(request);
            return response.IsSuccess ? TypedResults.Created($"v1/alunos/{response.Dados?.Id}", response) : TypedResults.BadRequest(response);
        }
    }
}
