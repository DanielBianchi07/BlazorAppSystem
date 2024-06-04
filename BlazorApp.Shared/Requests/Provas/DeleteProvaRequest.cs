using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp.Shared.Requests.Provas
{
    public class DeleteProvaRequest : Request
    {
        [Required(ErrorMessage = "Prova Inválida")]
        public Guid Id { get; set; }
    }
}
