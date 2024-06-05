using BlazorApp.Shared.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp.Shared.Requests.Alternativas
{
    public class UpdateAlternativaRequest : Request
    {
        [Required(ErrorMessage = "Alternativa Inválida")]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Questão Inválida")]
        public Guid QuestaoId { get; set; }
        [Required(ErrorMessage = "Conteúdo Inválido")]
        public string Conteudo { get; set; } = string.Empty;
        [Required(ErrorMessage = "Resposta Inválida")]
        public ERespostaAlternativa Resposta { get; set; } = ERespostaAlternativa.Errada;
        [Required(ErrorMessage = "Status Inválido")]
        public EAtivoInativo Status { get; set; } = EAtivoInativo.Ativo;
    }
}
