using BlazorApp.Api.Common.Api;
using BlazorApp.Shared.Enums;
using BlazorApp.Shared.Handlers;
using BlazorApp.Shared.Models;
using BlazorApp.Shared.Requests.Treinamentos;
using BlazorApp.Shared.Responses;

namespace BlazorApp.Api.EndPoints.Treinamentos
{
    public class GetTreinamentoBySituacaoEndPoint : IEndPoint
    {
        public static void Map(IEndpointRouteBuilder app)
            => app.MapGet("/situacao/{situacao}", HandleAsync)
                .WithName("Treinamento: Get By Situação")
                .WithOrder(13)
                .Produces<PagedResponse<List<Treinamento>?>>();
        private static async Task<IResult> HandleAsync(ITreinamentoHandler handler, ESituacaoTreinamento situacao)
        {
            var request = new GetTreinamentoBySituacaoRequest { Situacao = situacao };

            var result = await handler.GetTreinamentoBySitucaoAsync(request);
            return result.IsSuccess ? TypedResults.Ok(result) : TypedResults.BadRequest(result);
        }
    }
}
