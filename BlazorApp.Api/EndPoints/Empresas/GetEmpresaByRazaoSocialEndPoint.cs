using BlazorApp.Api.Common.Api;
using BlazorApp.Shared.Handlers;
using BlazorApp.Shared.Models;
using BlazorApp.Shared.Requests.Empresas;
using BlazorApp.Shared.Responses;

namespace BlazorApp.Api.EndPoints.Empresas
{
    public class GetEmpresaByRazaoSocialEndPoint : IEndPoint
    {
        public static void Map(IEndpointRouteBuilder app)
            => app.MapGet("/razaoSocial/{razaoSocial}", HandleAsync)
                .WithName("Empresa: Get By RazaoSocial")
                .WithOrder(6)
                .Produces<Response<Empresa?>>();
        private static async Task<IResult> HandleAsync(IEmpresaHandler handler, string razaoSocial)
        {
            var request = new GetEmpresaByRazaoSocialRequest { RazaoSocial = razaoSocial };

            var result = await handler.GetByRazaoSocial(request);
            return result.IsSuccess ? TypedResults.Ok(result) : TypedResults.BadRequest(result);
        }
    }
}