using BlazorApp.Api.Data;
using BlazorApp.Shared.Handlers;
using BlazorApp.Shared.Models;
using BlazorApp.Shared.Requests.Treinamentos;
using BlazorApp.Shared.Responses;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp.Api.Handlers
{
    public class TreinamentoHandler(AppDbContext context) : ITreinamentoHandler
    {
        public async Task<Response<Treinamento?>> CreateAsync(CreateTreinamentoRequest request)
        {
            var treinamento = new Treinamento
            {
                CreatedBy = request.UsuarioId,
                Instrutores = new List<Instrutor>(),
                Empresas = new List<Empresa>(),
                Alunos = new List<Aluno>(),
                CursoId = request.CursoId,
                Situacao = request.Situacao,
                Status = request.Status,
                Tipo = request.Tipo,
                DataCriacao = request.DataCriacao
            };
            List<Guid> alunos = request.AlunosId;
            List<Guid> empresas = request.EmpresasId;
            List<Guid> instrutores = request.InstrutoresId;
            // alunos
            if (alunos == null)
            {
                return new Response<Treinamento?>(null, message: "Nenhum aluno para adicionar ao treinamento");
            }
            else
            {
                foreach (var aln in alunos)
                {
                    var aluno = await context.Alunos.FindAsync(aln);
                    if (aluno != null)
                    {
                        treinamento.Alunos.Add(aluno);
                    }
                }
            }
            //empresas
            if (empresas == null)
            {
                return new Response<Treinamento?>(null, message: "Nenhuma empresa para adicionar ao treinamento");
            }
            else
            {
                foreach (var emp in empresas)
                {
                    var empresa = await context.Empresas.FindAsync(emp);
                    if (empresa != null)
                    {
                        treinamento.Empresas.Add(empresa);
                    }
                }
            }
            // instrutores
            if (instrutores == null)
            {
                return new Response<Treinamento?>(null, message: "Nenhum instrutor para adicionar ao treinamento");
            }
            else
            {
                foreach (var aln in instrutores)
                {
                    var instrutor = await context.Instrutores.FindAsync(aln);
                    if (instrutor != null)
                    {
                        treinamento.Instrutores.Add(instrutor);
                    }
                }
            }

            context.Treinamentos.Add(treinamento);
            await context.SaveChangesAsync();

            return new Response<Treinamento?>(treinamento, message: "Treinamento cadastrado com sucesso!");
        }

        public async Task<Response<Treinamento?>> DeleteAsync(DeleteTreinamentoRequest request)
        {
            try
            {
                var treinamento = await context.Treinamentos.FirstOrDefaultAsync(x => x.Id == request.Id);

                if (treinamento == null)
                    return new Response<Treinamento?>(null, 404, "Treinamento não encontrado para remoção");
                treinamento.Status = Shared.Enums.EAtivoInativo.Inativo;
                context.Treinamentos.Update(treinamento);
                await context.SaveChangesAsync();

                return new Response<Treinamento?>(treinamento, message: "Treinamento removido com sucesso!");
            }
            catch
            {
                return new Response<Treinamento?>(null, 500, "Não foi possível remover o Treinamento.");
            }
        }

        public async Task<PagedResponse<List<Treinamento>?>> GetAllAsync(GetAllTreinamentosRequest request)
        {
            try
            {
                var query = context
                    .Treinamentos
                    .AsNoTracking()
                    .OrderBy(x => x.DataCriacao);

                var treinamento = await query
                    .Skip((request.PageNumber - 1) * request.PageSize)
                    .Take(request.PageSize)
                    .ToListAsync();

                var count = await query.CountAsync();
                return new PagedResponse<List<Treinamento>?>(treinamento, count, request.PageNumber, request.PageSize);
            }
            catch
            {
                return new PagedResponse<List<Treinamento>?>(null, 500, "Não foi possível encontrar os treinamentos.");
            }
        }

        public async Task<PagedResponse<List<Treinamento>?>> GetByDateAsync(GetTreinamentoByDateRequest request)
        {
            try
            {
                var query = context.Treinamentos.AsNoTracking().Where(x => x.DataCriacao <= request.EndDate && x.DataCriacao >= request.StartDate).OrderBy(x => x.DataCriacao);

                var treinamentos = await query
                    .Skip((request.PageNumber - 1) * request.PageSize)
                    .Take(request.PageSize)
                    .ToListAsync();

                var count = await query.CountAsync();

                return new PagedResponse<List<Treinamento>?>(treinamentos, count, request.PageNumber, request.PageSize);
            }
            catch
            {
                return new PagedResponse<List<Treinamento>?>(null, 500, "Não foi possível encontrar treinamentos pela data requerida.");
            }
        }

        public async Task<Response<Treinamento?>> GetByIdAsync(GetTreinamentoByIdRequest request)
        {
            try
            {
                var treinamento = await context
                    .Treinamentos
                    .AsNoTracking()
                    .FirstOrDefaultAsync(x => x.Id == request.Id);

                return treinamento is null
                    ? new Response<Treinamento?>(null, 404, "Treinamento não encontrado pelo id.")
                    : new Response<Treinamento?>(treinamento);
            }
            catch
            {
                return new Response<Treinamento?>(null, 500, "Não foi possível encontrar o treinamento pelo id.");
            }
        }

        public async Task<PagedResponse<List<Treinamento>?>> GetTreinamentoByAlunoAsync(GetTreinamentoByAlunoRequest request)
        {
            try
            {
                var query = context
                .Treinamentos
                .AsNoTracking()
                .Where(x => x.Alunos.Any(aluno => aluno.Id == request.AlunoId));

                var treinamentos = await query
                    .Skip((request.PageNumber - 1) * request.PageSize)
                    .Take(request.PageSize)
                    .ToListAsync();

                var count = await query.CountAsync();
                return new PagedResponse<List<Treinamento>?>(treinamentos, count, request.PageNumber, request.PageSize);
            }
            catch
            {
                return new PagedResponse<List<Treinamento>?>(null, 500, "Não foi possível encontrar os treinamentos e os alunos");
            }
        }

        public async Task<PagedResponse<List<Treinamento>?>> GetTreinamentoByAlunoByDateAsync(GetTreinamentoByAlunoByDateRequest request)
        {
            try
            {
                var query = context
                .Treinamentos
                .AsNoTracking()
                .Where(x => x.Alunos.Any(aluno => aluno.Id == request.AlunoId) && x.DataCriacao <= request.EndDate && x.DataCriacao >= request.StartDate);

                var treinamentos = await query
                    .Skip((request.PageNumber - 1) * request.PageSize)
                    .Take(request.PageSize)
                    .ToListAsync();

                var count = await query.CountAsync();
                return new PagedResponse<List<Treinamento>?>(treinamentos, count, request.PageNumber, request.PageSize);
            }
            catch
            {
                return new PagedResponse<List<Treinamento>?>(null, 500, "Não foi possível encontrar os treinamentos e os alunos");
            }
        }

        public async Task<PagedResponse<List<Treinamento>?>> GetTreinamentoByEmpresaAsync(GetTreinamentoByEmpresaRequest request)
        {
            try
            {
                var query = context
                .Treinamentos
                .AsNoTracking()
                .Where(x => x.Empresas.Any(empresa => empresa.Id == request.EmpresaId));

                var treinamentos = await query
                    .Skip((request.PageNumber - 1) * request.PageSize)
                    .Take(request.PageSize)
                    .ToListAsync();

                var count = await query.CountAsync();
                return new PagedResponse<List<Treinamento>?>(treinamentos, count, request.PageNumber, request.PageSize);
            }
            catch
            {
                return new PagedResponse<List<Treinamento>?>(null, 500, "Não foi possível encontrar os treinamentos e as empresas");
            }
        }

        public async Task<PagedResponse<List<Treinamento>?>> GetTreinamentoByEmpresaByDateAsync(GetTreinamentoByEmpresaByDateRequest request)
        {
            try
            {
                var query = context
                .Treinamentos
                .AsNoTracking()
                .Where(x => x.Empresas.Any(empresa => empresa.Id == request.EmpresaId) && x.DataCriacao <= request.EndDate && x.DataCriacao >= request.StartDate);

                var treinamentos = await query
                    .Skip((request.PageNumber - 1) * request.PageSize)
                    .Take(request.PageSize)
                    .ToListAsync();

                var count = await query.CountAsync();
                return new PagedResponse<List<Treinamento>?>(treinamentos, count, request.PageNumber, request.PageSize);
            }
            catch
            {
                return new PagedResponse<List<Treinamento>?>(null, 500, "Não foi possível encontrar os treinamentos e as empresas");
            }
        }

        public async Task<PagedResponse<List<Treinamento>?>> GetTreinamentoByInstrutorAsync(GetTreinamentoByInstrutorRequest request)
        {
            try
            {
                var query = context
                .Treinamentos
                .AsNoTracking()
                .Where(x => x.Instrutores.Any(instrutor => instrutor.Id == request.InstrutorId));

                var treinamentos = await query
                    .Skip((request.PageNumber - 1) * request.PageSize)
                    .Take(request.PageSize)
                    .ToListAsync();

                var count = await query.CountAsync();
                return new PagedResponse<List<Treinamento>?>(treinamentos, count, request.PageNumber, request.PageSize);
            }
            catch
            {
                return new PagedResponse<List<Treinamento>?>(null, 500, "Não foi possível encontrar os treinamentos e os instrutores");
            }
        }

        public async Task<PagedResponse<List<Treinamento>?>> GetTreinamentoByInstrutorByDateAsync(GetTreinamentoByInstrutorByDateRequest request)
        {
            try
            {
                var query = context
                .Treinamentos
                .AsNoTracking()
                .Where(x => x.Instrutores.Any(instrutor => instrutor.Id == request.InstrutorId) && x.DataCriacao <= request.EndDate && x.DataCriacao >= request.StartDate);

                var treinamentos = await query
                    .Skip((request.PageNumber - 1) * request.PageSize)
                    .Take(request.PageSize)
                    .ToListAsync();

                var count = await query.CountAsync();
                return new PagedResponse<List<Treinamento>?>(treinamentos, count, request.PageNumber, request.PageSize);
            }
            catch
            {
                return new PagedResponse<List<Treinamento>?>(null, 500, "Não foi possível encontrar os treinamentos e os instrutores");
            }
        }

        public async Task<PagedResponse<List<Treinamento>?>> GetTreinamentoBySitucaoAsync(GetTreinamentoBySituacaoRequest request)
        {
            try
            {
                var query = context.Treinamentos.AsNoTracking().Where(x => x.Situacao == request.Situacao);

                var treinamentos = await query
                        .Skip((request.PageNumber - 1) * request.PageSize)
                        .Take(request.PageSize)
                        .ToListAsync();

                var count = await query.CountAsync();
                return new PagedResponse<List<Treinamento>?>(treinamentos, count, request.PageNumber, request.PageSize);
            }
            catch
            {
                return new PagedResponse<List<Treinamento>?>(null, 500, "Não foi possível encontrar os treinamentos e os instrutores");
            }
        }

        public async Task<Response<Treinamento?>> UpdateAsync(UpdateTreinamentoRequest request)
        {
            try
            {
                var treinamento = await context
                    .Treinamentos
                    .FirstOrDefaultAsync(x => x.Id == request.Id);

                if (treinamento == null)
                    return new Response<Treinamento?>(null, 404, "Treinamento não encontrado para atualizar.");

                treinamento.Status = request.Status;
                treinamento.DataAlteracao = request.DataAlteracao;
                treinamento.UpdatedBy = request.UsuarioId;

                context.Treinamentos.Update(treinamento);
                await context.SaveChangesAsync();

                return new Response<Treinamento?>(treinamento, message: "Treinamento atualizado com sucesso!");
            }
            catch
            {
                return new Response<Treinamento?>(null, 500, "Não foi possível atualizar o treinamento.");
            }
        }
    }
}
