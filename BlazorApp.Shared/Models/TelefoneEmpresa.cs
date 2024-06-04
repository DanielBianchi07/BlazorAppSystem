using BlazorApp.Shared.Enums;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
namespace BlazorApp.Shared.Models;

public class TelefoneEmpresa
{
    public Guid EmpresaId { get; set; }
    public string NroTelefone { get; set; } = string.Empty;
    public EAtivoInativo Status { get; set; } = EAtivoInativo.Ativo;
    [JsonIgnore]
    public Empresa Empresa { get; set; }

    public Guid UsuarioId { get; set; }
    [JsonIgnore]
    public ICollection<Usuario> Usuarios { get; set; }
}