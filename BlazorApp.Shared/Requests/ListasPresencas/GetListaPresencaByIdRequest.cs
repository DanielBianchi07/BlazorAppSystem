using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp.Shared.Requests.ListasPresencas
{
    public class GetListaPresencaByIdRequest : Request
    {
        [Required(ErrorMessage = "Treinamento Inválido")]
        public Guid TreinamentoId { get; set; }
        [Required(ErrorMessage = "Código Inválido")]
        public string Codigo { get; set; } = string.Empty;
    }
}
