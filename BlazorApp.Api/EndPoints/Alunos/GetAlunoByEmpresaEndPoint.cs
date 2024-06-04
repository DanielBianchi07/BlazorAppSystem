using BlazorApp.Api.Common.Api;
using BlazorApp.Shared.Handlers;
using BlazorApp.Shared.Models;
using BlazorApp.Shared.Requests.Alunos;
using BlazorApp.Shared.Responses;
using Microsoft.AspNetCore.Mvc;

namespace BlazorApp.Api.EndPoints.Alunos
{
    public class GetAlunoByEmpresaEndPoint : IEndPoint
    {
        public static void Map(IEndpointRouteBuilder app)
            => app.MapGet("/empresa/{empresaId}", HandleAsync)
                .WithName("Aluno: Get By Empresa")
                .WithOrder(6)
                .Produces<PagedResponse<List<Aluno>?>>();
        private static async Task<IResult> HandleAsync(IAlunoHandler handler, Guid empresaId)
        {
            var request = new GetAlunoByEmpresaRequest { EmpresaId = empresaId };

            var result = await handler.GetAlunoByEmpresaAsync(request);
            return result.IsSuccess ? TypedResults.Ok(result) : TypedResults.BadRequest(result);
        }
    }
}
