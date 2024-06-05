using BlazorApp.Api.Common.Api;
using BlazorApp.Shared.Handlers;
using BlazorApp.Shared.Models;
using BlazorApp.Shared.Requests.Usuarios;
using BlazorApp.Shared.Responses;

namespace BlazorApp.Api.EndPoints.Usuarios
{
    public class GetByCredencialEndPoint : IEndPoint
    {
        public static void Map(IEndpointRouteBuilder app)
            => app.MapGet("/credencial/{email}/{senha}", HandleAsync)
                .WithName("Usuario: Get By Credencial")
                .WithOrder(7)
                .Produces<PagedResponse<List<Usuario>?>>();
        private static async Task<IResult> HandleAsync(IUsuarioHandler handler, string email, string senha)
        {
            var request = new GetUsuarioBySenhaEmailRequest { Email = email, Senha = senha };
            var result = await handler.GetByCredenciais(request);
            return result.IsSuccess ? TypedResults.Ok(result) : TypedResults.BadRequest(result);
        }
    }
}
