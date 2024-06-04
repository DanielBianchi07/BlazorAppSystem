using BlazorApp.Api.Common.Api;
using BlazorApp.Shared.Handlers;
using BlazorApp.Shared.Models;
using BlazorApp.Shared.Requests.Questoes;
using BlazorApp.Shared.Responses;

namespace BlazorApp.Api.EndPoints.Questoes
{
    public class DeleteQuestaoEndPoint : IEndPoint
    {
        public static void Map(IEndpointRouteBuilder app)
            => app.MapDelete("/{id}", HandleAsync)
            .WithName("Questao: Delete")
            .WithOrder(3)
            .Produces<Response<Questao?>>();

        private static async Task<IResult> HandleAsync(IQuestaoHandler handler, Guid id)
        {
            var request = new DeleteQuestaoRequest { Id = id };

            var result = await handler.DeleteAsync(request);
            return result.IsSuccess ? TypedResults.Ok(result) : TypedResults.BadRequest(result);
        }
    }
}
