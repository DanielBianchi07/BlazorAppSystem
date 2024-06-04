using BlazorApp.Api.Common.Api;
using BlazorApp.Shared.Handlers;
using BlazorApp.Shared.Models;
using BlazorApp.Shared.Requests.EnderecosEmpresas;
using BlazorApp.Shared.Responses;

namespace BlazorApp.Api.EndPoints.EnderecosEmpresas
{
    public class DeleteEnderecoEmpresaEndPoint : IEndPoint
    {
        public static void Map(IEndpointRouteBuilder app)
            => app.MapDelete("/{empresaId}", HandleAsync)
            .WithName("EnderecoEmpresa: Delete")
            .WithOrder(3)
            .Produces<Response<EnderecoEmpresa?>>();

        private static async Task<IResult> HandleAsync(IEnderecoEmpresaHandler handler, Guid empresaId)
        {
            var request = new DeleteEnderecoEmpresaRequest { EmpresaId = empresaId };

            var result = await handler.DeleteAsync(request);
            return result.IsSuccess ? TypedResults.Ok(result) : TypedResults.BadRequest(result);
        }
    }
}