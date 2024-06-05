using BlazorApp.Shared.Enums;
using System.ComponentModel.DataAnnotations;

namespace BlazorApp.Shared.Requests.TelefonesEmpresas
{
    public class CreateTelefoneEmpresaRequest : Request
    {
        [Required(ErrorMessage = "Empresa Inválida")]
        public Guid EmpresaId { get; set; }

        [Required(ErrorMessage = "Número de Telefone Inválido")]
        public string NroTelefone { get; set; } = string.Empty;

        [Required(ErrorMessage = "Status Inválido")]
        public EAtivoInativo Status { get; set; }
    }
}
