using BlazorApp.Api.Common.Api;
using BlazorApp.Shared.Handlers;
using BlazorApp.Shared.Models;
using BlazorApp.Shared.Requests.Instrutores;
using BlazorApp.Shared.Responses;

namespace BlazorApp.Api.EndPoints.Instrutores
{
    public class GetInstrutorByEspecializacaoEndPoint : IEndPoint
    {
        public static void Map(IEndpointRouteBuilder app)
            => app.MapGet("/especializacao/{especializacao}", HandleAsync)
                .WithName("Instrutor: Get By Especializacao")
                .WithOrder(6)
                .Produces<PagedResponse<List<Instrutor>?>>();
        private static async Task<IResult> HandleAsync(IInstrutorHandler handler, string especializacao)
        {
            var request = new GetInstrutorByEspecializacaoRequest { Especializacao = especializacao };

            var result = await handler.GetByEspecializacaoAsync(request);
            return result.IsSuccess ? TypedResults.Ok(result) : TypedResults.BadRequest(result);
        }
    }
}