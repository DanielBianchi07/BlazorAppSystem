using BlazorApp.Api.Common.Api;
using BlazorApp.Shared.Handlers;
using BlazorApp.Shared.Models;
using BlazorApp.Shared.Requests.Treinamentos;
using BlazorApp.Shared.Responses;

namespace BlazorApp.Api.EndPoints.Treinamentos
{
    public class GetTreinamentoByAlunoByDateEndPoint : IEndPoint
    {
        public static void Map(IEndpointRouteBuilder app)
            => app.MapGet("/aluno/{alunoId}/data/{dataInicial}-{dataFinal}", HandleAsync)
                .WithName("Treinamento: Get By Aluno By Date")
                .WithOrder(6)
                .Produces<PagedResponse<List<Treinamento>?>>();
        private static async Task<IResult> HandleAsync(ITreinamentoHandler handler, Guid alunoId, DateTime dataInicial, DateTime dataFinal)
        {
            var request = new GetTreinamentoByAlunoByDateRequest { AlunoId = alunoId, StartDate = dataInicial, EndDate = dataFinal };

            var result = await handler.GetTreinamentoByAlunoByDateAsync(request);
            return result.IsSuccess ? TypedResults.Ok(result) : TypedResults.BadRequest(result);
        }
    }
}
