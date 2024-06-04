using BlazorApp.Shared.Enums;
using System.Text.Json.Serialization;

namespace BlazorApp.Shared.Models;

public class Curso
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Nome { get; set; } = string.Empty;
    public string Logo { get; set; } = string.Empty;
    public int CargaHorariaInicial { get; set; }
    public int CargaHorariaPeriodico { get; set; }
    public int Validade { get; set; }
    public EAtivoInativo Status { get; set; } = EAtivoInativo.Ativo;
    public DateTime? DataCriacao { get; set; } = null;
    public DateTime? DataAlteracao { get; set; } = null;

    [JsonIgnore]
    public ICollection<Treinamento> Treinamentos { get; set; }
    [JsonIgnore]
    public ICollection<ConteudoProgramatico> ConteudosProgramaticos { get; set; }
    [JsonIgnore]
    public ICollection<Prova> Provas { get; set; }

    public string UsuarioId { get; set; }
    [JsonIgnore]
    public ICollection<Usuario> Usuarios { get; set; }
}