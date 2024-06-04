using BlazorApp.Shared.Enums;
using System.Text.Json.Serialization;

namespace BlazorApp.Shared.Models;

public class EnderecoEmpresa
{
    // public Guid Id { get; set; } = Guid.NewGuid();
    public Guid EmpresaId { get; set; }
    public string CEP { get; set; } = string.Empty;
    public string Estado { get; set; } = string.Empty;
    public string Cidade { get; set; } = string.Empty;
    public string Bairro { get; set; } = string.Empty;
    public string NomeRua { get; set; } = string.Empty;
    public string Numero { get; set; } = string.Empty;
    public string? Complemento { get; set; } = string.Empty;
    public EAtivoInativo Status { get; set; } = EAtivoInativo.Ativo;

    [JsonIgnore]
    public Empresa Empresa { get; set; } = null;

    public string UsuarioId { get; set; }
    [JsonIgnore]
    public ICollection<Usuario> Usuarios { get; set; }
}