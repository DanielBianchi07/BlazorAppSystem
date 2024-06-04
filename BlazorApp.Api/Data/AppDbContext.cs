using BlazorApp.Shared.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace BlazorApp.Api.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<Alternativa> Alternativas { get; set; } = null!;
        public DbSet<Aluno> Alunos { get; set; } = null!;
        public DbSet<Certificado> Certificados { get; set; } = null!;
        public DbSet<ConteudoProgramatico> ConteudosProgramatico { get; set; } = null!;
        public DbSet<Curso> Cursos { get; set; } = null!;
        public DbSet<Empresa> Empresas { get; set; } = null!;
        public DbSet<EnderecoEmpresa> EnderecosEmpresa { get; set; } = null!;
        public DbSet<Instrutor> Instrutores { get; set; } = null!;
        public DbSet<ListaPresenca> ListasPresenca { get; set; } = null!;
        public DbSet<Prova> Provas { get; set; } = null!;
        public DbSet<Questao> Questoes { get; set; } = null!;
        public DbSet<TelefoneEmpresa> TelefonesEmpresa { get; set; } = null!;
        public DbSet<Treinamento> Treinamentos { get; set; } = null!;

        public DbSet<Usuario> Usuarios { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            modelBuilder.Entity<Alternativa>().HasData(
                new Alternativa { Id = new Guid("8d7e2f3c0d294d6197f13453b6f7d631"), Conteudo = "alternativa A", QuestaoId = Guid.Parse("b5aefd227c2e42e593168f09d5f2c0f1"), Resposta = Shared.Enums.ERespostaAlternativa.Certa, Status = Shared.Enums.EAtivoInativo.Ativo, UsuarioId = "UsuarioTeste01@teste.com" }
                );

            modelBuilder.Entity<Aluno>().HasData(
                                new Aluno { Id = new Guid("1b5d254e45cb4c4f8fd7c1e2f5a15f2d"), Nome = "Aluno Teste 1", DataCriacao = DateTime.Now, Cpf = "000.111.00011", Assinatura = "Assin1", Status = Shared.Enums.EAtivoInativo.Ativo, Telefone = "", UsuarioId = "UsuarioTeste01@teste.com" }
                                );
            modelBuilder.Entity<Treinamento>().HasData(
                                new Treinamento { Id = new Guid("d4f354e86e644b2c91f599c5a6e5d7c1"), CursoId = Guid.Parse("9c6a17fd8d5a4f68a6d15e9f8a2f4c17"), Situacao = Shared.Enums.ESituacaoTreinamento.Andamento, Status = Shared.Enums.EAtivoInativo.Ativo, DataCriacao = DateTime.Now, Tipo = Shared.Enums.ETipoTreinamento.Inicial, UsuarioId = "UsuarioTeste01@teste.com" }
                                );
            modelBuilder.Entity<Curso>().HasData(
                                new Curso { Id = new Guid("9c6a17fd8d5a4f68a6d15e9f8a2f4c17"), Nome = "Curso Teste 01", CargaHorariaInicial = 4, CargaHorariaPeriodico = 8, DataCriacao = DateTime.Now, Status = Shared.Enums.EAtivoInativo.Ativo, Logo = "", Validade = 2, UsuarioId = "UsuarioTeste01@teste.com" }
                                );
            modelBuilder.Entity<Prova>().HasData(
                                new Prova { CursoId = Guid.Parse("9c6a17fd8d5a4f68a6d15e9f8a2f4c17"), DataCriacao = DateTime.Now, Id = new Guid("3e6d2f3a5f574c9785c18f5d1b6c4d71"), Status = Shared.Enums.EAtivoInativo.Ativo, UsuarioId = "UsuarioTeste01@teste.com" }
                                );
            modelBuilder.Entity<Empresa>().HasData(
                new Empresa { Id = new Guid("7a9e5f7d2c6e4a1bbc3f4d5a1e2f5b6c"), CNPJ = "11.000.111/0001-10", RazaoSocial = "Empresa Teste 01", Status = Shared.Enums.EAtivoInativo.Ativo, UsuarioId = "UsuarioTeste01@teste.com", Alunos = new List<Aluno>(), DataCriacao = DateTime.Now, TelefoneEmpresa = new List<TelefoneEmpresa>(), Treinamentos = new List<Treinamento>(), Usuarios = new List<Usuario>() }
            );
            modelBuilder.Entity<Instrutor>().HasData(
                                new Instrutor { Id = new Guid("2f1b6d4e8e7f4a5d9f1c7c3e5d6b8f1a"), Cpf = "222.000.22202", DataCriacao = DateTime.Now, Assinatura = "", Especializacao = "Técnico de Segurança", Nome = "Instrutor Teste 01", Registro = "CAEPF01/542", Status = Shared.Enums.EAtivoInativo.Ativo, Telefone = "(11) 991276269", UsuarioId = "UsuarioTeste01@teste.com" }
                                );
            modelBuilder.Entity<Usuario>().HasData(
                                new Usuario { UsuarioId = "UsuarioTeste01@teste.com", IsAdmin = 1, Nome = "Usuario 01", DataCriacao = DateTime.Now, Senha = "aqgbpo22" },
                                new Usuario { UsuarioId = "TesteUsuario02@teste.com", IsAdmin = 1, Nome = "Usuario 02", DataCriacao = DateTime.Now, Senha = "aqgbpo23" }
                                );
            modelBuilder.Entity<Questao>().HasData(
                                new Questao { Id = new Guid("b5aefd227c2e42e593168f09d5f2c0f1"), Conteudo = "Questao 01", ProvaId = Guid.Parse("3e6d2f3a5f574c9785c18f5d1b6c4d71"), Status = Shared.Enums.EAtivoInativo.Ativo, UsuarioId = "UsuarioTeste01@teste.com" }
                                );
        }
    }
}
