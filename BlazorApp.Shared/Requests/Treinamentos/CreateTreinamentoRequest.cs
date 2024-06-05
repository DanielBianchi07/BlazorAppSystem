using BlazorApp.Shared.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp.Shared.Requests.Treinamentos
{
    public class CreateTreinamentoRequest : Request
    {
        public DateTime? DataCriacao { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "Tipo do Treinamento Inválido")]
        public ETipoTreinamento Tipo { get; set; } = ETipoTreinamento.Inicial;

        [Required(ErrorMessage = "Situação Inválida")]
        public ESituacaoTreinamento Situacao { get; set; } = ESituacaoTreinamento.Andamento;

        [Required(ErrorMessage = "Status Inválido")]
        public EAtivoInativo Status { get; set; } = EAtivoInativo.Ativo;


        [Required(ErrorMessage = "Curso Inválido")]
        public Guid CursoId { get; set; }
        [Required(ErrorMessage = "Empresa Inválida")]
        public List<Guid> EmpresasId { get; set; }
        [Required(ErrorMessage = "Aluno Inválido")]
        public List<Guid> AlunosId { get; set; }
        [Required(ErrorMessage = "Instrutor Inválido")]
        public List<Guid> InstrutoresId { get; set; }
    }
}
