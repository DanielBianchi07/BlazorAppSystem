using BlazorApp.Api.Common.Api;
using BlazorApp.Shared.Handlers;
using BlazorApp.Shared.Models;
using BlazorApp.Shared.Requests.Certificados;
using BlazorApp.Shared.Responses;
using Microsoft.AspNetCore.Mvc;

namespace BlazorApp.Api.EndPoints.Certificados
{
    public class GetCertificadoByIdEndPoint : IEndPoint
    {
        public static void Map(IEndpointRouteBuilder app)
            => app.MapGet("/{treinamentoId}/{codigo}", HandleAsync)
                .WithName("Certificado: Get By Id")
                .WithOrder(5)
                .Produces<Response<Certificado?>>();
        private static async Task<IResult> HandleAsync(ICertificadoHandler handler, Guid treinamentoId, string codigo)
        {
            var request = new GetCertificadoByIdRequest { TreinamentoId = treinamentoId, Codigo = codigo };

            var result = await handler.GetByIdAsync(request);
            return result.IsSuccess ? TypedResults.Ok(result) : TypedResults.BadRequest(result);
        }
    }
}