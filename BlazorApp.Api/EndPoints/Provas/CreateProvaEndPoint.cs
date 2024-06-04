using BlazorApp.Api.Common.Api;
using BlazorApp.Shared.Handlers;
using BlazorApp.Shared.Models;
using BlazorApp.Shared.Requests.Provas;
using BlazorApp.Shared.Responses;

namespace BlazorApp.Api.EndPoints.Provas
{
    public class CreateProvaEndPoint : IEndPoint
    {
        public static void Map(IEndpointRouteBuilder app)
            => app.MapPost("/", HandleAsync)
            .WithName("Provas: Create")
            .WithOrder(1)
            .Produces<Response<Prova?>>();

        private static async Task<IResult> HandleAsync(IProvaHandler handler, CreateProvaRequest request)
        {
            var response = await handler.CreateAsync(request);
            return response.IsSuccess ? TypedResults.Created($"v1/provas/{response.Dados?.Id}", response) : TypedResults.BadRequest(response);
        }
    }
}
