using BlazorApp.Api.Common.Api;
using BlazorApp.Shared.Handlers;
using BlazorApp.Shared.Models;
using BlazorApp.Shared.Requests.Alternativas;
using BlazorApp.Shared.Responses;
using Microsoft.AspNetCore.Mvc;

namespace BlazorApp.Api.EndPoints.Alternativas
{
    public class DeleteAlternativaEndPoint : IEndPoint
    {
        public static void Map(IEndpointRouteBuilder app)
            => app.MapDelete("/{id}", HandleAsync)
            .WithName("Alternativa: Delete")
            .WithOrder(3)
            .Produces<Response<Alternativa?>>();
        private static async Task<IResult> HandleAsync(IAlternativaHandler handler, Guid id)
        {
            var request = new DeleteAlternativaRequest { Id = id };

            var result = await handler.DeleteAsync(request);
            return result.IsSuccess ? TypedResults.Ok(result) : TypedResults.BadRequest(result);
        }
    }
}
