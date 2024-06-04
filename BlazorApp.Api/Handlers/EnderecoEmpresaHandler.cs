using BlazorApp.Api.Data;
using BlazorApp.Shared.Handlers;
using BlazorApp.Shared.Models;
using BlazorApp.Shared.Requests.EnderecosEmpresas;
using BlazorApp.Shared.Responses;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp.Api.Handlers
{
    public class EnderecoEmpresaHandler(AppDbContext context) : IEnderecoEmpresaHandler
    {
        public async Task<Response<EnderecoEmpresa?>> CreateAsync(CreateEnderecoEmpresaRequest request)
        {
            var empresa = new EnderecoEmpresa
            {
                EmpresaId = request.EmpresaId,
                CEP = request.CEP,
                Estado = request.Estado,
                Cidade = request.Cidade,
                Bairro = request.Bairro,
                NomeRua = request.NomeRua,
                Numero = request.Numero,
                Complemento = request.Complemento,
                Status = request.Status,
                UsuarioId = request.UsuarioId,
            };

            try
            {
                await context.EnderecosEmpresa.AddAsync(empresa);
                await context.SaveChangesAsync();

                return new Response<EnderecoEmpresa?>(empresa, 201, "Endereço cadastrado com sucesso!");
            }
            catch
            {
                return new Response<EnderecoEmpresa?>(null, 500, "Não foi possível cadastrar o endereço");
            }
        }

        public async Task<Response<EnderecoEmpresa?>> DeleteAsync(DeleteEnderecoEmpresaRequest request)
        {
            try
            {
                var enderecoEmpresa = await context.EnderecosEmpresa.FirstOrDefaultAsync(x => x.EmpresaId == request.EmpresaId);

                if (enderecoEmpresa == null)
                    return new Response<EnderecoEmpresa?>(null, 404, "Endereço não encontrado para remoção");
                enderecoEmpresa.Status = Shared.Enums.EAtivoInativo.Inativo;
                await context.SaveChangesAsync();

                return new Response<EnderecoEmpresa?>(enderecoEmpresa, message: "Endereço removido com sucesso!");
            }
            catch
            {
                return new Response<EnderecoEmpresa?>(null, 500, "Não foi possível remover o endereço.");
            }
        }

        public async Task<Response<EnderecoEmpresa?>> GetByIdAsync(GetEnderecoEmpresaByIdRequest request)
        {
            try
            {
                var enderecoEmpresa = await context
                    .EnderecosEmpresa
                    .AsNoTracking()
                    .FirstOrDefaultAsync(x => x.EmpresaId == request.EmpresaId);

                return enderecoEmpresa is null
                    ? new Response<EnderecoEmpresa?>(null, 404, "Endereço não encontrado pelo id.")
                    : new Response<EnderecoEmpresa?>(enderecoEmpresa);
            }
            catch
            {
                return new Response<EnderecoEmpresa?>(null, 500, "Não foi possível encontrar o endereço pelo id.");
            }
        }

        public async Task<Response<EnderecoEmpresa?>> UpdateAsync(UpdateEnderecoEmpresaRequest request)
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