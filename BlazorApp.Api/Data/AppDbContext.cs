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
        }
    }
}
