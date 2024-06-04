using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp.Shared.Requests.Cursos
{
    public class DeleteCursoRequest : Request
    {
        [Required(ErrorMessage = "Curso Inválido")]
        public Guid Id {get; set;}
    }
}
