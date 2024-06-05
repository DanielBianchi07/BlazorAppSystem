using BlazorApp.Api.Data;
using BlazorApp.Shared.Enums;
using BlazorApp.Shared.Handlers;
using BlazorApp.Shared.Models;
using BlazorApp.Shared.Requests.ListasPresencas;
using BlazorApp.Shared.Responses;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;

namespace BlazorApp.Api.Handlers
{
    public class listaPresencaHandler(AppDbContext context) : IListaPresencaHandler
    {
        public async Task<Response<ListaPresenca?>> CreateAsync(CreateListaPresencaRequest request)
        {
            var listaPresenca = new ListaPresenca()
            {
                TreinamentoId = request.TreinamentoId,
                Codigo = request.Codigo,
                DataCriacao = request.DataCriacao,
                Situacao = request.Situacao,
                CreatedBy = request.UsuarioId,
            };

            try
            {
                await context.ListasPresenca.AddAsync(listaPresenca);
                await context.SaveChangesAsync();

                return new Response<ListaPresenca?>(listaPresenca, 201, "Lista de Presença cadastrada com sucesso!");
            }
            catch
            {
                return new Response<ListaPresenca?>(null, 500, "Não foi possível cadastrar a lista de presença.");
            }
        }

        public async Task<Response<ListaPresenca?>> DeleteAsync(DeleteListaPresencaRequest request)
        {
            try
            {
                var listaPresenca = await context.ListasPresenca.FirstOrDefaultAsync(x => x.TreinamentoId == request.TreinamentoId && x.Codigo == request.Codigo);

                if (listaPresenca == null)
                    return new Response<ListaPresenca?>(null, 404, "Lista de presença não encontrada para remoção");
                listaPresenca.Situacao = ESituacaoCertificado.Cancelado;
                context.ListasPresenca.Update(listaPresenca);
                await context.SaveChangesAsync();

                return new Response<ListaPresenca?>(listaPresenca, message: "Lista de presença removida com sucesso!");
            }
            catch
            {
                return new Response<ListaPresenca?>(null, 500, "Não foi possível remover a lista de presença.");
            }
        }

        public async Task<PagedResponse<List<ListaPresenca>?>> GetAllAsync(GetAllListaPresencaRequest request)
        {
            try
            {
                var query = context
                    .ListasPresenca
                    .AsNoTracking()
                    .OrderBy(x => x.DataCriacao);

                var listaPresencas = await query
                    .Skip((request.PageNumber - 1) * request.PageSize)
                    .Take(request.PageSize)
                    .ToListAsync();

                var count = await query.CountAsync();
                return new PagedResponse<List<ListaPresenca>?>(listaPresencas, count, request.PageNumber, request.PageSize);
            }
            catch
            {
                return new PagedResponse<List<ListaPresenca>?>(null, 500, "Não foi possível encontrar as listas de presença.");
            }
        }

        public async Task<Response<ListaPresenca?>> GetByIdAsync(GetListaPresencaByIdRequest request)
        {
            try
            {
                var listaPresenca= await context
                    .ListasPresenca
                    .AsNoTracking()
                    .FirstOrDefaultAsync(x => x.TreinamentoId == request.TreinamentoId && x.Codigo == request.Codigo);

                return listaPresenca is null
                    ? new Response<ListaPresenca?>(null, 404, "Lista de presença não encontrada pelo id.")
                    : new Response<ListaPresenca?>(listaPresenca);
            }
            catch
            {
                return new Response<ListaPresenca?>(null, 500, "Não foi possível encontrar a lista de presença pelo id.");
            }
        }

        public async Task<PagedResponse<List<ListaPresenca>?>> GetByDateAsync(GetListaPresencaByDateRequest request)
        {
            try
            {
                var query = context.ListasPresenca.AsNoTracking().Where(x => x.DataCriacao <= request.EndDate && x.DataCriacao >= request.StartDate).OrderBy(x => x.DataCriacao);

                var listaPresenca = await query
                    .Skip((request.PageNumber - 1) * request.PageSize)
                    .Take(request.PageSize)
                    .ToListAsync();

                var count = await query.CountAsync();

                return new PagedResponse<List<ListaPresenca>?>(listaPresenca, count, request.PageNumber, request.PageSize);
            }
            catch
            {
                return new PagedResponse<List<ListaPresenca>?>(null, 500, "Não foi possível encontrar lista de presença pela data requerida.");
            }
        }

        public async Task<Response<ListaPresenca?>> UpdateAsync(UpdateListaPresencaRequest request)
        {
            try
            {
                var listaPresenca = await context.ListasPresenca.FirstOrDefaultAsync(x => x.TreinamentoId == request.TreinamentoId && x.Codigo == request.Codigo);

                if (listaPresenca == null)
                    return new Response<ListaPresenca?>(null, 404, "Lista de presença não encontrada para atualizar.");
                listaPresenca.DataAlteracao = request.DataAlteracao;
                listaPresenca.DataInicioTreinamento = request.DataInicioTreinamento;
                listaPresenca.Situacao = request.Situacao;
                listaPresenca.UpdatedBy = request.UsuarioId;

                context.ListasPresenca.Update(listaPresenca);
                await context.SaveChangesAsync();

                return new Response<ListaPresenca?>(listaPresenca, message: "Lista de presença atualizada com sucesso!");
            }
            catch
            {
                return new Response<ListaPresenca?>(null, 500, "Não foi possível atualizar a lista de presença.");
            }
        }
    }
}