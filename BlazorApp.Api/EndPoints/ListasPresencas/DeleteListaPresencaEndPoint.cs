using BlazorApp.Api.Common.Api;
using BlazorApp.Shared.Handlers;
using BlazorApp.Shared.Models;
using BlazorApp.Shared.Requests.ListasPresencas;
using BlazorApp.Shared.Responses;
using Microsoft.AspNetCore.Mvc;

namespace BlazorApp.Api.EndPoints.ListasPresencas
{
    public class DeleteListaPresencaEndPoint : IEndPoint
    {
        public static void Map(IEndpointRouteBuilder app)
            => app.MapDelete("/{treinamentoId}/{codigo}", HandleAsync)
            .WithName("ListaPresenca: Delete")
            .WithOrder(3)
            .Produces<Response<ListaPresenca?>>();

        private static async Task<IResult> HandleAsync(IListaPresencaHandler handler, Guid treinamentoId, string codigo)
        {
            var request = new DeleteListaPresencaRequest { TreinamentoId = treinamentoId, Codigo = codigo };

            var result = await handler.DeleteAsync(request);
            return result.IsSuccess ? TypedResults.Ok(result) : TypedResults.BadRequest(result);
        }
    }
}