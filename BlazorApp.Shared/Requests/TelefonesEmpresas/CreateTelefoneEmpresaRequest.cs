using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        [Required(ErrorMessage = "Usuario Inválido")]
        public Guid UsuarioId { get; set; }
    }
}
