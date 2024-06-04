using BlazorApp.Api.Common.Api;
using BlazorApp.Shared.Handlers;
using BlazorApp.Shared.Models;
using BlazorApp.Shared.Requests.ListasPresencas;
using BlazorApp.Shared.Responses;
using Microsoft.AspNetCore.Mvc;

namespace BlazorApp.Api.EndPoints.ListasPresencas
{
    public class GetAllListaPresencaEndPoint : IEndPoint
    {
        public static void Map(IEndpointRouteBuilder app)
            => app.MapGet("/", HandleAsync)
                .WithName("ListaPresenca: Get All Listas de Presenças")
                .WithOrder(6)
                .Produces<PagedResponse<List<ListaPresenca>?>>();
        private static async Task<IResult> HandleAsync(IListaPresencaHandler handler)
        {
            var request = new GetAllListaPresencaRequest();

            var result = await handler.GetAllAsync(request);
            return result.IsSuccess ? TypedResults.Ok(result) : TypedResults.BadRequest(result);
        }
    }
}