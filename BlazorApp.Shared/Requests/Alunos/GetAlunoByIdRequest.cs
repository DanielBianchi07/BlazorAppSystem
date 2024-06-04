using BlazorApp.Shared.Models;
using BlazorApp.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BlazorApp.Shared.Requests.Alunos
{
    public class GetAlunoByIdRequest : Request
    {
        [Required(ErrorMessage = "Aluno Inválido")]
        public Guid Id { get; set; }
    }
}
