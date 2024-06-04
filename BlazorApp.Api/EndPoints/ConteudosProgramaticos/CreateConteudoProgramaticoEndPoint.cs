using BlazorApp.Api.Common.Api;
using BlazorApp.Shared.Handlers;
using BlazorApp.Shared.Models;
using BlazorApp.Shared.Requests.ConteudosProgramaticos;
using BlazorApp.Shared.Responses;
using Microsoft.AspNetCore.Builder;

namespace BlazorApp.Api.EndPoints.ConteudosProgramaticos
{
    public class CreateConteudoProgramaticoEndPoint : IEndPoint
    {
        public static void Map(IEndpointRouteBuilder app)
            => app.MapPost("/", HandleAsync)
            .WithName("ConteudoProgramatico: Create")
            .WithOrder(1)
            .Produces<Response<ConteudoProgramatico?>>();

        private static async Task<IResult> HandleAsync(IConteudoProgramaticoHandler handler, CreateConteudoProgramaticoRequest request)
        {
            var response = await handler.CreateAsync(request);
            return response.IsSuccess ? TypedResults.Created($"v1/conteudo-programatico/{response.Dados?.Id}", response) : TypedResults.BadRequest(response);
        }
    }
}