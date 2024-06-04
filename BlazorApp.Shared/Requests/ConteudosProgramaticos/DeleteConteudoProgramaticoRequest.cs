using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp.Shared.Requests.ConteudosProgramaticos
{
    public class DeleteConteudoProgramaticoRequest : Request
    {
        [Required(ErrorMessage = "Conteudo Programático Inválido")]
        public Guid Id { get; set; }
    }
}
