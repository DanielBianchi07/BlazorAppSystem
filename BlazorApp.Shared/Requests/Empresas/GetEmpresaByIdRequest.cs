using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp.Shared.Requests.Empresas
{
    public class GetEmpresaByIdRequest : Request
    {
        [Required(ErrorMessage = "Empresa Inválida")]
        public Guid Id { get; set; }
    }
}
