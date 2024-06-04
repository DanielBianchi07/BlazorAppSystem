using BlazorApp.Shared.Enums;
using BlazorApp.Shared.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp.Shared.Requests.ConteudosProgramaticos
{
    public class CreateConteudoProgramaticoRequest : Request
    {
        [Required(ErrorMessage = "Curso Inválido")]
        public Guid CursoId { get; set; }
        [Required(ErrorMessage = "Assunto Inválido")]
        public string Assunto { get; set; } = string.Empty;
        [Required(ErrorMessage = "Carga Horária Inválida")]
        public int CargaHoraria { get; set; }
        [Required(ErrorMessage = "Status Inválido")]
        public EAtivoInativo Status { get; set; } = EAtivoInativo.Ativo;
        public DateTime? DataCriacao { get; set; } = DateTime.Now;
    }
}
