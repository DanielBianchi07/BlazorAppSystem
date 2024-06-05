using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp.Shared.Requests.TelefonesEmpresas
{
    public class GetTelefoneEmpresaByIdRequest : Request
    {
        [Required(ErrorMessage = "Telefone Inválido")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Empresa Inválida")]
        public Guid EmpresaId { get; set; }
    }
}
