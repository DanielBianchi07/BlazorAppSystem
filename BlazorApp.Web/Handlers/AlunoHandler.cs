using BlazorApp.Api.Data;
using BlazorApp.Shared.Handlers;
using BlazorApp.Shared.Models;
using BlazorApp.Shared.Requests.Alunos;
using BlazorApp.Shared.Requests.Empresas;
using BlazorApp.Shared.Responses;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp.Api.Handlers
{
    public class AlunoHandler(AppDbContext context) : IAlunoHandler
    {
        public async Task<Response<Aluno?>> CreateAsync(CreateAlunoRequest request)
        {
            var aluno = new Aluno
            {
                UsuarioId = request.UsuarioId,
                Nome = request.Nome,
                Cpf = request.Cpf,
                Rg = request.Rg,
                Email = request.Email,
                Telefone = request.Telefone,
                Assinatura = request.Assinatura
            };

            try
            {
                await context.Alunos.AddAsync(aluno);
                await context.SaveChangesAsync();

                var alunoEmpresa = new AlunoEmpresa
                {
                    AlunoId = aluno.Id,
                    EmpresaId = request.EmpresaId
                };

                await context.AlunosEmpresas.AddAsync(alunoEmpresa);
                await context.SaveChangesAsync();

                return new Response<Aluno?>(aluno, 201, "Aluno cadastrado com sucesso!");
            }
            catch
            {
                return new Response<Aluno?>(null, 500, "Não foi possível cadastrar o aluno");
            }
        }

        public async Task<Response<Aluno?>> DeleteAsync(DeleteAlunoRequest request)
        {
            try
            {
                var aluno = await context.Alunos.FirstOrDefaultAsync(x => x.Id == request.Id);

                if (aluno == null)
                    return new Response<Aluno?>(null, 404, "Aluno não encontrado");

                context.Alunos.Remove(aluno);
                await context.SaveChangesAsync();

                return new Response<Aluno?>(aluno, message: "Aluno removido com sucesso!");
            }
            catch
            {
                return new Response<Aluno?>(null, 500, "Não foi possível remover o aluno");
            }
        }

        public Task<PagedResponse<List<Aluno>?>> GetAllAsync(GetAllAlunoRequest request)
        {
            throw new NotImplementedException();
        }

        public async Task<PagedResponse<List<Aluno>?>> GetByEmpresaAsync(GetAlunosByEmpresaRequest request)
        {
            try
            {
                var query = context.Alunos
                    .AsNoTracking()
                    .Where(aluno => context.AlunosEmpresas
                    .Any(ae => ae.AlunoId == aluno.Id && ae.EmpresaId == request.EmpresaId))
                    .OrderBy(aluno => aluno.Nome);

                var alunoEmpresa = await query
                    .Skip((request.PageNumber - 1) * request.PageSize)
                    .Take(request.PageSize)
                    .ToListAsync();

                var count = await query.CountAsync();

                return new PagedResponse<List<Aluno>?>(alunoEmpresa, count, request.PageNumber, request.PageSize);
            }
            catch
            {
                return new PagedResponse<List<Aluno>?>(null, 500, "Não foi possível encontrar alunos");
            }
        }

        public async Task<Response<Aluno?>> GetByIdAsync(GetAlunoByIdRequest request)
        {
            try
            {
                var aluno = await context
                    .Alunos
                    .AsNoTracking()
                    .FirstOrDefaultAsync(x => x.Id == request.Id);

                return aluno is null
                    ? new Response<Aluno?>(null, 404, "Aluno não encontrado")
                    : new Response<Aluno?>(aluno);
            }
            catch
            {
                return new Response<Aluno?>(null, 500, "Não foi possível encontrar o aluno");
            }
        }

        public async Task<Response<List<Aluno>?>> GetByTreinamentoAsync(GetAlunosByTreinamentoRequest request)
        {
            try
            {
                var query = context.Alunos
                    .AsNoTracking()
                    .Where(aluno => context.TreinamentosAlunos
                    .Any(ae => ae.AlunoId == aluno.Id && ae.TreinamentoId == request.TreinamentoId))
                    .OrderBy(aluno => aluno.Nome);

                var alunoEmpresa = await query
                    .Skip((request.PageNumber - 1) * request.PageSize)
                    .Take(request.PageSize)
                    .ToListAsync();

                var count = await query.CountAsync();

                return new PagedResponse<List<Aluno>?>(alunoEmpresa, count, request.PageNumber, request.PageSize);
            }
            catch
            {
                return new PagedResponse<List<Aluno>?>(null, 500, "Não foi possível encontrar os alunos");
            }
        }

        public async Task<Response<Aluno?>> UpdateAsync(UpdateAlunoRequest request)
        {
            try
            {
                var aluno = await context.Alunos.FirstOrDefaultAsync(x => x.Id == request.Id);

                if (aluno == null)
                    return new Response<Aluno?>(null, 404, "Aluno não encontrado");
                aluno.UsuarioId = request.UsuarioId;
                aluno.Nome = request.Nome;
                aluno.Cpf = request.Cpf;
                aluno.Rg = request.Rg;
                aluno.Email = request.Email;
                aluno.Telefone = request.Telefone;
                aluno.Assinatura = request.Assinatura;

                context.Alunos.Update(aluno);
                await context.SaveChangesAsync();

                return new Response<Aluno?>(aluno, message: "Aluno atualizada com sucesso!");
            }
            catch
            {
                return new Response<Aluno?>(null, 500, "Não foi possível atualizar o aluno");
            }
        }
    }
}
