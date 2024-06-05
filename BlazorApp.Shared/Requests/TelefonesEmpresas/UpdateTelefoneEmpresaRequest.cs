using BlazorApp.Shared.Enums;
using System.ComponentModel.DataAnnotations;

namespace BlazorApp.Shared.Requests.TelefonesEmpresas
{
    public class UpdateTelefoneEmpresaRequest : Request
    {
        [Required(ErrorMessage = "Telefone Inválido")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Número de Telefone Inválido")]
        public string NroTelefone { get; set; } = string.Empty;

        [Required(ErrorMessage = "Status Inválido")]
        public EAtivoInativo Status { get; set; }
    }
}
