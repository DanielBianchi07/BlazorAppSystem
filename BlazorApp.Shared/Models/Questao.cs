using BlazorApp.Shared.Enums;
using System.Text.Json.Serialization;

namespace BlazorApp.Shared.Models;

public class Questao
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Conteudo { get; set; } = string.Empty;
    public EAtivoInativo Status { get; set; } = EAtivoInativo.Ativo;

    public Guid ProvaId { get; set; }
    public Prova Prova { get; set; }
    [JsonIgnore]
    public ICollection<Alternativa> Alternativas { get; set; }

    public string UsuarioId { get; set; }
    [JsonIgnore]
    public ICollection<Usuario> Usuarios { get; set; }
}