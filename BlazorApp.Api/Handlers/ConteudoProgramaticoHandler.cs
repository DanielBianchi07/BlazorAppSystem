using BlazorApp.Api.Data;
using BlazorApp.Shared.Handlers;
using BlazorApp.Shared.Models;
using BlazorApp.Shared.Requests.ConteudosProgramaticos;
using BlazorApp.Shared.Responses;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;

namespace BlazorApp.Api.Handlers
{
    public class ConteudoProgramaticoHandler(AppDbContext context) : IConteudoProgramaticoHandler
    {
        public async Task<Response<ConteudoProgramatico?>> CreateAsync(CreateConteudoProgramaticoRequest request)
        {
            var conteudoProgramatico = new ConteudoProgramatico()
            {
                CursoId = request.CursoId,
                Assunto = request.Assunto,
                CargaHoraria = request.CargaHoraria,
                DataCriacao = request.DataCriacao,
                UsuarioId = request.UsuarioId,
            };

            try
            {
                await context.ConteudosProgramatico.AddAsync(conteudoProgramatico);
                await context.SaveChangesAsync();

                return new Response<ConteudoProgramatico?>(conteudoProgramatico, 201, "Conteúdo Programático cadastrado com sucesso!");
            }
            catch
            {
                return new Response<ConteudoProgramatico?>(null, 500, "Não foi possível cadastrar o Conteúdo Programático.");
            }
        }

        public async Task<Response<ConteudoProgramatico?>> DeleteAsync(DeleteConteudoProgramaticoRequest request)
        {
            try
            {
                var conteudoProgramatico = await context.ConteudosProgramatico.FirstOrDefaultAsync(x => x.Id == request.Id);

                if (conteudoProgramatico == null)
                    return new Response<ConteudoProgramatico?>(null, 404, "Conteúdo Programático não encontrado para remoção");
                conteudoProgramatico.Status = Shared.Enums.EAtivoInativo.Inativo;
                context.ConteudosProgramatico.Update(conteudoProgramatico);
                await context.SaveChangesAsync();

                return new Response<ConteudoProgramatico?>(conteudoProgramatico, message: "Conteúdo Programático removido com sucesso!");
            }
            catch
            {
                return new Response<ConteudoProgramatico?>(null, 500, "Não foi possível remover o Conteúdo Programático.");
            }
        }

        public async Task<PagedResponse<List<ConteudoProgramatico>?>> GetAllAsync(GetAllConteudosProgramaticosRequest request)
        {
            try
            {
                var query = context
                    .ConteudosProgramatico
                    .AsNoTracking()
                    .OrderBy(x => x.DataCriacao);

                var conteudoProgramatico = await query
                    .Skip((request.PageNumber - 1) * request.PageSize)
                    .Take(request.PageSize)
                    .ToListAsync();

                var count = await query.CountAsync();
                return new PagedResponse<List<ConteudoProgramatico>?>(conteudoProgramatico, count, request.PageNumber, request.PageSize);
            }
            catch
            {
                return new PagedResponse<List<ConteudoProgramatico>?>(null, 500, "Não foi possível encontrar os Conteúdos Programáticos.");
            }
        }

        public async Task<PagedResponse<List<ConteudoProgramatico>?>> GetByCursoAsync(GetConteudoProgramaticoByCursoRequest request)
        {
            try
            {
                var query = context.ConteudosProgramatico.AsNoTracking().Where(x => x.CursoId == request.CursoId).OrderBy(x => x.DataCriacao);

                var conteudoProgramatico = await query
                    .Skip((request.PageNumber - 1) * request.PageSize)
                    .Take(request.PageSize)
                    .ToListAsync();

                var count = await query.CountAsync();

                return new PagedResponse<List<ConteudoProgramatico>?>(conteudoProgramatico, count, request.PageNumber, request.PageSize);
            }
            catch
            {
                return new PagedResponse<List<ConteudoProgramatico>?>(null, 500, "Não foi possível encontrar conteúdos programático pelo curso requerido.");
            }
        }

        public async Task<Response<ConteudoProgramatico?>> UpdateAsync(UpdateConteudoProgramaticoRequest request)
        {
            try
            {
                var conteudoProgramatico = await context.ConteudosProgramatico.FirstOrDefaultAsync(x => x.Id == request.Id);

                if (conteudoProgramatico == null)
                    return new Response<ConteudoProgramatico?>(null, 404, "Conteúdo programático não encontrado para atualizar.");
                conteudoProgramatico.Assunto = request.Assunto;
                conteudoProgramatico.CargaHoraria = request.CargaHoraria;
                conteudoProgramatico.Status = request.Status;
                conteudoProgramatico.DataAlteracao = request.DataAlteracao;
                conteudoProgramatico.UsuarioId = request.UsuarioId;

                context.ConteudosProgramatico.Update(conteudoProgramatico);
                await context.SaveChangesAsync();

                return new Response<ConteudoProgramatico?>(conteudoProgramatico, message: "Conteúdo Programático atualizado com sucesso!");
            }
            catch
            {
                return new Response<ConteudoProgramatico?>(null, 500, "Não foi possível atualizar o conteúdo programático.");
            }
        }
    }
}