using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp.Shared.Requests
{
    public abstract class Request
    {
        [Required(ErrorMessage = "Usuario Inválido")]
        public Guid UsuarioId { get; set; }
    }
}
