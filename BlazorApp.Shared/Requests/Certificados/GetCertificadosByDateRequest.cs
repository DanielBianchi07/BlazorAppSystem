using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp.Shared.Requests.Certificados
{
    public class GetCertificadosByDateRequest : PagedRequest
    {
        [Required(ErrorMessage = "Data Inválida")]
        public DateTime? StartDate { get; set; }
        [Required(ErrorMessage = "Data Invalida")]
        public DateTime? EndDate { get; set; }
    }
}
