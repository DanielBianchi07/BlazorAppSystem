using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp.Shared.Requests.Instrutores
{
    public class GetInstrutorByEspecializacaoRequest : PagedRequest
    {
        [Required(ErrorMessage = "Especialização Inválida")]
        public string Especializacao { get; set; } = string.Empty;
    }
}