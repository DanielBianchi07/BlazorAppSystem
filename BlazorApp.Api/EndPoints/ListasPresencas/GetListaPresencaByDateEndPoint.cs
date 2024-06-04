using BlazorApp.Api.Common.Api;
using BlazorApp.Shared.Handlers;
using BlazorApp.Shared.Models;
using BlazorApp.Shared.Requests.ListasPresencas;
using BlazorApp.Shared.Responses;
using Microsoft.AspNetCore.Mvc;

namespace BlazorApp.Api.EndPoints.ListasPresencas
{
    public class GetListaPresencaByDateEndPoint : IEndPoint
    {
        public static void Map(IEndpointRouteBuilder app)
            => app.MapGet("/data/{dataInicial}/{dataFinal}", HandleAsync)
                .WithName("ListaPresenca: Get By Date")
                .WithOrder(5)
                .Produces<PagedResponse<List<ListaPresenca>?>>();
        private static async Task<IResult> HandleAsync(IListaPresencaHandler handler, DateTime dataInicial, DateTime dataFinal)
        {
            var request = new GetListaPresencaByDateRequest { StartDate = dataInicial, EndDate = dataFinal };

            var result = await handler.GetByDateAsync(request);
            return result.IsSuccess ? TypedResults.Ok(result) : TypedResults.BadRequest(result);
        }
    }
}