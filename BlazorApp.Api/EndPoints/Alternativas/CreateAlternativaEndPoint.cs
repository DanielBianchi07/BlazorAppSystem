using BlazorApp.Api.Common.Api;
using BlazorApp.Shared.Handlers;
using BlazorApp.Shared.Models;
using BlazorApp.Shared.Requests.Alternativas;
using BlazorApp.Shared.Responses;
using Microsoft.AspNetCore.Builder;

namespace BlazorApp.Api.EndPoints.Alternativas
{
    public class CreateAlternativaEndPoint : IEndPoint
    {
        public static void Map(IEndpointRouteBuilder app)
            => app.MapPost("/", HandleAsync)
            .WithName("Alternativas: Create")
            .WithOrder(1)
            .Produces<Response<Alternativa?>>();

        private static async Task<IResult> HandleAsync(IAlternativaHandler handler, CreateAlternativaRequest request)
        {
            var response = await handler.CreateAsync(request);
            return response.IsSuccess ? TypedResults.Created($"v1/alternativas/{response.Dados?.Id}", response) : TypedResults.BadRequest(response);
        }
    }
}
