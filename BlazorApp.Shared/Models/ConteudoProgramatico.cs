using BlazorApp.Shared.Enums;
using System.Text.Json.Serialization;

namespace BlazorApp.Shared.Models;

public class ConteudoProgramatico
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Assunto { get; set; } = string.Empty;
    public int CargaHoraria { get; set; }
    public EAtivoInativo Status { get; set; } = EAtivoInativo.Ativo;
    public DateTime? DataCriacao { get; set; } = null;
    public DateTime? DataAlteracao { get; set; } = null;

    public Guid CursoId { get; set; }
    public Curso Curso { get; set; }

    public Guid CreatedBy { get; set; }
    public Guid? UpdatedBy { get; set; }
}