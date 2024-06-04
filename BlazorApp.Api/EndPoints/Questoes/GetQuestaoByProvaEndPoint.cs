using BlazorApp.Api.Common.Api;
using BlazorApp.Shared.Handlers;
using BlazorApp.Shared.Models;
using BlazorApp.Shared.Requests.Questoes;
using BlazorApp.Shared.Responses;

namespace BlazorApp.Api.EndPoints.Questoes
{
    public class GetQuestaoByProvaEndPoint : IEndPoint
    {
        public static void Map(IEndpointRouteBuilder app)
            => app.MapGet("/prova/{provaId}", HandleAsync)
                .WithName("Questao: Get By Prova")
                .WithOrder(4)
                .Produces<PagedResponse<List<Questao>?>>();
        private static async Task<IResult> HandleAsync(IQuestaoHandler handler, Guid provaId)
        {
            var request = new GetQuestaoByProvaRequest {  ProvaId = provaId };
            var result = await handler.GetByProvaAsync(request);
            return result.IsSuccess ? TypedResults.Ok(result) : TypedResults.BadRequest(result);
        }
    }
}
