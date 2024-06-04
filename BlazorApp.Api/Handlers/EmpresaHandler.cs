﻿using BlazorApp.Api.Data;
using BlazorApp.Shared.Handlers;
using BlazorApp.Shared.Models;
using BlazorApp.Shared.Requests.Empresas;
using BlazorApp.Shared.Responses;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp.Api.Handlers
{
    public class EmpresaHandler(AppDbContext context) : IEmpresaHandler
    {
        public async Task<Response<Empresa?>> CreateAsync(CreateEmpresaRequest request)
        {
            var empresa = new Empresa
            {
                UsuarioId = request.UsuarioId,
                CNPJ = request.CNPJ,
                RazaoSocial = request.RazaoSocial,
                Email = request.Email,
                EnderecoEmpresa = request.Endereco,
                Status = request.Status,

                DataCriacao = request.DataCriacao,
            };

            try
            {
                await context.Empresas.AddAsync(empresa);
                await context.SaveChangesAsync();

                return new Response<Empresa?>(empresa, 201, "Empresa cadastrado com sucesso!");
            }
            catch
            {
                return new Response<Empresa?>(null, 500, "Não foi possível cadastrar o empresa");
            }
        }

        public async Task<Response<Empresa?>> DeleteAsync(DeleteEmpresaRequest request)
        {
            try
            {
                var empresa = await context.Empresas.FirstOrDefaultAsync(x => x.Id == request.Id);

                if (empresa == null)
                    return new Response<Empresa?>(null, 404, "Empresa não encontrado");
                empresa.Status = Shared.Enums.EAtivoInativo.Inativo;
                context.Empresas.Update(empresa);
                await context.SaveChangesAsync();

                return new Response<Empresa?>(empresa, message: "Empresa inativado com sucesso!");
            }
            catch
            {
                return new Response<Empresa?>(null, 500, "Não foi possível inativar o empresa");
            }
        }

        public async Task<PagedResponse<List<Empresa>?>> GetAllAsync(GetAllEmpresasRequest request)
        {
            try
            {
                var query = context
                    .Empresas
                    .AsNoTracking()
                    .OrderBy(x => x.RazaoSocial);

                var empresas = await query
                    .Skip((request.PageNumber - 1) * request.PageSize)
                    .Take(request.PageSize)
                    .ToListAsync();

                var count = await query.CountAsync();
                return new PagedResponse<List<Empresa>?>(empresas, count, request.PageNumber, request.PageSize);
            }
            catch
            {
                return new PagedResponse<List<Empresa>?>(null, 500, "Não foi possível encontrar o empresa");
            }
        }

        public async Task<Response<Empresa?>> GetByIdAsync(GetEmpresaByIdRequest request)
        {
            try
            {
                var empresa = await context
                    .Empresas
                    .AsNoTracking()
                    .FirstOrDefaultAsync(x => x.Id == request.Id);

                return empresa is null
                    ? new Response<Empresa?>(null, 404, "Empresa não encontrado")
                    : new Response<Empresa?>(empresa);
            }
            catch
            {
                return new Response<Empresa?>(null, 500, "Não foi possível encontrar o empresa");
            }
        }

        public async Task<Response<Empresa?>> UpdateAsync(UpdateEmpresaRequest request)
        {
            try
            {
                var empresa = await context.Empresas.FirstOrDefaultAsync(x => x.Id == request.Id);

                if (empresa == null)
                    return new Response<Empresa?>(null, 404, "Empresa não encontrado para atualizar");
                empresa.CNPJ = request.CNPJ;
                empresa.RazaoSocial = request.RazaoSocial;
                empresa.Email = request.Email;
                empresa.Status = request.Status;
                empresa.DataAlteracao = request.DataAlteracao;
                empresa.UsuarioId = request.UsuarioId;

                context.Empresas.Update(empresa);
                await context.SaveChangesAsync();

                return new Response<Empresa?>(empresa, message: "Empresa atualizado com sucesso!");
            }
            catch
            {
                return new Response<Empresa?>(null, 500, "Não foi possível atualizar a empresa.");
            }
        }
    }
}
