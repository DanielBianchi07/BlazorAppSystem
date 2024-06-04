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
    public class CreateProvaRequest : Request
    {
        [Required(ErrorMessage = "Status Inválido")]
        public EAtivoInativo Status { get; set; } = EAtivoInativo.Ativo;
        public DateTime? DataCriacao { get; set; } = DateTime.Now;
        [Required(ErrorMessage = "Curso Inválido")]
        public Guid CursoId { get; set; }
        [Required(ErrorMessage = "Usuário Inválido")]
        public string UsuarioId { get; set; }
    }
}
