using BlazorApp.Api.Common.Api;
using BlazorApp.Shared.Handlers;
using BlazorApp.Shared.Models;
using BlazorApp.Shared.Requests.TelefonesEmpresas;
using BlazorApp.Shared.Responses;
using Microsoft.AspNetCore.Mvc;

namespace BlazorApp.Api.EndPoints.TelefonesEmpresas
{
    public class UpdateTelefoneEmpresaEndPoint : IEndPoint
    {
        public static void Map(IEndpointRouteBuilder app)
            => app.MapPut("/{id}", HandleAsync)
            .WithName("TelefoneEmpresa: Update")
            .WithOrder(2)
            .Produces<Response<TelefoneEmpresa?>>();
        private static async Task<IResult> HandleAsync(ITelefoneEmpresaHandler handler, UpdateTelefoneEmpresaRequest request, Guid id)
        {
            request.Id = id;
            var result = await handler.UpdateAsync(request);
            return result.IsSuccess ? TypedResults.Ok(result) : TypedResults.BadRequest(result);
        }
    }
}