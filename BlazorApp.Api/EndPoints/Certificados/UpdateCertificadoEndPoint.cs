using BlazorApp.Api.Common.Api;
using BlazorApp.Shared.Handlers;
using BlazorApp.Shared.Models;
using BlazorApp.Shared.Requests.Certificados;
using BlazorApp.Shared.Responses;
using Microsoft.AspNetCore.Mvc;

namespace BlazorApp.Api.EndPoints.Certificados
{
    public class UpdateCertificadoEndPoint : IEndPoint
    {
        public static void Map(IEndpointRouteBuilder app)
            => app.MapPut("/{treinamentoId}/{codigo}", HandleAsync)
            .WithName("Certificado: Update")
            .WithOrder(2)
            .Produces<Response<Certificado?>>();
        private static async Task<IResult> HandleAsync(ICertificadoHandler handler, UpdateCertificadoRequest request, Guid treinamentoId, string codigo)
        {
            request.TreinamentoId = treinamentoId;
            request.Codigo = codigo;    
            var result = await handler.UpdateAsync(request);
            return result.IsSuccess ? TypedResults.Ok(result) : TypedResults.BadRequest(result);
        }
    }
}