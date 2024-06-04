using BlazorApp.Api.Data;
using BlazorApp.Shared.Handlers;
using BlazorApp.Shared.Models;
using BlazorApp.Shared.Requests.TelefonesEmpresas;
using BlazorApp.Shared.Responses;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp.Api.Handlers
{
    public class TelefoneEmpresaHandler(AppDbContext context) : ITelefoneEmpresaHandler
    {
        public async Task<Response<TelefoneEmpresa?>> CreateAsync(CreateTelefoneEmpresaRequest request)
        {
            var telefoneEmpresa = new TelefoneEmpresa
            {
                EmpresaId = request.EmpresaId,
                NroTelefone = request.NroTelefone,
                Status = request.Status,
                UsuarioId = request.UsuarioId,
            };

            try
            {
                await context.TelefonesEmpresa.AddAsync(telefoneEmpresa);
                await context.SaveChangesAsync();

                return new Response<TelefoneEmpresa?>(telefoneEmpresa, 201, "Telefone cadastrado com sucesso!");
            }
            catch
            {
                return new Response<TelefoneEmpresa?>(null, 500, "Não foi possível cadastrar o telefone.");
            }
        }

        public async Task<Response<TelefoneEmpresa?>> DeleteAsync(DeleteTelefoneEmpresaRequest request)
        {
            try
            {
                var telefoneEmpresa = await context.TelefonesEmpresa.FirstOrDefaultAsync(x => x.EmpresaId == request.EmpresaId && x.NroTelefone == request.NroTelefone);

                if (telefoneEmpresa == null)
                    return new Response<TelefoneEmpresa?>(null, 404, "Telefone não encontrado para remoção");
                telefoneEmpresa.Status = Shared.Enums.EAtivoInativo.Inativo;
                await context.SaveChangesAsync();

                return new Response<TelefoneEmpresa?>(telefoneEmpresa, message: "Telefone removido com sucesso!");
            }
            catch
            {
                return new Response<TelefoneEmpresa?>(null, 500, "Não foi possível remover o telefone.");
            }
        }

        public async Task<Response<TelefoneEmpresa?>> GetByIdAsync(GetTelefoneEmpresaByIdRequest request)
        {
            try
            {
                var telefoneEmpresa = await context
                    .TelefonesEmpresa
                    .AsNoTracking()
                    .FirstOrDefaultAsync(x => x.EmpresaId == request.EmpresaId && x.NroTelefone == request.NroTelefone);

                return telefoneEmpresa is null
                    ? new Response<TelefoneEmpresa?>(null, 404, "Telefone não encontrado pelo id.")
                    : new Response<TelefoneEmpresa?>(telefoneEmpresa);
            }
            catch
            {
                return new Response<TelefoneEmpresa?>(null, 500, "Não foi possível encontrar o telefone pelo id.");
            }
        }

        public async Task<PagedResponse<List<TelefoneEmpresa>?>> GetByEmpresaAsync(GetTelefonesByEmpresasRequest request)
        {
            try
            {
                var query = context
                .Empresas
                .AsNoTracking()
                .Where(x => x.TelefoneEmpresa.Any(telefone => telefone.EmpresaId == request.EmpresaId));

                var telefones = await query
                    .Skip((request.PageNumber - 1) * request.PageSize)
                    .Take(request.PageSize)
                    .ToListAsync();

                var count = await query.CountAsync();
                return new PagedResponse<List<TelefoneEmpresa>?>(telefones, count, request.PageNumber, request.PageSize);
            }
            catch
            {
                return new PagedResponse<List<TelefoneEmpresa>?>(null, 500, "Não foi possível encontrar os telefones da empresa");
            }
        }

        public async Task<Response<EnderecoEmpresa?>> UpdateAsync(UpdateTelefoneEmpresaRequest request)
        {
            try
            {
                var enderecoEmpresa = await context.EnderecosEmpresa.FirstOrDefaultAsync(x => x.EmpresaId == request.EmpresaId);

                if (enderecoEmpresa == null)
                    return new Response<EnderecoEmpresa?>(null, 404, "Endereço não encontrado para atualizar");
                enderecoEmpresa.CEP = request.CEP;
                enderecoEmpresa.Estado = request.Estado;
                enderecoEmpresa.Cidade = request.Cidade;
                enderecoEmpresa.Bairro = request.Bairro;
                enderecoEmpresa.NomeRua = request.NomeRua;
                enderecoEmpresa.Numero = request.Numero;
                enderecoEmpresa.Complemento = request.Complemento;
                enderecoEmpresa.Status = request.Status;
                enderecoEmpresa.UsuarioId = request.UsuarioId;

                context.EnderecosEmpresa.Update(enderecoEmpresa);
                await context.SaveChangesAsync();

                return new Response<EnderecoEmpresa?>(enderecoEmpresa, message: "Endereço atualizado com sucesso!");
            }
            catch
            {
                return new Response<EnderecoEmpresa?>(null, 500, "Não foi possível atualizar o endereço.");
            }
        }
    }
}