using BlazorApp.Api.Common.Api;
using BlazorApp.Shared.Handlers;
using BlazorApp.Shared.Models;
using BlazorApp.Shared.Requests.TelefonesEmpresas;
using BlazorApp.Shared.Responses;

namespace BlazorApp.Api.EndPoints.TelefonesEmpresas
{
    public class DeleteTelefoneEmpresaEndPoint : IEndPoint
    {
        public static void Map(IEndpointRouteBuilder app)
            => app.MapDelete("/{id}/{empresaId}", HandleAsync)
            .WithName("TelefoneEmpresa: Delete")
            .WithOrder(3)
            .Produces<Response<TelefoneEmpresa?>>();

        private static async Task<IResult> HandleAsync(ITelefoneEmpresaHandler handler, Guid id, Guid empresaId)
        {
            var request = new DeleteTelefoneEmpresaRequest { Id = id, EmpresaId = empresaId };

            var result = await handler.DeleteAsync(request);
            return result.IsSuccess ? TypedResults.Ok(result) : TypedResults.BadRequest(result);
        }
    }
}