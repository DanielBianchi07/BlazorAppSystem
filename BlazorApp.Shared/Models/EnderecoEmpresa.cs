using BlazorApp.Shared.Enums;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BlazorApp.Shared.Models;

public class EnderecoEmpresa
{
    // public Guid Id { get; set; } = Guid.NewGuid();
    public Guid? EmpresaId { get; set; }
    [Required(ErrorMessage = "CEP Inválido")]
    public string CEP { get; set; } = string.Empty;
    [Required(ErrorMessage = "Estado Inválido")]
    public string Estado { get; set; } = string.Empty;
    [Required(ErrorMessage = "Cidade Inválida")]
    public string Cidade { get; set; } = string.Empty;
    [Required(ErrorMessage = "Bairro Inválido")]
    public string Bairro { get; set; } = string.Empty;
    [Required(ErrorMessage = "Nome da Rua Inválido")]
    public string NomeRua { get; set; } = string.Empty;
    [Required(ErrorMessage = "Número Inválido")]
    public string Numero { get; set; } = string.Empty;
    public string? Complemento { get; set; } = string.Empty;
    public EAtivoInativo Status { get; set; } = EAtivoInativo.Ativo;

    [JsonIgnore]
    public Empresa Empresa { get; set; } = null;

    public Guid CreatedBy { get; set; }
    public Guid? UpdatedBy { get; set; }
}