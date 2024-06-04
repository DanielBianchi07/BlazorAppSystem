using BlazorApp.Api.Common.Api;
using BlazorApp.Shared.Handlers;
using BlazorApp.Shared.Models;
using BlazorApp.Shared.Requests.Certificados;
using BlazorApp.Shared.Responses;
using Microsoft.AspNetCore.Builder;

namespace BlazorApp.Api.EndPoints.Certificados
{
    public class CreateCertificadoEndPoint : IEndPoint
    {
        public static void Map(IEndpointRouteBuilder app)
            => app.MapPost("/", HandleAsync)
            .WithName("Certificados: Create")
            .WithOrder(1)
            .Produces<Response<Certificado?>>();

        private static async Task<IResult> HandleAsync(ICertificadoHandler handler, CreateCertificadoRequest request)
        {
            var response = await handler.CreateAsync(request);
            return response.IsSuccess ? TypedResults.Created($"v1/certificados/{response.Dados?.TreinamentoId}", response) : TypedResults.BadRequest(response);
        }
    }
}