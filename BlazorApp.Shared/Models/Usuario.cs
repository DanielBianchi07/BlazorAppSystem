using BlazorApp.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BlazorApp.Shared.Models
{
    public class Usuario
    {
        public string UsuarioId { get; set; } = string.Empty;
        public string Nome { get; set; } = string.Empty;
        public string Senha {  get; set; } = string.Empty;
        public int IsAdmin { get; set; }
        public DateTime? DataCriacao { get; set; } = null;
        public DateTime? DataAlteracao { get; set; } = null;
        public EAtivoInativo Status { get; set; } = EAtivoInativo.Ativo;

        [JsonIgnore]
        public ICollection<Alternativa> Alternativas { get; set; }
        [JsonIgnore]
        public ICollection<Aluno> Alunos { get; set; }
        [JsonIgnore]
        public ICollection<Certificado> Certificados { get; set; }
        [JsonIgnore]
        public ICollection<ConteudoProgramatico> ConteudosProgramaticos { get; set; }
        [JsonIgnore]
        public ICollection<Curso> Cursos { get; set; }
        [JsonIgnore]
        public ICollection<Empresa> Empresas { get; set; }
        [JsonIgnore]
        public ICollection<EnderecoEmpresa> EnderecosEmpresas { get; set; }
        [JsonIgnore]
        public ICollection<Instrutor> Instrutores { get; set; }
        [JsonIgnore]
        public ICollection<ListaPresenca> ListasPresescas { get; set; }
        [JsonIgnore]
        public ICollection<Prova> Provas { get; set; }
        [JsonIgnore]
        public ICollection<Questao> Questoes { get; set; }
        [JsonIgnore]
        public ICollection<TelefoneEmpresa> TelefonesEmpresas { get; set; }
        [JsonIgnore]
        public ICollection<Treinamento> Treinamentos { get; set; }
    }
}
