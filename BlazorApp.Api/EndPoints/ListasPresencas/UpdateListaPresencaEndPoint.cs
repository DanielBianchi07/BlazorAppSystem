using BlazorApp.Api.Common.Api;
using BlazorApp.Shared.Handlers;
using BlazorApp.Shared.Models;
using BlazorApp.Shared.Requests.ListasPresencas;
using BlazorApp.Shared.Responses;
using Microsoft.AspNetCore.Mvc;

namespace BlazorApp.Api.EndPoints.ListasPresencas
{
    public class UpdateListaPresencaEndPoint : IEndPoint
    {
        public static void Map(IEndpointRouteBuilder app)
            => app.MapPut("/{treinamentoId}/{codigo}", HandleAsync)
            .WithName("ListaPresenca: Update")
            .WithOrder(2)
            .Produces<Response<ListaPresenca?>>();
        private static async Task<IResult> HandleAsync(IListaPresencaHandler handler, UpdateListaPresencaRequest request, Guid treinamentoId, string codigo)
        {
            request.TreinamentoId = treinamentoId;
            request.Codigo = codigo;
            var result = await handler.UpdateAsync(request);
            return result.IsSuccess ? TypedResults.Ok(result) : TypedResults.BadRequest(result);
        }
    }
}