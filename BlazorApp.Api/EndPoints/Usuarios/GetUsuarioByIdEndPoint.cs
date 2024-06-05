using BlazorApp.Api.Common.Api;
using BlazorApp.Shared.Handlers;
using BlazorApp.Shared.Models;
using BlazorApp.Shared.Requests.Questoes;
using BlazorApp.Shared.Requests.Usuarios;
using BlazorApp.Shared.Responses;

namespace BlazorApp.Api.EndPoints.Usuarios
{
    public class GetUsuarioByIdEndPoint : IEndPoint
    {
        public static void Map(IEndpointRouteBuilder app)
            => app.MapGet("/{id}", HandleAsync)
                .WithName("Usuario: Get By Id")
                .WithOrder(5)
                .Produces<Response<Usuario?>>();
        private static async Task<IResult> HandleAsync(IUsuarioHandler handler, Guid id)
        {
            var request = new GetusuarioByIdRequest { Id = id };

            var result = await handler.GetByIdAsync(request);
            return result.IsSuccess ? TypedResults.Ok(result) : TypedResults.BadRequest(result);
        }
    }
}
