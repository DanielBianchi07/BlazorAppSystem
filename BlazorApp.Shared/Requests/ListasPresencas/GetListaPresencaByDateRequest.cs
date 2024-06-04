using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp.Shared.Requests.ListasPresencas
{
    public class GetListaPresencaByDateRequest : PagedRequest
    {
        [Required(ErrorMessage = "Data Inválida")]
        public DateTime? StartDate { get; set; }
        [Required(ErrorMessage = "Data Inválida")]
        public DateTime? EndDate { get; set; }
    }
}
