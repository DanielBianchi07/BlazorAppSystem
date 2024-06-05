using BlazorApp.Api.Common.Api;
using BlazorApp.Shared.Handlers;
using BlazorApp.Shared.Models;
using BlazorApp.Shared.Requests.EnderecosEmpresas;
using BlazorApp.Shared.Responses;
using Microsoft.AspNetCore.Mvc;

namespace BlazorApp.Api.EndPoints.EnderecosEmpresas
{
    public class UpdateEnderecoEmpresaEndPoint : IEndPoint
    {
        public static void Map(IEndpointRouteBuilder app)
            => app.MapPut("/{empresaId}", HandleAsync)
            .WithName("EnderecoEmpresa: Update")
            .WithOrder(2)
            .Produces<Response<EnderecoEmpresa?>>();
        private static async Task<IResult> HandleAsync(IEnderecoEmpresaHandler handler, UpdateEnderecoEmpresaRequest request, Guid empresaId)
        {
            request.EmpresaId = empresaId;
            var result = await handler.UpdateAsync(request);
            return result.IsSuccess ? TypedResults.Ok(result) : TypedResults.BadRequest(result);
        }
    }
}