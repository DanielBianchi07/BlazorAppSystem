using BlazorApp.Api.Common.Api;
using BlazorApp.Shared.Handlers;
using BlazorApp.Shared.Models;
using BlazorApp.Shared.Requests.Alunos;
using BlazorApp.Shared.Responses;

namespace BlazorApp.Api.EndPoints.Alunos
{
    public class GetAlunoByTreinamentoEndPoint : IEndPoint
    {
        public static void Map(IEndpointRouteBuilder app)
            => app.MapGet("/treinamento/{treinamentoId}", HandleAsync)
                .WithName("Aluno: Get By Treinamento")
                .WithOrder(7)
                .Produces<PagedResponse<List<Aluno>?>>();
        private static async Task<IResult> HandleAsync(IAlunoHandler handler, Guid treinamentoId)
        {
            var request = new GetAlunoByTreinamentoRequest { TreinamentoId = treinamentoId };

            var result = await handler.GetAlunoByTreinamentoAsync(request);
            return result.IsSuccess ? TypedResults.Ok(result) : TypedResults.BadRequest(result);
        }
    }
}
