using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp.Shared.Requests.Treinamentos
{
    public class GetTreinamentoByCursoRequest : PagedRequest
    {
        [Required(ErrorMessage = "Curso Inválido")]
        public Guid CursoId { get; set; }
    }
}
