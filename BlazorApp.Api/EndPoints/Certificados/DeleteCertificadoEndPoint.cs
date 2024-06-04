using BlazorApp.Api.Common.Api;
using BlazorApp.Shared.Handlers;
using BlazorApp.Shared.Models;
using BlazorApp.Shared.Requests.Certificados;
using BlazorApp.Shared.Responses;
using Microsoft.AspNetCore.Mvc;

namespace BlazorApp.Api.EndPoints.Certificados
{
    public class DeleteCertificadoEndPoint : IEndPoint
    {
        public static void Map(IEndpointRouteBuilder app)
            => app.MapDelete("/{treinamentoId}/{codigo}", HandleAsync)
            .WithName("Certificado: Delete")
            .WithOrder(3)
            .Produces<Response<Certificado?>>();

        private static async Task<IResult> HandleAsync(ICertificadoHandler handler, Guid treinamentoId, string codigo)
        {
            var request = new DeleteCertificadoRequest { TreinamentoId = treinamentoId, Codigo = codigo };

            var result = await handler.DeleteAsync(request);
            return result.IsSuccess ? TypedResults.Ok(result) : TypedResults.BadRequest(result);
        }
    }
}