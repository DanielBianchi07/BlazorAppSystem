using BlazorApp.Api.Common.Api;
using BlazorApp.Shared.Handlers;
using BlazorApp.Shared.Models;
using BlazorApp.Shared.Requests.ListasPresencas;
using BlazorApp.Shared.Responses;
using Microsoft.AspNetCore.Builder;

namespace BlazorApp.Api.EndPoints.ListasPresencas
{
    public class CreateListaPresencaEndPoint : IEndPoint
    {
        public static void Map(IEndpointRouteBuilder app)
            => app.MapPost("/", HandleAsync)
            .WithName("ListasPresenca: Create")
            .WithOrder(1)
            .Produces<Response<ListaPresenca?>>();

        private static async Task<IResult> HandleAsync(IListaPresencaHandler handler, CreateListaPresencaRequest request)
        {
            var response = await handler.CreateAsync(request);
            return response.IsSuccess ? TypedResults.Created($"v1/listas-presenca/{response.Dados?.TreinamentoId}", response) : TypedResults.BadRequest(response);
        }
    }
}