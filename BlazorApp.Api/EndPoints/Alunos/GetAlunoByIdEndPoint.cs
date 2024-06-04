using BlazorApp.Api.Common.Api;
using BlazorApp.Shared.Handlers;
using BlazorApp.Shared.Models;
using BlazorApp.Shared.Requests.Alternativas;
using BlazorApp.Shared.Requests.Alunos;
using BlazorApp.Shared.Responses;
using Microsoft.AspNetCore.Mvc;

namespace BlazorApp.Api.EndPoints.Alunos
{
    public class GetAlunoByIdEndPoint : IEndPoint
    {
        public static void Map(IEndpointRouteBuilder app)
            => app.MapGet("/{id}", HandleAsync)
                .WithName("Aluno: Get By Id")
                .WithOrder(4)
                .Produces<Response<Aluno?>>();
        private static async Task<IResult> HandleAsync(IAlunoHandler handler, Guid id)
        {
            var request = new GetAlunoByIdRequest { Id = id };

            var result = await handler.GetByIdAsync(request);
            return result.IsSuccess ? TypedResults.Ok(result) : TypedResults.BadRequest(result);
        }
    }
}
