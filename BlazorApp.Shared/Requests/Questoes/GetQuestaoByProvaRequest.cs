using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp.Shared.Requests.Questoes
{
    public class GetQuestaoByProvaRequest : PagedRequest
    {
        [Required(ErrorMessage = "Prova Inválida")]
        public Guid ProvaId { get; set; }
    }
}
