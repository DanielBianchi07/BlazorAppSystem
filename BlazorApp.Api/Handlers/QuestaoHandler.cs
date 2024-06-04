using BlazorApp.Api.Data;
using BlazorApp.Shared.Handlers;
using BlazorApp.Shared.Models;
using BlazorApp.Shared.Requests.Questoes;
using BlazorApp.Shared.Responses;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp.Api.Handlers
{
    public class QuestaoHandler(AppDbContext context) : IQuestaoHandler
    {
        public async Task<Response<Questao?>> CreateAsync(CreateQuestaoRequest request)
        {
            var prova = await context.Provas.FindAsync(request.ProvaId);
            if (prova == null)
            {
                return new Response<Questao?>(null, message: "Prova não encontrada");
            }

            var questao = new Questao
            {
                UsuarioId = request.UsuarioId,
                Conteudo = request.Conteudo,
                Status = request.Status,
                ProvaId = request.ProvaId
            };
            context.Questoes.Add(questao);
            await context.SaveChangesAsync();

            return new Response<Questao?>(questao, message: "Questao cadastrada com sucesso!");
        }

        public async Task<Response<Questao?>> DeleteAsync(DeleteQuestaoRequest request)
        {
            try
            {
                var questao = await context.Questoes.FirstOrDefaultAsync(x => x.Id == request.Id);

                if (questao == null)
                    return new Response<Questao?>(null, 404, "Conteúdo Programático não encontrado para remoção");
                questao.Status = Shared.Enums.EAtivoInativo.Inativo;
                context.Questoes.Update(questao);
                await context.SaveChangesAsync();

                return new Response<Questao?>(questao, message: "Conteúdo Programático removido com sucesso!");
            }
            catch
            {
                return new Response<Questao?>(null, 500, "Não foi possível remover o Conteúdo Programático.");
            }
        }

        public async Task<Response<Questao?>> GetByIdAsync(GetQuestaoByIdRequest request)
        {
            try
            {
                var questao = await context
                    .Questoes
                    .AsNoTracking()
                    .FirstOrDefaultAsync(x => x.Id == request.Id);

                return questao is null
                    ? new Response<Questao?>(null, 404, "Questao não encontrado pelo id.")
                    : new Response<Questao?>(questao);
            }
            catch
            {
                return new Response<Questao?>(null, 500, "Não foi possível encontrar a questao pelo id.");
            }
        }

        public async Task<PagedResponse<List<Questao>?>> GetByProvaAsync(GetQuestaoByProvaRequest request)
        {
            try
            {
                var query = context.Questoes.AsNoTracking().Where(x => x.ProvaId == request.ProvaId).OrderBy(x => x.Prova);

                var questao = await query
                    .Skip((request.PageNumber - 1) * request.PageSize)
                    .Take(request.PageSize)
                    .ToListAsync();

                var count = await query.CountAsync();

                return new PagedResponse<List<Questao>?>(questao, count, request.PageNumber, request.PageSize);
            }
            catch
            {
                return new PagedResponse<List<Questao>?>(null, 500, "Não foi possível encontrar conteúdos programático pelo curso requerido.");
            }
        }

        public async Task<Response<Questao?>> UpdateAsync(UpdateQuestaoRequest request)
        {
            try
            {
                var questao = await context.Questoes.FirstOrDefaultAsync(x => x.Id == request.Id);

                if (questao == null)
                    return new Response<Questao?>(null, 404, "Questao não encontrada para atualizar.");
                questao.UsuarioId = request.UsuarioId;
                questao.Conteudo = request.Conteudo;
                questao.Status = request.Status;

                context.Questoes.Update(questao);
                await context.SaveChangesAsync();

                return new Response<Questao?>(questao, message: "Questao atualizada com sucesso!");
            }
            catch
            {
                return new Response<Questao?>(null, 500, "Não foi possível atualizar a Questao.");
            }
        }
    }
}
