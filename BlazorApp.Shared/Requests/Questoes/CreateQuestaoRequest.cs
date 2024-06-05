using BlazorApp.Shared.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp.Shared.Requests.Questoes
{
    public class CreateQuestaoRequest : Request
    {
        [Required(ErrorMessage = "Prova Inválida")]
        public Guid ProvaId { get; set; }
        [Required(ErrorMessage = "Conteúdo Inválido")]
        public string Conteudo { get; set; } = string.Empty;
        [Required(ErrorMessage = "Status Inválido")]
        public EAtivoInativo Status { get; set; }
    }
}
