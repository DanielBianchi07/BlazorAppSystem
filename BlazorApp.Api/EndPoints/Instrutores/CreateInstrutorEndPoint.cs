using BlazorApp.Api.Common.Api;
using BlazorApp.Shared.Handlers;
using BlazorApp.Shared.Models;
using BlazorApp.Shared.Requests.Instrutores;
using BlazorApp.Shared.Responses;
using Microsoft.AspNetCore.Builder;


namespace BlazorApp.Api.EndPoints.Instrutores
{
    public class CreateInstrutorEndPoint : IEndPoint
    {
        public static void Map(IEndpointRouteBuilder app)
            => app.MapPost("/", HandleAsync)
            .WithName("Instrutor: Create")
            .WithOrder(1)
            .Produces<Response<Instrutor?>>();

        private static async Task<IResult> HandleAsync(IInstrutorHandler handler, CreateInstrutorRequest request)
        {
            var response = await handler.CreateAsync(request);
            return response.IsSuccess ? TypedResults.Created($"v1/instrutores/{response.Dados?.Id}", response) : TypedResults.BadRequest(response);
        }
    }
}