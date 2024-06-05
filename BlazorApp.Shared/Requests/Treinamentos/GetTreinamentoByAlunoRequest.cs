using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp.Shared.Requests.Treinamentos
{
    public class GetTreinamentoByAlunoRequest : PagedRequest
    {
        [Required(ErrorMessage = "Aluno Inválido")]
        public Guid AlunoId { get; set; }
    }
}
