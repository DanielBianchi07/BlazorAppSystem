using BlazorApp.Api.Common.Api;
using BlazorApp.Shared.Handlers;
using BlazorApp.Shared.Models;
using BlazorApp.Shared.Requests.Instrutores;
using BlazorApp.Shared.Responses;
using Microsoft.AspNetCore.Mvc;

namespace BlazorApp.Api.EndPoints.Instrutores
{
    public class UpdateInstrutorEndPoint : IEndPoint
    {
        public static void Map(IEndpointRouteBuilder app)
            => app.MapPut("/{id}", HandleAsync)
            .WithName("Instrutor: Update")
            .WithOrder(2)
            .Produces<Response<Instrutor?>>();
        private static async Task<IResult> HandleAsync(IInstrutorHandler handler, UpdateInstrutorRequest request, Guid id)
        {
            request.Id = id;

            var result = await handler.UpdateAsync(request);
            return result.IsSuccess ? TypedResults.Ok(result) : TypedResults.BadRequest(result);
        }
    }
}
