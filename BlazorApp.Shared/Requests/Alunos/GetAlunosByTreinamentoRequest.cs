using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp.Shared.Requests.Alunos
{
    public class GetAlunoByTreinamentoRequest : PagedRequest
    {
        [Required(ErrorMessage = "Treinamento Inválido")]
        public Guid TreinamentoId { get; set; }
    }
}