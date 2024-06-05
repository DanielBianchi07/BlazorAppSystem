using BlazorApp.Api.Common.Api;
using BlazorApp.Shared.Handlers;
using BlazorApp.Shared.Models;
using BlazorApp.Shared.Requests.Questoes;
using BlazorApp.Shared.Requests.Usuarios;
using BlazorApp.Shared.Responses;

namespace BlazorApp.Api.EndPoints.Usuarios
{
    public class CreateUsuarioEndPoint : IEndPoint
    {
        public static void Map(IEndpointRouteBuilder app)
            => app.MapPost("/", HandleAsync)
            .WithName("Usuario: Create")
            .WithOrder(1)
            .Produces<Response<Usuario?>>();

        private static async Task<IResult> HandleAsync(IUsuarioHandler handler, CreateUsuarioRequest request)
        {
            var response = await handler.CreateAsync(request);
            return response.IsSuccess ? TypedResults.Created($"v1/usuario/{response.Dados?.Id}", response) : TypedResults.BadRequest(response);
        }
    }
}
