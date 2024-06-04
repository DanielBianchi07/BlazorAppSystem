using BlazorApp.Api.Data;
using BlazorApp.Shared.Handlers;
using BlazorApp.Shared.Models;
using BlazorApp.Shared.Requests.Cursos;
using BlazorApp.Shared.Responses;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;

namespace BlazorApp.Api.Handlers
{
    public class CursoHandler(AppDbContext context) : ICursoHandler
    {
        public async Task<Response<Curso?>> CreateAsync(CreateCursoRequest request)
        {
            var curso = new Curso()
            {
                Nome = request.Nome,
                Logo = request.Logo,
                CargaHorariaInicial = request.CargaHorariaInicial,
                CargaHorariaPeriodico = request.CargaHorariaPeriodico,
                Validade = request.Validade,
                Status = request.Status,
                DataCriacao = request.DataCriacao,
                UsuarioId = request.UsuarioId
            };

            try
            {
                await context.Cursos.AddAsync(curso);
                await context.SaveChangesAsync();

                return new Response<Curso?>(curso, 201, "Curso cadastrado com sucesso!");
            }
            catch
            {
                return new Response<Curso?>(null, 500, "Não foi possível cadastrar o curso.");
            }
        }

        public async Task<Response<Curso?>> DeleteAsync(DeleteCursoRequest request)
        {
            try
            {
                var curso = await context.Cursos.FirstOrDefaultAsync(x => x.Id == request.Id);

                if (curso == null)
                    return new Response<Curso?>(null, 404, "Curso não encontrado para remoção");
                curso.Status = Shared.Enums.EAtivoInativo.Inativo;
                context.Cursos.Update(curso);
                await context.SaveChangesAsync();

                return new Response<Curso?>(curso, message: "Curso removido com sucesso!");
            }
            catch
            {
                return new Response<Curso?>(null, 500, "Não foi possível remover o curso.");
            }
        }

        public async Task<PagedResponse<List<Curso>?>> GetAllAsync(GetAllCursosRequest request)
        {
            try
            {
                var query = context
                    .Cursos
                    .AsNoTracking()
                    .OrderBy(x => x.DataCriacao);

                var cursos = await query
                    .Skip((request.PageNumber - 1) * request.PageSize)
                    .Take(request.PageSize)
                    .ToListAsync();

                var count = await query.CountAsync();
                return new PagedResponse<List<Curso>?>(cursos, count, request.PageNumber, request.PageSize);
            }
            catch
            {
                return new PagedResponse<List<Curso>?>(null, 500, "Não foi possível encontrar os cursos.");
            }
        }

        public async Task<Response<Curso?>> GetByIdAsync(GetCursoByIdRequest request)
        {
            try
            {
                var curso = await context
                    .Cursos
                    .AsNoTracking()
                    .FirstOrDefaultAsync(x => x.Id == request.Id);

                return curso is null
                    ? new Response<Curso?>(null, 404, "Curso não encontrado pelo id.")
                    : new Response<Curso?>(curso);
            }
            catch
            {
                return new Response<Curso?>(null, 500, "Não foi possível encontrar o curso pelo id.");
            }
        }

        public async Task<Response<Curso?>> UpdateAsync(UpdateCursoRequest request)
        {
            try
            {
                var curso = await context.Cursos.FirstOrDefaultAsync(x => x.Id == request.Id);

                if (curso == null)
                    return new Response<Curso?>(null, 404, "Curso não encontrado para atualizar");
                curso.Nome = request.Nome;
                curso.Logo = request.Logo;
                curso.CargaHorariaInicial = request.CargaHorariaInicial;
                curso.CargaHorariaPeriodico = request.CargaHorariaPeriodico;
                curso.Validade = request.Validade;
                curso.Status = request.Status;
                curso.DataAlteracao = request.DataAlteracao;
                curso.UsuarioId = request.UsuarioId;

                context.Cursos.Update(curso);
                await context.SaveChangesAsync();

                return new Response<Curso?>(curso, message: "Curso atualizado com sucesso!");
            }
            catch
            {
                return new Response<Curso?>(null, 500, "Não foi possível atualizar o curso.");
            }
        }
    }
}