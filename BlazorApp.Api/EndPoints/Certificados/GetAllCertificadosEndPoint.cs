using BlazorApp.Api.Common.Api;
using BlazorApp.Shared.Handlers;
using BlazorApp.Shared.Models;
using BlazorApp.Shared.Requests.Certificados;
using BlazorApp.Shared.Responses;
using Microsoft.AspNetCore.Mvc;

namespace BlazorApp.Api.EndPoints.Certificados
{
    public class GetAllCertificadosEndPoint : IEndPoint
    {
        public static void Map(IEndpointRouteBuilder app)
            => app.MapGet("/", HandleAsync)
                .WithName("Certificado: Get All Alunos")
                .WithOrder(4)
                .Produces<PagedResponse<List<Certificado>?>>();
        private static async Task<IResult> HandleAsync(ICertificadoHandler handler)
        {
            var request = new GetAllCertificadosRequest();

            var result = await handler.GetAllAsync(request);
            return result.IsSuccess ? TypedResults.Ok(result) : TypedResults.BadRequest(result);
        }
    }
}