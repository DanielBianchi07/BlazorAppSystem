using BlazorApp.Api.Common.Api;
using BlazorApp.Shared.Handlers;
using BlazorApp.Shared.Models;
using BlazorApp.Shared.Requests.Empresas;
using BlazorApp.Shared.Responses;

namespace BlazorApp.Api.EndPoints.Empresas
{
    public class CreateEmpresaEndPoint : IEndPoint
    {
        public static void Map(IEndpointRouteBuilder app)
        => app.MapPost("/", HandleAsync)
        .WithName("Empresas: Create")
        .WithOrder(1)
        .Produces<Response<Empresa?>>();

        private static async Task<IResult> HandleAsync(IEmpresaHandler handler, CreateEmpresaRequest request)
        {
            var response = await handler.CreateAsync(request);
            return response.IsSuccess ? TypedResults.Created($"v1/empresas/{response.Dados?.Id}", response) : TypedResults.BadRequest(response);
        }
    }
}
