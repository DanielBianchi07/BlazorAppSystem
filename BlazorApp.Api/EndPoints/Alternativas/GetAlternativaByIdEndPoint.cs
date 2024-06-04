using BlazorApp.Api.Common.Api;
using BlazorApp.Shared.Handlers;
using BlazorApp.Shared.Models;
using BlazorApp.Shared.Requests.Alternativas;
using BlazorApp.Shared.Responses;
using Microsoft.AspNetCore.Mvc;

namespace BlazorApp.Api.EndPoints.Alternativas
{
    public class GetAlternativaByIdEndPoint : IEndPoint
    {
        public static void Map(IEndpointRouteBuilder app)
            => app.MapGet("/{id}", HandleAsync)
                .WithName("Alternativa: Get By Id")
                .WithOrder(4)
                .Produces<Response<Alternativa?>>();
        private static async Task<IResult> HandleAsync(IAlternativaHandler handler, Guid id)
        {
            var request = new GetAlternativaByIdRequest { Id = id};

            var result = await handler.GetByIdAsync(request);
            return result.IsSuccess ? TypedResults.Ok(result) : TypedResults.BadRequest(result);
        }
    }
}
