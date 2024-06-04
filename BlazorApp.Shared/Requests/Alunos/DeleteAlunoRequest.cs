using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp.Shared.Requests.Alunos
{
    public class DeleteAlunoRequest : Request
    {
        [Required(ErrorMessage = "Aluno Inválido")]
        public Guid Id { get; set; }
    }
}
