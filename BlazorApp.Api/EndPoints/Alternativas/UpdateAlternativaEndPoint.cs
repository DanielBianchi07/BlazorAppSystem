using BlazorApp.Api.Common.Api;
using BlazorApp.Shared.Handlers;
using BlazorApp.Shared.Models;
using BlazorApp.Shared.Requests.Alternativas;
using BlazorApp.Shared.Responses;
using Microsoft.AspNetCore.Mvc;

namespace BlazorApp.Api.EndPoints.Alternativas
{
    public class UpdateAlternativaEndPoint : IEndPoint
    {
        public static void Map(IEndpointRouteBuilder app)
            => app.MapPut("/{id}", HandleAsync)
            .WithName("Alternativa: Update")
            .WithOrder(2)
            .Produces<Response<Alternativa?>>();
        private static async Task<IResult> HandleAsync(IAlternativaHandler handler, UpdateAlternativaRequest request, Guid id)
        {
            request.Id = id;
            var result = await handler.UpdateAsync(request);
            return result.IsSuccess ? TypedResults.Ok(result) : TypedResults.BadRequest(result);
        }
    }
}
