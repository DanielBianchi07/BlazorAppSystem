using BlazorApp.Shared.Enums;
using System.Text.Json.Serialization;

namespace BlazorApp.Shared.Models;

public class Treinamento
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public DateTime? DataCriacao { get; set; } = null;
    public DateTime? DataAlteracao { get; set; } = null;
    public ETipoTreinamento Tipo { get; set; } = ETipoTreinamento.Inicial;
    public ESituacaoTreinamento Situacao { get; set; } = ESituacaoTreinamento.Andamento;
    public EAtivoInativo Status { get; set; } = EAtivoInativo.Ativo;
    [JsonIgnore]
    public ListaPresenca ListaPresenca { get; set; }

    public Guid CursoId { get; set; }
    [JsonIgnore]
    public Curso Curso { get; set; }
    [JsonIgnore]
    public ICollection<Certificado> Certificados { get; set; }
    [JsonIgnore]
    public ICollection<Empresa> Empresas { get; set; }
    [JsonIgnore]
    public ICollection<Aluno> Alunos { get; set; }
    [JsonIgnore]
    public ICollection<Instrutor> Instrutores { get; set; }

    public Guid CreatedBy { get; set; }
    public Guid? UpdatedBy { get; set; }
}