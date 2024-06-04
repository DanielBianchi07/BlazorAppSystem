using BlazorApp.Shared.Enums;
using System.Text.Json.Serialization;

namespace BlazorApp.Shared.Models;

public class Empresa
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string CNPJ { get; set; } = string.Empty;
    public string RazaoSocial { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public EAtivoInativo Status { get; set; } = EAtivoInativo.Ativo;
    public DateTime? DataCriacao { get; set; } = null;
    public DateTime? DataAlteracao { get; set; } = null;

    public EnderecoEmpresa EnderecoEmpresa { get; set; } = null;
    [JsonIgnore]
    public ICollection<TelefoneEmpresa> TelefoneEmpresa { get; set; }
    [JsonIgnore]
    public ICollection<Treinamento> Treinamentos { get; set; }
    [JsonIgnore]
    public ICollection<Aluno> Alunos { get; set; }

    public string UsuarioId { get; set; }
    [JsonIgnore]
    public ICollection<Usuario> Usuarios { get; set; }
}