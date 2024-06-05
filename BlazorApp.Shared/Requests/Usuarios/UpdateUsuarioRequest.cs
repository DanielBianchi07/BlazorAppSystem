using BlazorApp.Shared.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp.Shared.Requests.Usuarios
{
    public class UpdateUsuarioRequest : Request
    {
        [Required(ErrorMessage = "Usuário Inválido")]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Email Inválido")]
        public string Email { get; set; } = string.Empty;
        [Required(ErrorMessage = "Nome Inválido")]
        public string Nome { get; set; } = string.Empty;

        [Required(ErrorMessage = "Senha Inválida")]
        public string Senha { get; set; } = string.Empty;
        [Required(ErrorMessage = "Status inválido")]
        public EAtivoInativo Status { get; set; }

        public DateTime? DataAlteracao { get; set; } = DateTime.Now;

    }
}