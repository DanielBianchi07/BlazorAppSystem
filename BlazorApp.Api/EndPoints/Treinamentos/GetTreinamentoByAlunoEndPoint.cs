using BlazorApp.Api.Common.Api;
using BlazorApp.Shared.Handlers;
using BlazorApp.Shared.Models;
using BlazorApp.Shared.Requests.Treinamentos;
using BlazorApp.Shared.Responses;

namespace BlazorApp.Api.EndPoints.Treinamentos
{
    public class GetTreinamentoByAlunoEndPoint : IEndPoint
    {
        public static void Map(IEndpointRouteBuilder app)
            => app.MapGet("/aluno/{alunoId}", HandleAsync)
                .WithName("Treinamento: Get By Aluno")
                .WithOrder(7)
                .Produces<PagedResponse<List<Treinamento>?>>();
        private static async Task<IResult> HandleAsync(ITreinamentoHandler handler, Guid alunoId)
        {
            var request = new GetTreinamentoByAlunoRequest { AlunoId = alunoId };

            var result = await handler.GetTreinamentoByAlunoAsync(request);
            return result.IsSuccess ? TypedResults.Ok(result) : TypedResults.BadRequest(result);
        }
    }
}
