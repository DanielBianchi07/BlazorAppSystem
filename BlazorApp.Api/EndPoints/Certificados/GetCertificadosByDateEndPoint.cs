using BlazorApp.Api.Common.Api;
using BlazorApp.Shared.Handlers;
using BlazorApp.Shared.Models;
using BlazorApp.Shared.Requests.Certificados;
using BlazorApp.Shared.Responses;
using Microsoft.AspNetCore.Mvc;

namespace BlazorApp.Api.EndPoints.Certificados
{
    public class GetCertificadosByDateEndPoint : IEndPoint
    {
        public static void Map(IEndpointRouteBuilder app)
            => app.MapGet("/data/{dataInicial}-{dataFinal}", HandleAsync)
                .WithName("Certificado: Get By Date")
                .WithOrder(6)
                .Produces<PagedResponse<List<Certificado>?>>();
        private static async Task<IResult> HandleAsync(ICertificadoHandler handler, DateTime dataInicial, DateTime dataFinal)
        {
            var request = new GetCertificadosByDateRequest { StartDate = dataInicial, EndDate = dataFinal };

            var result = await handler.GetByDateAsync(request);
            return result.IsSuccess ? TypedResults.Ok(result) : TypedResults.BadRequest(result);
        }
    }
}