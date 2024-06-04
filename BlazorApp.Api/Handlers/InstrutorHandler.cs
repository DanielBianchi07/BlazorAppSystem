using BlazorApp.Api.Data;
using BlazorApp.Shared.Handlers;
using BlazorApp.Shared.Models;
using BlazorApp.Shared.Requests.Instrutores;
using BlazorApp.Shared.Responses;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;

namespace BlazorApp.Api.Handlers
{
    public class InstrutorHandler(AppDbContext context) : IInstrutorHandler
    {
        public async Task<Response<Instrutor?>> CreateAsync(CreateInstrutorRequest request)
        {
            var instrutor = new Instrutor()
            {
                Nome = request.Nome,
                Cpf = request.Cpf,
                Especializacao = request.Especializacao,
                Registro = request.Registro,
                Email = request.Email,
                Telefone = request.Telefone,
                Assinatura = request.Assinatura,
                Status = request.Status,
                DataCriacao = request.DataCriacao,
                UsuarioId = request.UsuarioId
            };

            try
            {
                await context.Instrutores.AddAsync(instrutor);
                await context.SaveChangesAsync();

                return new Response<Instrutor?>(instrutor, 201, "Instrutor cadastrado com sucesso!");
            }
            catch
            {
                return new Response<Instrutor?>(null, 500, "Não foi possível cadastrar o instrutor.");
            }
        }

        public async Task<Response<Instrutor?>> DeleteAsync(DeleteInstrutorRequest request)
        {
            try
            {
                var instrutor = await context.Instrutores.FirstOrDefaultAsync(x => x.Id == request.Id);

                if (instrutor == null)
                    return new Response<Instrutor?>(null, 404, "Instrutor não encontrado para remoção");
                instrutor.Status = Shared.Enums.EAtivoInativo.Inativo;
                context.Instrutores.Update(instrutor);
                await context.SaveChangesAsync();

                return new Response<Instrutor?>(instrutor, message: "Instrutor removido com sucesso!");
            }
            catch
            {
                return new Response<Instrutor?>(null, 500, "Não foi possível remover o Instrutor.");
            }
        }

        public async Task<PagedResponse<List<Instrutor>?>> GetAllAsync(GetAllInstrutorRequest request)
        {
            try
            {
                var query = context
                    .Instrutores
                    .AsNoTracking()
                    .OrderBy(x => x.DataCriacao);

                var instrutor = await query
                    .Skip((request.PageNumber - 1) * request.PageSize)
                    .Take(request.PageSize)
                    .ToListAsync();

                var count = await query.CountAsync();
                return new PagedResponse<List<Instrutor>?>(instrutor, count, request.PageNumber, request.PageSize);
            }
            catch
            {
                return new PagedResponse<List<Instrutor>?>(null, 500, "Não foi possível encontrar os instrutores.");
            }
        }

        public async Task<PagedResponse<List<Instrutor>?>> GetByEspecializacaoAsync(GetInstrutorByEspecializacaoRequest request)
        {
            try
            {
                var query = context.Instrutores.AsNoTracking().Where(x => x.Especializacao == request.Especializacao).OrderBy(x => x.DataCriacao);

                var instrutor = await query
                    .Skip((request.PageNumber - 1) * request.PageSize)
                    .Take(request.PageSize)
                    .ToListAsync();

                var count = await query.CountAsync();

                return new PagedResponse<List<Instrutor>?>(instrutor, count, request.PageNumber, request.PageSize);
            }
            catch
            {
                return new PagedResponse<List<Instrutor>?>(null, 500, "Não foi possível encontrar instrutor pela especialização requerida.");
            }
        }

        public async Task<Response<Instrutor?>> GetByIdAsync(GetInstrutorByIdRequest request)
        {
            try 
            {
                var instrutor = await context
                    .Instrutores
                    .AsNoTracking()
                    .FirstOrDefaultAsync(x => x.Id == request.Id);

                return instrutor is null
                    ? new Response<Instrutor?>(null, 404, "Instrutor não encontrado pelo id.")
                    : new Response<Instrutor?>(instrutor);
            }
            catch
            {
                return new Response<Instrutor?>(null, 500, "Não foi possível encontrar o instrutor pelo id.");
            }
        }

        public async Task<PagedResponse<List<Instrutor>?>> GetByTreinamentoAsync(GetInstrutorByTreinamentoRequest request)
        {
            try
            {
                var query = context
                    .Instrutores
                    .AsNoTracking()
                    .Where(x => x.Treinamentos.Any(treinamento => treinamento.Id == request.TreinamentoId));

                var instrutores = await query
                    .Skip((request.PageNumber - 1) * request.PageSize)
                    .Take(request.PageSize)
                    .ToListAsync();

                var count = await query.CountAsync();

                return new PagedResponse<List<Instrutor>?>(instrutores, count, request.PageNumber, request.PageSize);
            }
            catch
            {
                return new PagedResponse<List<Instrutor>?>(null, 500, "Não foi possível encontrar instrutor pelo treinamento requerido.");
            }
        }

        public async Task<Response<Instrutor?>> UpdateAsync(UpdateInstrutorRequest request)
        {
            try
            {
                var instrutor = await context
                    .Instrutores
                    .FirstOrDefaultAsync(x => x.Id == request.Id);

                if (instrutor == null)
                    return new Response<Instrutor?>(null, 404, "Instrutor não encontrado para atualizar.");
                instrutor.Nome = request.Nome;
                instrutor.Cpf = request.Cpf;
                instrutor.Especializacao = request.Especializacao;
                instrutor.Registro = request.Registro;
                instrutor.Email = request.Email;
                instrutor.Telefone = request.Telefone;
                instrutor.Assinatura = request.Assinatura;
                instrutor.Status = request.Status;
                instrutor.DataAlteracao = request.DataAlteracao;
                instrutor.UsuarioId = request.UsuarioId;

                context.Instrutores.Update(instrutor);
                await context.SaveChangesAsync();

                return new Response<Instrutor?>(instrutor, message: "Instrutor atualizado com sucesso!");
            }
            catch
            {
                return new Response<Instrutor?>(null, 500, "Não foi possível atualizar o instrutor.");
            }
        }
    }
}