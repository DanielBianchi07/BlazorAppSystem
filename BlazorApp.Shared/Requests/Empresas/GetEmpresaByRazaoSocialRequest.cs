using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp.Shared.Requests.Empresas
{
    public class GetEmpresaByRazaoSocialRequest : PagedRequest
    {
        [Required(ErrorMessage = "Empresa Inválida")]
        public string RazaoSocial { get; set; }
    }
}