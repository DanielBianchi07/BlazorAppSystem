using BlazorApp.Shared.Enums;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
namespace BlazorApp.Shared.Models;

public class Prova
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public EAtivoInativo Status { get; set; } = EAtivoInativo.Ativo;
    public DateTime? DataCriacao { get; set; } = null;
    public DateTime? DataAlteracao { get; set; } = null;

    public Guid CursoId { get; set; }
    public Curso Curso { get; set; }
    [JsonIgnore]
    public ICollection<Questao> Questoes { get; set; }

    public Guid CreatedBy { get; set; }
    public Guid? UpdatedBy { get; set; }
}