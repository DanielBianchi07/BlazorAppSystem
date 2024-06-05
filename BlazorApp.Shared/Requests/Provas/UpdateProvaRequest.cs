using BlazorApp.Shared.Enums;
using BlazorApp.Shared.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp.Shared.Requests.Provas
{
    public class UpdateProvaRequest : Request
    {
        [Required(ErrorMessage = "Prova Inválida")]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Status Inválido")]
        public EAtivoInativo Status { get; set; } = EAtivoInativo.Ativo;
        public DateTime? DataAlteracao { get; set; } = DateTime.Now;
        [Required(ErrorMessage = "Curso Inválido")]
        public Guid CursoId { get; set; }
    }
}
