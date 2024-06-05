using BlazorApp.Api.Common.Api;
using BlazorApp.Shared.Handlers;
using BlazorApp.Shared.Models;
using BlazorApp.Shared.Requests.Usuarios;
using BlazorApp.Shared.Responses;

namespace BlazorApp.Api.EndPoints.Usuarios
{
    public class GetAllUsuarioEndPoint : IEndPoint
    {
        public static void Map(IEndpointRouteBuilder app)
            => app.MapGet("/", HandleAsync)
                .WithName("Usuario: Get All Usuario")
                .WithOrder(4)
                .Produces<PagedResponse<List<Usuario>?>>();
        private static async Task<IResult> HandleAsync(IUsuarioHandler handler)
        {
            var request = new GetAllUsuarioRequest();

            var result = await handler.GetAllAsync(request);
            return result.IsSuccess ? TypedResults.Ok(result) : TypedResults.BadRequest(result);
        }
    }
}
