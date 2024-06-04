using BlazorApp.Api.Common.Api;
using BlazorApp.Shared.Handlers;
using BlazorApp.Shared.Models;
using BlazorApp.Shared.Requests.Instrutores;
using BlazorApp.Shared.Responses;
using Microsoft.AspNetCore.Mvc;

namespace BlazorApp.Api.EndPoints.Instrutores
{
    public class GetAllInstrutorEndPoint : IEndPoint
    {
        public static void Map(IEndpointRouteBuilder app)
            => app.MapGet("/", HandleAsync)
                .WithName("Instrutor: Get All Instrutores")
                .WithOrder(5)
                .Produces<Response<Instrutor?>>();
        private static async Task<IResult> HandleAsync(IInstrutorHandler handler)
        {
            var request = new GetAllInstrutorRequest();

            var result = await handler.GetAllAsync(request);
            return result.IsSuccess ? TypedResults.Ok(result) : TypedResults.BadRequest(result);
        }
    }
}