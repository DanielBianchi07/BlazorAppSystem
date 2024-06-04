using BlazorApp.Api.Common.Api;
using BlazorApp.Shared.Handlers;
using BlazorApp.Shared.Models;
using BlazorApp.Shared.Requests.Instrutores;
using BlazorApp.Shared.Responses;
using Microsoft.AspNetCore.Mvc;

namespace BlazorApp.Api.EndPoints.Instrutores
{
    public class DeleteInstrutorEndPoint : IEndPoint
    {
        public static void Map(IEndpointRouteBuilder app)
            => app.MapDelete("/{id}", HandleAsync)
            .WithName("Instrutor: Delete")
            .WithOrder(3)
            .Produces<Response<Instrutor?>>();
        private static async Task<IResult> HandleAsync(IInstrutorHandler handler, Guid id)
        {
            var request = new DeleteInstrutorRequest { Id = id };
            var result = await handler.DeleteAsync(request);
            return result.IsSuccess ? TypedResults.Ok(result) : TypedResults.BadRequest(result);
        }
    }
}
