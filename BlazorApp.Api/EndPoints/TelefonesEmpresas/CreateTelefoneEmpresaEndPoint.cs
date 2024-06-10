using BlazorApp.Api.Common.Api;
using BlazorApp.Shared.Handlers;
using BlazorApp.Shared.Models;
using BlazorApp.Shared.Requests.TelefonesEmpresas;
using BlazorApp.Shared.Responses;
using Microsoft.AspNetCore.Builder;

namespace BlazorApp.Api.EndPoints.TelefonesEmpresas
{
    public class CreateTelefoneEmpresaEndPoint : IEndPoint
    {
        public static void Map(IEndpointRouteBuilder app)
            => app.MapPost("/", HandleAsync)
            .WithName("TelefoneEmpresa: Create")
            .WithOrder(1)
            .Produces<Response<TelefoneEmpresa?>>();

        private static async Task<IResult> HandleAsync(ITelefoneEmpresaHandler handler, CreateTelefoneEmpresaRequest request)
        {
            var response = await handler.CreateAsync(request);
            return response.IsSuccess ? TypedResults.Created($"v1/telefones-empresas/{response.Dados?.Id}", response) : TypedResults.BadRequest(response);
        }
    }
}