using BlazorApp.Shared.Models;
using BlazorApp.Shared.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp.Shared.Requests.Cursos
{
    public class UpdateCursoRequest : Request
    {
        [Required(ErrorMessage = "Curso Inválido")]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Nome de Curso Inválido")]
        public string Nome { get; set; } = string.Empty;
        [Required(ErrorMessage = "Logo Inválida")]
        public string Logo { get; set; } = string.Empty;
        [Required(ErrorMessage = "Carga Horária Inicial Inválida")]
        public int CargaHorariaInicial { get; set; }
        [Required(ErrorMessage = "Carga Horária Periódica Inválida")]
        public int CargaHorariaPeriodico { get; set; }
        [Required(ErrorMessage = "Validade de Curso Inválida")]
        public int Validade { get; set; }
        [Required(ErrorMessage = "Status Inválido")]
        public EAtivoInativo Status { get; set; } = EAtivoInativo.Ativo;
        public DateTime? DataCriacao { get; set; } = DateTime.Now;
        public DateTime? DataAlteracao { get; set; } = DateTime.Now;
    }
}
