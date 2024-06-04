using BlazorApp.Shared.Enums;
using System.Text.Json.Serialization;

namespace BlazorApp.Shared.Models;

public class Alternativa
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Conteudo { get; set; } = string.Empty;
    public ERespostaAlternativa Resposta { get; set; } = ERespostaAlternativa.Errada;
    public EAtivoInativo Status { get; set; } = EAtivoInativo.Ativo;
    public Guid QuestaoId { get; set; }
    public Questao Questao { get; set; }

    public string UsuarioId { get; set; }
    [JsonIgnore]
    public ICollection<Usuario> Usuarios { get; set; }
}