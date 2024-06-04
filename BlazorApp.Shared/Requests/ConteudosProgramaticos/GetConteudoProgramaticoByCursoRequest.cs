using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp.Shared.Requests.ConteudosProgramaticos
{
    public class GetConteudoProgramaticoByCursoRequest : PagedRequest
    {
        [Required(ErrorMessage = "Curso Inválido")]
        public Guid CursoId { get; set; }
    }
}
