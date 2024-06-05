using BlazorApp.Api.Common.Api;
using BlazorApp.Shared.Enums;
using BlazorApp.Shared.Handlers;
using BlazorApp.Shared.Models;
using BlazorApp.Shared.Requests.Questoes;
using BlazorApp.Shared.Requests.Usuarios;
using BlazorApp.Shared.Responses;

namespace BlazorApp.Api.EndPoints.Usuarios
{
    public class GetUsuarioAdminEndPoint : IEndPoint
    {
        public static void Map(IEndpointRouteBuilder app)
            => app.MapGet("/admins/{isadmin}", HandleAsync)
                .WithName("Usuario: Get Admin")
                .WithOrder(6)
                .Produces<PagedResponse<List<Usuario>?>>();
        private static async Task<IResult> HandleAsync(IUsuarioHandler handler, EAtivoInativo isadmin)
        {
            var request = new GetUsuarioAdminRequest { IsAdmin = isadmin };
            var result = await handler.GetUsuarioAdminAsync(request);
            return result.IsSuccess ? TypedResults.Ok(result) : TypedResults.BadRequest(result);
        }
    }
}
