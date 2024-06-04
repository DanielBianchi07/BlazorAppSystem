using BlazorApp.Api.Data;
using BlazorApp.Shared.Handlers;
using BlazorApp.Shared.Models;
using BlazorApp.Shared.Requests.Alternativas;
using BlazorApp.Shared.Responses;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;

namespace BlazorApp.Api.Handlers
{
    public class AlternativaHandler(AppDbContext context) : IAlternativaHandler
    {
        public async Task<Response<Alternativa?>> CreateAsync(CreateAlternativaRequest request)
        {
            var alternativa = new Alternativa
            {
                QuestaoId = request.QuestaoId,
                Conteudo = request.Conteudo,
                Resposta = request.Resposta,
                Status = request.Status,
                UsuarioId = request.UsuarioId,
            };

            try
            {
                await context.Alternativas.AddAsync(alternativa);
                await context.SaveChangesAsync();

                return new Response<Alternativa?>(alternativa, 201, "Alternativa cadastrada com sucesso!");
            }
            catch
            {
                return new Response<Alternativa?>(null, 500, "Não foi possível cadastrar a alternativa");
            }
        }

        public async Task<Response<Alternativa?>> DeleteAsync(DeleteAlternativaRequest request)
        {
            try
            {
                var alternativa = await context.Alternativas.FirstOrDefaultAsync(x => x.Id == request.Id);
                
                if (alternativa == null)
                    return new Response<Alternativa?>(null, 404, "Alternativa não encontrada para remoção");
                alternativa.Status = Shared.Enums.EAtivoInativo.Inativo;
                context.Alternativas.Update(alternativa);
                await context.SaveChangesAsync();

                return new Response<Alternativa?>(alternativa, message: "Alternativa inativada com sucesso!");
            }
            catch
            {
                return new Response<Alternativa?>(null, 500, "Não foi possível inativar a alternativa");
            }
        }

        public async Task<PagedResponse<List<Alternativa>?>> GetByQuestaoAsync(GetAlternativasByQuestaoRequest request)
        {
            try
            {
                var query = context.Alternativas.AsNoTracking().Where(x => x.QuestaoId == request.QuestaoId).OrderBy(x => x.Questao);

                var alternativaQuestao = await query
                    .Skip((request.PageNumber - 1) * request.PageSize)
                    .Take(request.PageSize)
                    .ToListAsync();

                var count = await query.CountAsync();

                return new PagedResponse<List<Alternativa>?>(alternativaQuestao, count, request.PageNumber, request.PageSize);
            }
            catch
            {
                return new PagedResponse<List<Alternativa>?>(null, 500, "Não foi possível encontrar alternativas pela questao");
            }
        }

        public async Task<Response<Alternativa?>> GetByIdAsync(GetAlternativaByIdRequest request)
        {
            try
            {
                var alternativa = await context
                    .Alternativas
                    .AsNoTracking()
                    .FirstOrDefaultAsync(x => x.Id == request.Id);

                return alternativa is null
                    ? new Response<Alternativa?>(null, 404, "Alternativa não encontrada pelo id")
                    : new Response<Alternativa?>(alternativa);
            }
            catch
            {
                return new Response<Alternativa?>(null, 500, "Não foi possível encontrar a alternativa pelo id");
            }
        }

        public async Task<Response<Alternativa?>> UpdateAsync(UpdateAlternativaRequest request)
        {
            try
            {
                var alternativa = await context.Alternativas.FirstOrDefaultAsync(x => x.Id == request.Id);

                if (alternativa == null)
                    return new Response<Alternativa?>(null, 404, "Alternativa não encontrada para atualizar");
                alternativa.Conteudo = request.Conteudo;
                alternativa.Resposta = request.Resposta;
                alternativa.Status = request.Status;

                context.Alternativas.Update(alternativa);
                await context.SaveChangesAsync();

                return new Response<Alternativa?>(alternativa, message: "Alternativa atualizada com sucesso!");
            }
            catch
            {
                return new Response<Alternativa?>(null, 500, "Não foi possível atualizar a alternativa");
            }
        }
    }
}
