using BlazorApp.Api.Data;
using BlazorApp.Shared.Handlers;
using BlazorApp.Shared.Models;
using BlazorApp.Shared.Requests.Alunos;
using BlazorApp.Shared.Responses;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp.Api.Handlers
{
    public class AlunoHandler(AppDbContext context) : IAlunoHandler
    {
        public async Task<Response<Aluno?>> CreateAsync(CreateAlunoRequest request)
        {
            var empresa = await context.Empresas.FindAsync(request.EmpresaId);
            if (empresa == null)
            {
                return new Response<Aluno?>(null, message: "Empresa não encontrada");
            }

            var aluno = new Aluno
            {
                Nome = request.Nome,
                Cpf = request.Cpf,
                Rg = request.Rg,
                Email = request.Email,
                Telefone = request.Telefone,
                Assinatura = request.Assinatura,
                DataCriacao = request.DataCriacao,
                CreatedBy = request.UsuarioId,
                Empresas = new List<Empresa>()
            };

            aluno.Empresas.Add(empresa); // Adicione a empresa ao aluno
            context.Alunos.Add(aluno);
            await context.SaveChangesAsync();

            return new Response<Aluno?>(aluno, message: "Aluno cadastrado com sucesso!");
        }

        public async Task<Response<Aluno?>> DeleteAsync(DeleteAlunoRequest request)
        {
            try
            {
                var aluno = await context.Alunos.FirstOrDefaultAsync(x => x.Id == request.Id);

                if (aluno == null)
                    return new Response<Aluno?>(null, 404, "Aluno não encontrado");
                aluno.Status = Shared.Enums.EAtivoInativo.Inativo;
                context.Alunos.Update(aluno);
                await context.SaveChangesAsync();

                return new Response<Aluno?>(aluno, message: "Aluno inativado com sucesso!");
            }
            catch
            {
                return new Response<Aluno?>(null, 500, "Não foi possível inativar o aluno");
            }
        }

        public async Task<PagedResponse<List<Aluno>?>> GetAllAsync(GetAllAlunoRequest request)
        {
            try
            {
                var query = context
                    .Alunos
                    .AsNoTracking()
                    .OrderBy(x => x.Nome);
                    
                var alunos = await query
                    .Skip((request.PageNumber - 1) * request.PageSize)
                    .Take(request.PageSize)
                    .ToListAsync();

                var count = await query.CountAsync();
                return new PagedResponse<List<Aluno>?>(alunos, count, request.PageNumber, request.PageSize);
            }
            catch
            {
                return new PagedResponse<List<Aluno>?>(null, 500, "Não foi possível encontrar o aluno");
            }
        }

        public async Task<PagedResponse<List<Aluno>?>> GetAlunoByEmpresaAsync(GetAlunoByEmpresaRequest request)
        {
            try
            {
                var query = context
                .Alunos
                .AsNoTracking()
                .Where(x => x.Empresas.Any(empresa => empresa.Id == request.EmpresaId));

                var alunos = await query
                    .Skip((request.PageNumber - 1) * request.PageSize)
                    .Take(request.PageSize)
                    .ToListAsync();

                var count = await query.CountAsync();
                return new PagedResponse<List<Aluno>?>(alunos, count, request.PageNumber, request.PageSize);
            }
            catch
            {
                return new PagedResponse<List<Aluno>?>(null, 500, "Não foi possível encontrar os alunos e as empresas");
            }
        }

        public async Task<PagedResponse<List<Aluno>?>> GetAlunoByTreinamentoAsync(GetAlunoByTreinamentoRequest request)
        {
            try
            {
                var query = context
                .Alunos
                .AsNoTracking()
                .Where(x => x.Treinamentos.Any(treinamento => treinamento.Id == request.TreinamentoId));

                var alunos = await query
                    .Skip((request.PageNumber - 1) * request.PageSize)
                    .Take(request.PageSize)
                    .ToListAsync();

                var count = await query.CountAsync();
                return new PagedResponse<List<Aluno>?>(alunos, count, request.PageNumber, request.PageSize);
            }
            catch
            {
                return new PagedResponse<List<Aluno>?>(null, 500, "Não foi possível encontrar os alunos e os treinamentos");
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

                var empresa = context.Empresas.AsNoTracking().Where(x => x.Alunos.Any(x => x.Id == request.Id));
                aluno.Empresas.Add(empresa.LastOrDefault());

                return aluno is null
                    ? new Response<Aluno?>(null, 404, "Aluno não encontrado")
                    : new Response<Aluno?>(aluno);
            }
            catch
            {
                return new Response<Aluno?>(null, 500, "Não foi possível encontrar o aluno");
            }
        }

        public async Task<Response<Aluno?>> UpdateAsync(UpdateAlunoRequest request)
        {
            try
            {
                var aluno = await context.Alunos.FirstOrDefaultAsync(x => x.Id == request.Id);

                if (aluno == null)
                    return new Response<Aluno?>(null, 404, "Aluno não encontrado");
                aluno.Nome = request.Nome;
                aluno.Cpf = request.Cpf;
                aluno.Rg = request.Rg;
                aluno.Email = request.Email;
                aluno.Telefone = request.Telefone;
                aluno.Assinatura = request.Assinatura;
                aluno.DataAlteracao = request.DataAlteracao;
                aluno.UpdatedBy = request.UsuarioId;

                var empresa = await context.Empresas.FindAsync(request.EmpresaId);
                if (empresa == null)
                {
                    return new Response<Aluno?>(null, message: "Empresa não encontrada");
                }
                aluno.Empresas.Add(empresa);
                context.Alunos.Update(aluno);
                await context.SaveChangesAsync();

                return new Response<Aluno?>(aluno, message: "Aluno atualizado com sucesso!");
            }
            catch
            {
                return new Response<Aluno?>(null, 500, "Não foi possível atualizar o aluno");
            }
        }
    }
}
