using BlazorApp.Shared.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp.Shared.Requests.Usuarios
{
    public class CreateUsuarioRequest
    {
        [Required(ErrorMessage = "Email Inválido")]
        public string Email { get; set; } = string.Empty;
        [Required(ErrorMessage = "Nome Inválido")]
        public string Nome { get; set; } = string.Empty;

        [Required(ErrorMessage = "Senha Inválida")]
        public string Senha { get; set; } = string.Empty;
        public EAtivoInativo Status { get; set; } = EAtivoInativo.Ativo;
        public DateTime? DataCriacao { get; set; } = DateTime.Now;

    }
}