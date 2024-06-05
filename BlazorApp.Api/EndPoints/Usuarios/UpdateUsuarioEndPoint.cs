using BlazorApp.Api.Common.Api;
using BlazorApp.Shared.Handlers;
using BlazorApp.Shared.Models;
using BlazorApp.Shared.Requests.Usuarios;
using BlazorApp.Shared.Responses;

namespace BlazorApp.Api.EndPoints.Usuarios
{
    public class UpdateUsuarioEndPoint : IEndPoint
    {
        public static void Map(IEndpointRouteBuilder app)
            => app.MapPut("/{id}", HandleAsync)
            .WithName("Usuario: Update")
            .WithOrder(2)
            .Produces<Response<Usuario?>>();
        private static async Task<IResult> HandleAsync(IUsuarioHandler handler, UpdateUsuarioRequest request, Guid id)
        {
            request.Id = id;
            var result = await handler.UpdateAsync(request);
            return result.IsSuccess ? TypedResults.Ok(result) : TypedResults.BadRequest(result);
        }
    }
}
