using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp.Shared.Requests.TelefonesEmpresas
{
    public class GetTelefonesByEmpresasRequest : PagedRequest
    {
        [Required(ErrorMessage = "Empresa Inválida")]
        public Guid EmpresaId { get; set; }
    }
}
