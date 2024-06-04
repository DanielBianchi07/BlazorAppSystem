using BlazorApp.Api.Common.Api;
using BlazorApp.Shared.Handlers;
using BlazorApp.Shared.Models;
using BlazorApp.Shared.Requests.Empresas;
using BlazorApp.Shared.Responses;

namespace BlazorApp.Api.EndPoints.Empresas
{
    public class GetAllEmpresaEndPoint : IEndPoint
    {
        public static void Map(IEndpointRouteBuilder app)
            => app.MapGet("/", HandleAsync)
                .WithName("Empresa: Get All Empresa")
                .WithOrder(4)
                .Produces<PagedResponse<List<Empresa>?>>();
        private static async Task<IResult> HandleAsync(IEmpresaHandler handler)
        {
            var request = new GetAllEmpresasRequest();

            var result = await handler.GetAllAsync(request);
            return result.IsSuccess ? TypedResults.Ok(result) : TypedResults.BadRequest(result);
        }
    }
}
