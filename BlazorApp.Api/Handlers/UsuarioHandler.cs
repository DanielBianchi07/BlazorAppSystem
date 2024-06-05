using BlazorApp.Api.Data;
using BlazorApp.Shared.Handlers;
using BlazorApp.Shared.Models;
using BlazorApp.Shared.Requests.Usuarios;
using BlazorApp.Shared.Responses;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System;
using BlazorApp.Shared.Enums;


namespace BlazorApp.Api.Handlers
{
    public class UsuarioHandler(AppDbContext context) : IUsuarioHandler
    {
        public async Task<Response<Usuario?>> CreateAsync(CreateUsuarioRequest request)
        {
            var usuario = new Usuario
            {
                Nome = request.Nome,
                Senha = HashPassword(request.Senha),
                DataCriacao = request.DataCriacao,
                IsAdmin = EAtivoInativo.Inativo,
                Email = request.Email,
                Status = request.Status
            };

            try
            {
                await context.Usuarios.AddAsync(usuario);
                await context.SaveChangesAsync();

                return new Response<Usuario?>(usuario, 201, "Usuario cadastrado com sucesso!");
            }
            catch
            {
                return new Response<Usuario?>(null, 500, "Não foi possível cadastrar o usuario");
            }
        }

        public async Task<Response<Usuario?>> DeleteAsync(DeleteUsuarioRequest request)
        {
            try
            {
                var usuario = await context.Usuarios.FirstOrDefaultAsync(x => x.Id == request.Id && x.IsAdmin == EAtivoInativo.Inativo);

                if (usuario == null)
                    return new Response<Usuario?>(null, 404, "Usuario não encontrado para remoção");
                usuario.Status = EAtivoInativo.Inativo;
                context.Usuarios.Update(usuario);
                await context.SaveChangesAsync();

                return new Response<Usuario?>(usuario, message: "Usuario inativado com sucesso!");
            }
            catch
            {
                return new Response<Usuario?>(null, 500, "Não foi possível inativar o usuario");
            }
        }

        public async Task<PagedResponse<List<Usuario>?>> GetUsuarioAdminAsync(GetUsuarioAdminRequest request)
        {
            try
            {
                var query = context
                    .Usuarios
                    .AsNoTracking()
                    .Where(x => x.IsAdmin == EAtivoInativo.Ativo)
                    .OrderBy(x => x.Nome);

                var usuarios = await query
                    .Skip((request.PageNumber - 1) * request.PageSize)
                    .Take(request.PageSize)
                    .ToListAsync();

                var count = await query.CountAsync();
                return new PagedResponse<List<Usuario>?>(usuarios, count, request.PageNumber, request.PageSize);
            }
            catch
            {
                return new PagedResponse<List<Usuario>?>(null, 500, "Não foi possível encontrar os usuarios.");
            }
        }

        public async Task<Response<Usuario?>> GetByIdAsync(GetusuarioByIdRequest request)
        {
            try
            {
                var usuario = await context
                    .Usuarios
                    .AsNoTracking()
                    .FirstOrDefaultAsync(x => x.Id == request.Id);

                return usuario is null
                    ? new Response<Usuario?>(null, 404, "Usuario não encontrado pelo id.")
                    : new Response<Usuario?>(usuario);
            }
            catch
            {
                return new Response<Usuario?>(null, 500, "Não foi possível encontrar o usuario pelo id.");
            }
        }

        public async Task<Response<Usuario?>> GetByCredenciais(GetUsuarioBySenhaEmailRequest request)
        {
            try
            {
                var usuario = await context.Usuarios.FirstOrDefaultAsync(x => x.Email == request.Email);

                if (usuario != null)
                {
                    byte[] hashBytes = Convert.FromBase64String(usuario.Senha);

                    // Extrai o salt (primeiros 16 bytes)
                    byte[] salt = new byte[16];
                    Array.Copy(hashBytes, 0, salt, 0, 16);

                    // Gera o hash da senha fornecida usando o salt extraído
                    var pbkdf2 = new Rfc2898DeriveBytes(request.Senha, salt, 10000, HashAlgorithmName.SHA256);
                    byte[] hash = pbkdf2.GetBytes(32);

                    // Compara o hash gerado com o hash armazenado (os últimos 32 bytes)
                    for (int i = 0; i < 32; i++)
                    {
                        if (hashBytes[i + 16] != hash[i])
                        {
                            return new Response<Usuario?>(null, 404, "Usuario não encontrado, credenciais incorretas."); // Senha incorreta
                        }
                    }
                    return new Response<Usuario?>(usuario);
                }
                else
                {
                    return new Response<Usuario?>(null, 404, "Usuario não encontrado, credenciais incorretas."); // usuario não encontrado
                }
            }
            catch
            {
                return new Response<Usuario?>(null, 500, "Não foi possível encontrar o usuario pelas credenciais.");
            }
}

        public async Task<Response<Usuario?>> UpdateAsync(UpdateUsuarioRequest request)
        {
            try
            {
                var usuario = await context.Usuarios.FirstOrDefaultAsync(x => x.Id == request.Id);

                if (usuario == null)
                    return new Response<Usuario?>(null, 404, "Usuario não encontrado para atualizar.");
                usuario.Email = request.Email;
                usuario.Nome = request.Nome;
                usuario.Senha = HashPassword(request.Senha);
                usuario.Status = request.Status;
                usuario.DataAlteracao = request.DataAlteracao;

                context.Usuarios.Update(usuario);
                await context.SaveChangesAsync();

                return new Response<Usuario?>(usuario, message: "Usuario atualizado com sucesso!");
            }
            catch
            {
                return new Response<Usuario?>(null, 500, "Não foi possível atualizar o Usuario.");
            }
        }

        public async Task<PagedResponse<List<Usuario>?>> GetAllAsync(GetAllUsuarioRequest request)
        {
            try
            {
                var query = context
                    .Usuarios
                    .AsNoTracking()
                    .OrderBy(x => x.Nome);

                var usuarios = await query
                    .Skip((request.PageNumber - 1) * request.PageSize)
                    .Take(request.PageSize)
                    .ToListAsync();

                var count = await query.CountAsync();
                return new PagedResponse<List<Usuario>?>(usuarios, count, request.PageNumber, request.PageSize);
            }
            catch
            {
                return new PagedResponse<List<Usuario>?>(null, 500, "Não foi possível encontrar os usuarios.");
            }
        }

        private string HashPassword(string password)
        {
            byte[] salt = new byte[16];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            // Gera o hash da senha usando PBKDF2 com SHA256
            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 10000, HashAlgorithmName.SHA256);
            byte[] hash = pbkdf2.GetBytes(32);

            // Combina o salt e o hash em um único array para facilitar o armazenamento
            byte[] hashBytes = new byte[48];
            Array.Copy(salt, 0, hashBytes, 0, 16);
            Array.Copy(hash, 0, hashBytes, 16, 32);

            return Convert.ToBase64String(hashBytes);
        }
    }
}
