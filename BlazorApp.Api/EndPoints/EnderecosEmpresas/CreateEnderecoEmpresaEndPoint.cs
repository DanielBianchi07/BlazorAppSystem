using BlazorApp.Api.Common.Api;
using BlazorApp.Shared.Handlers;
using BlazorApp.Shared.Models;
using BlazorApp.Shared.Requests.EnderecosEmpresas;
using BlazorApp.Shared.Responses;
using Microsoft.AspNetCore.Builder;

namespace BlazorApp.Api.EndPoints.EnderecosEmpresas
{
    public class CreateEnderecoEmpresaEndPoint : IEndPoint
    {
        public static void Map(IEndpointRouteBuilder app)
            => app.MapPost("/", HandleAsync)
            .WithName("EnderecoEmpresa: Create")
            .WithOrder(1)
            .Produces<Response<EnderecoEmpresa?>>();

        private static async Task<IResult> HandleAsync(IEnderecoEmpresaHandler handler, CreateEnderecoEmpresaRequest request)
        {
            var response = await handler.CreateAsync(request);
            return response.IsSuccess ? TypedResults.Created($"v1/enderecos-empresas/{response.Dados?.EmpresaId}", response) : TypedResults.BadRequest(response);
        }
    }
}