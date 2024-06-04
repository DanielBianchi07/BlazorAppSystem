using BlazorApp.Api.Common.Api;
using BlazorApp.Shared.Handlers;
using BlazorApp.Shared.Models;
using BlazorApp.Shared.Requests.Questoes;
using BlazorApp.Shared.Responses;

namespace BlazorApp.Api.EndPoints.Questoes
{
    public class UpdateQuestaoEndPoint : IEndPoint
    {
        public static void Map(IEndpointRouteBuilder app)
            => app.MapPut("/{id}", HandleAsync)
            .WithName("Questao: Update")
            .WithOrder(2)
            .Produces<Response<Questao?>>();
        private static async Task<IResult> HandleAsync(IQuestaoHandler handler, UpdateQuestaoRequest request, Guid id)
        {
            request.Id = id;
            var result = await handler.UpdateAsync(request);
            return result.IsSuccess ? TypedResults.Ok(result) : TypedResults.BadRequest(result);
        }
    }
}
