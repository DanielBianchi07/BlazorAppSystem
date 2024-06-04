using BlazorApp.Api.Common.Api;
using BlazorApp.Shared.Handlers;
using BlazorApp.Shared.Models;
using BlazorApp.Shared.Requests.Provas;
using BlazorApp.Shared.Responses;

namespace BlazorApp.Api.EndPoints.Provas
{
    public class GetAllProvasEndPoint : IEndPoint
    {
        public static void Map(IEndpointRouteBuilder app)
            => app.MapGet("/", HandleAsync)
                .WithName("Prova: Get All Prova")
                .WithOrder(4)
                .Produces<PagedResponse<List<Prova>?>>();
        private static async Task<IResult> HandleAsync(IProvaHandler handler)
        {
            var request = new GetAllProvasRequest();

            var result = await handler.GetAllAsync(request);
            return result.IsSuccess ? TypedResults.Ok(result) : TypedResults.BadRequest(result);
        }
    }
}
