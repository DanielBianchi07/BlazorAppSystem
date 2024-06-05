using BlazorApp.Api.Data;
using BlazorApp.Shared.Handlers;
using BlazorApp.Shared.Models;
using BlazorApp.Shared.Requests.Certificados;
using BlazorApp.Shared.Responses;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;

namespace BlazorApp.Api.Handlers
{
    public class CertificadoHandler(AppDbContext context) : ICertificadoHandler
    {
        public async Task<Response<Certificado?>> CreateAsync(CreateCertificadoRequest request)
        {
            var certificado = new Certificado()
            {
                TreinamentoId = request.TreinamentoId,
                Codigo = request.Codigo,
                DataInicioCertificado = request.DataInicioCertificado,
                DataCriacao = request.DataCriacao,
                Situacao = request.Situacao,
                CreatedBy = request.UsuarioId,
            };

            try
            {
                await context.Certificados.AddAsync(certificado);
                await context.SaveChangesAsync();

                return new Response<Certificado?>(certificado, 201, "Certificado cadastrado com sucesso!");
            }
            catch
            {
                return new Response<Certificado?>(null, 500, "Não foi possível cadastrar o certificado.");
            }
        }

        public async Task<Response<Certificado?>> DeleteAsync(DeleteCertificadoRequest request)
        {
            try
            {
                var certificado = await context.Certificados.FirstOrDefaultAsync(x => x.TreinamentoId == request.TreinamentoId && x.Codigo == request.Codigo);

                if (certificado== null)
                    return new Response<Certificado?>(null, 404, "Certificado não encontrado para remoção");
                certificado.Situacao = Shared.Enums.ESituacaoCertificado.Cancelado;
                context.Certificados.Update(certificado);
                await context.SaveChangesAsync();

                return new Response<Certificado?>(certificado, message: "Certificado removido com sucesso!");
            }
            catch
            {
                return new Response<Certificado?>(null, 500, "Não foi possível remover o certificado.");
            }
        }

        public async Task<PagedResponse<List<Certificado>?>> GetAllAsync(GetAllCertificadosRequest request)
        {
            try
            {
                var query = context
                    .Certificados
                    .AsNoTracking()
                    .OrderBy(x => x.DataCriacao);

                var certificados = await query
                    .Skip((request.PageNumber - 1) * request.PageSize)
                    .Take(request.PageSize)
                    .ToListAsync();

                var count = await query.CountAsync();
                return new PagedResponse<List<Certificado>?>(certificados, count, request.PageNumber, request.PageSize);
            }
            catch
            {
                return new PagedResponse<List<Certificado>?>(null, 500, "Não foi possível encontrar os certificados.");
            }
        }

        public async Task<Response<Certificado?>> GetByIdAsync(GetCertificadoByIdRequest request)
        {
            try
            {
                var certificado = await context
                    .Certificados
                    .AsNoTracking()
                    .FirstOrDefaultAsync(x => x.TreinamentoId == request.TreinamentoId && x.Codigo == request.Codigo);

                return certificado is null
                    ? new Response<Certificado?>(null, 404, "Certificado não encontrado pelo id.")
                    : new Response<Certificado?>(certificado);
            }
            catch
            {
                return new Response<Certificado?>(null, 500, "Não foi possível encontrar o certificado pelo id.");
            }
        }

        public async Task<PagedResponse<List<Certificado>?>> GetByDateAsync(GetCertificadosByDateRequest request)
        {
            try
            {
                var query = context.Certificados.AsNoTracking().Where(x => x.DataCriacao <= request.EndDate && x.DataCriacao >= request.StartDate).OrderBy(x => x.DataCriacao);

                var certificados = await query
                    .Skip((request.PageNumber - 1) * request.PageSize)
                    .Take(request.PageSize)
                    .ToListAsync();

                var count = await query.CountAsync();

                return new PagedResponse<List<Certificado>?>(certificados, count, request.PageNumber, request.PageSize);
            }
            catch
            {
                return new PagedResponse<List<Certificado>?>(null, 500, "Não foi possível encontrar certificados pela data requerida.");
            }
        }

        public async Task<Response<Certificado?>> UpdateAsync(UpdateCertificadoRequest request)
        {
            try
            {
                var certificado = await context.Certificados.FirstOrDefaultAsync(x => x.TreinamentoId == request.TreinamentoId && x.Codigo == request.Codigo);

                if (certificado == null)
                    return new Response<Certificado?>(null, 404, "Certificado não encontrado para atualizar");
                certificado.DataInicioCertificado = request.DataInicioCertificado;
                certificado.Situacao = request.Situacao;
                certificado.DataAlteracao = request.DataAlteracao;
                certificado.UpdatedBy = request.UsuarioId;

                context.Certificados.Update(certificado);
                await context.SaveChangesAsync();

                return new Response<Certificado?>(certificado, message: "Certificado atualizado com sucesso!");
            }
            catch
            {
                return new Response<Certificado?>(null, 500, "Não foi possível atualizar o certificdo.");
            }
        }
    }
}