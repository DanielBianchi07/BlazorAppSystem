using BlazorApp.Api.Common.Api;
using BlazorApp.Shared.Handlers;
using BlazorApp.Shared.Models;
using BlazorApp.Shared.Requests.ConteudosProgramaticos;
using BlazorApp.Shared.Requests.Questoes;
using BlazorApp.Shared.Responses;

namespace BlazorApp.Api.EndPoints.Questoes
{
    public class CreateQuestaoEndPoint : IEndPoint
    {
        public static void Map(IEndpointRouteBuilder app)
            => app.MapPost("/", HandleAsync)
            .WithName("Questao: Create")
            .WithOrder(1)
            .Produces<Response<Questao?>>();

        private static async Task<IResult> HandleAsync(IQuestaoHandler handler, CreateQuestaoRequest request)
        {
            var response = await handler.CreateAsync(request);
            return response.IsSuccess ? TypedResults.Created($"v1/questao/{response.Dados?.Id}", response) : TypedResults.BadRequest(response);
        }
    }
}
