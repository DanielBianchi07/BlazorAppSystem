using BlazorApp.Api.Common.Api;
using BlazorApp.Shared.Handlers;
using BlazorApp.Shared.Models;
using BlazorApp.Shared.Requests.Treinamentos;
using BlazorApp.Shared.Responses;

namespace BlazorApp.Api.EndPoints.Treinamentos
{
    public class CreateTreinamentoEndPoint : IEndPoint
    {
        public static void Map(IEndpointRouteBuilder app)
            => app.MapPost("/", HandleAsync)
            .WithName("Treinamento: Create")
            .WithOrder(1)
            .Produces<Response<Treinamento?>>();

        private static async Task<IResult> HandleAsync(ITreinamentoHandler handler, CreateTreinamentoRequest request)
        {
            var response = await handler.CreateAsync(request);
            return response.IsSuccess ? TypedResults.Created($"v1/treinamento/{response.Dados?.Id}", response) : TypedResults.BadRequest(response);
        }
    }
}
