using BlazorApp.Shared.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp.Shared.Requests.Treinamentos
{
    public class GetTreinamentoBySituacaoRequest : PagedRequest
    {
        [Required(ErrorMessage = "Situação Inválido")]
        public ESituacaoTreinamento Situacao { get; set; }
    }
}
