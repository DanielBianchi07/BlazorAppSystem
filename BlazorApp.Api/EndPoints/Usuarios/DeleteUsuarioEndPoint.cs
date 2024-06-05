using BlazorApp.Api.Common.Api;
using BlazorApp.Shared.Handlers;
using BlazorApp.Shared.Models;
using BlazorApp.Shared.Requests.Usuarios;
using BlazorApp.Shared.Responses;

namespace BlazorApp.Api.EndPoints.Usuarios
{
    public class DeleteUsuarioEndPoint : IEndPoint
    {
        public static void Map(IEndpointRouteBuilder app)
            => app.MapDelete("/{id}", HandleAsync)
            .WithName("Usuario: Delete")
            .WithOrder(3)
            .Produces<Response<Usuario?>>();

        private static async Task<IResult> HandleAsync(IUsuarioHandler handler, Guid id)
        {
            var request = new DeleteUsuarioRequest { Id = id };

            var result = await handler.DeleteAsync(request);
            return result.IsSuccess ? TypedResults.Ok(result) : TypedResults.BadRequest(result);
        }
    }
}
