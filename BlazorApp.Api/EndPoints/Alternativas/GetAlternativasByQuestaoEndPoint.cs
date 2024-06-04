using BlazorApp.Api.Common.Api;
using BlazorApp.Shared.Handlers;
using BlazorApp.Shared.Models;
using BlazorApp.Shared.Requests.Alternativas;
using BlazorApp.Shared.Responses;
using Microsoft.AspNetCore.Mvc;

namespace BlazorApp.Api.EndPoints.Alternativas
{
    public class GetAlternativasByQuestaoEndPoint : IEndPoint
    {
        public static void Map(IEndpointRouteBuilder app)
            => app.MapGet("/questao/{idQuestao}", HandleAsync)
                .WithName("Alternativa: Get By Questao")
                .WithOrder(5)
                .Produces<PagedResponse<Alternativa?>>();
        private static async Task<IResult> HandleAsync(IAlternativaHandler handler, Guid idQuestao)
        {
            var request = new GetAlternativasByQuestaoRequest { QuestaoId = idQuestao };

            var result = await handler.GetByQuestaoAsync(request);
            return result.IsSuccess ? TypedResults.Ok(result) : TypedResults.BadRequest(result);
        }
    }
}
