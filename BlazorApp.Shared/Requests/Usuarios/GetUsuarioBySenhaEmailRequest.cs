using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp.Shared.Requests.Usuarios
{
    public class GetUsuarioBySenhaEmailRequest : Request
    {
        [Required(ErrorMessage = "Email Inválido")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Senha Obrigatória")]
        public string Senha { get; set; }
    }
}
