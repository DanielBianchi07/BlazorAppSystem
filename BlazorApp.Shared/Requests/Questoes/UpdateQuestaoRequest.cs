using BlazorApp.Shared.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp.Shared.Requests.Questoes
{
    public class UpdateQuestaoRequest : Request
    {
        [Required(ErrorMessage = "Questão Inválida")]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Conteúdo Inválido")]
        public string Conteudo { get; set; } = string.Empty;
        [Required(ErrorMessage = "Status Inválido")]
        public EAtivoInativo Status { get; set; }
        [Required(ErrorMessage = "Prova Inválida")]
        public Guid ProvaId { get; set; }

        [Required(ErrorMessage = "Usuario Inválido")]
        public string UsuarioId { get; set; }
    }
}
