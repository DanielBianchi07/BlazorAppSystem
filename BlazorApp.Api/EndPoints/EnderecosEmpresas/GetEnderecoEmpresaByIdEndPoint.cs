using BlazorApp.Api.Common.Api;
using BlazorApp.Shared.Handlers;
using BlazorApp.Shared.Models;
using BlazorApp.Shared.Requests.EnderecosEmpresas;
using BlazorApp.Shared.Responses;
using Microsoft.AspNetCore.Mvc;

namespace BlazorApp.Api.EndPoints.EnderecosEmpresas
{
    public class GetEnderecoEmpresaByIdEndPoint : IEndPoint
    {
        public static void Map(IEndpointRouteBuilder app)
            => app.MapGet("/{empresaId}", HandleAsync)
                .WithName("EnderecoEmpresa: Get By Id")
                .WithOrder(4)
                .Produces<Response<EnderecoEmpresa?>>();
        private static async Task<IResult> HandleAsync(IEnderecoEmpresaHandler handler, Guid empresaId)
        {
            var request = new GetEnderecoEmpresaByIdRequest { EmpresaId = empresaId };

            var result = await handler.GetByIdAsync(request);
            return result.IsSuccess ? TypedResults.Ok(result) : TypedResults.BadRequest(result);
        }
    }
}