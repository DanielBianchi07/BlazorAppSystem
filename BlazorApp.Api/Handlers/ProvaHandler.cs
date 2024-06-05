using BlazorApp.Api.Data;
using BlazorApp.Shared.Handlers;
using BlazorApp.Shared.Models;
using BlazorApp.Shared.Requests.Provas;
using BlazorApp.Shared.Responses;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp.Api.Handlers
{
    public class ProvaHandler(AppDbContext context) : IProvaHandler
    {
        public async Task<Response<Prova?>> CreateAsync(CreateProvaRequest request)
        {
            var prova = new Prova()
            {
                CursoId = request.CursoId,
                DataCriacao = request.DataCriacao,
                Status = request.Status,
                CreatedBy = request.UsuarioId
            };

            try
            {
                await context.Provas.AddAsync(prova);
                await context.SaveChangesAsync();

                return new Response<Prova?>(prova, 201, "Prova cadastrada com sucesso!");
            }
            catch
            {
                return new Response<Prova?>(null, 500, "Não foi possível cadastrar a prova.");
            }
        }

        public async Task<Response<Prova?>> DeleteAsync(DeleteProvaRequest request)
        {
            try
            {
                var prova = await context.Provas.FirstOrDefaultAsync(x => x.Id == request.Id);

                if (prova == null)
                    return new Response<Prova?>(null, 404, "Prova não encontrada para remoção");
                prova.Status = Shared.Enums.EAtivoInativo.Inativo;
                context.Provas.Update(prova);
                await context.SaveChangesAsync();

                return new Response<Prova?>(prova, message: "Prova removida com sucesso!");
            }
            catch
            {
                return new Response<Prova?>(null, 500, "Não foi possível remover a prova.");
            }
        }

        public async Task<PagedResponse<List<Prova>?>> GetAllAsync(GetAllProvasRequest request)
        {
            try
            {
                var query = context
                    .Provas
                    .AsNoTracking()
                    .OrderBy(x => x.DataCriacao);

                var provas = await query
                    .Skip((request.PageNumber - 1) * request.PageSize)
                    .Take(request.PageSize)
                    .ToListAsync();

                var count = await query.CountAsync();
                return new PagedResponse<List<Prova>?>(provas, count, request.PageNumber, request.PageSize);
            }
            catch
            {
                return new PagedResponse<List<Prova>?>(null, 500, "Não foi possível encontrar as provas.");
            }
        }

        public async Task<PagedResponse<List<Prova>?>> GetByCursoAsync(GetProvaByCursoRequest request)
        {
            try
            {
                var query = context
                    .Provas
                    .AsNoTracking()
                    .Where(x => x.CursoId == request.CursoId)
                    .OrderBy(x => x.DataCriacao);

                var provas = await query
                    .Skip((request.PageNumber - 1) * request.PageSize)
                    .Take(request.PageSize)
                    .ToListAsync();

                var count = await query.CountAsync();
                return new PagedResponse<List<Prova>?>(provas, count, request.PageNumber, request.PageSize);
            }
            catch
            {
                return new PagedResponse<List<Prova>?>(null, 500, "Não foi possível encontrar os provas.");
            }
        }

        public async Task<Response<Prova?>> GetByIdAsync(GetProvaByIdRequest request)
        {
            try
            {
                var prova = await context
                    .Provas
                    .AsNoTracking()
                    .FirstOrDefaultAsync(x => x.Id == request.Id);

                return prova is null
                    ? new Response<Prova?>(null, 404, "Prova não encontrada pelo id.")
                    : new Response<Prova?>(prova);
            }
            catch
            {
                return new Response<Prova?>(null, 500, "Não foi possível encontrar a prova pelo id.");
            }
        }

        public async Task<Response<Prova?>> UpdateAsync(UpdateProvaRequest request)
        {
            try
            {
                var prova = await context.Provas.FirstOrDefaultAsync(x => x.Id == request.Id);

                if (prova == null)
                    return new Response<Prova?>(null, 404, "Prova não encontrada para atualizar");
                prova.DataAlteracao = request.DataAlteracao;
                prova.Status = request.Status;
                prova.UpdatedBy = request.UsuarioId;

                context.Provas.Update(prova);
                await context.SaveChangesAsync();

                return new Response<Prova?>(prova, message: "Prova atualizada com sucesso!");
            }
            catch
            {
                return new Response<Prova?>(null, 500, "Não foi possível atualizar a prova.");
            }
        }
    }
}
