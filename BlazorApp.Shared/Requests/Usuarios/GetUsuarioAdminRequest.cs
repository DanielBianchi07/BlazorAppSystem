using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp.Shared.Requests.Usuarios
{
    public class GetUsuarioAdminRequest : PagedRequest
    {
        [Required(ErrorMessage = "Definição de Admin Inválida")]
        public int IsAdmin { get; set; }
    }
}