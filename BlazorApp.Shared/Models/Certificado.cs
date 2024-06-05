using BlazorApp.Shared.Enums;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
namespace BlazorApp.Shared.Models;

public class Certificado
{
    public Guid TreinamentoId { get; set; }
    public string Codigo { get; set; } = string.Empty;
    public DateTime? DataInicioCertificado { get; set; } = null;
    public DateTime? DataCriacao { get; set; } = null;
    public DateTime? DataAlteracao { get; set; } = null;
    public ESituacaoCertificado Situacao { get; set; } = ESituacaoCertificado.Processando;

    public Treinamento Treinamento { get; set; } = null;

    public Guid CreatedBy { get; set; }
    public Guid? UpdatedBy { get; set; }
}