using BlazorApp.Api.Common.Api;
using BlazorApp.Shared.Handlers;
using BlazorApp.Shared.Models;
using BlazorApp.Shared.Requests.Empresas;
using BlazorApp.Shared.Responses;

namespace BlazorApp.Api.EndPoints.Empresas
{
    public class GetEmpresaByIdEndPoint : IEndPoint
    {
        public static void Map(IEndpointRouteBuilder app)
            => app.MapGet("/{id}", HandleAsync)
                .WithName("Empresa: Get By Id")
                .WithOrder(5)
                .Produces<Response<Empresa?>>();
        private static async Task<IResult> HandleAsync(IEmpresaHandler handler, Guid id)
        {
            var request = new GetEmpresaByIdRequest { Id = id };

            var result = await handler.GetByIdAsync(request);
            return result.IsSuccess ? TypedResults.Ok(result) : TypedResults.BadRequest(result);
        }
    }
}
