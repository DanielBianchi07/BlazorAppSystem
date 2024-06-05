using BlazorApp.Shared.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp.Shared.Requests.Treinamentos
{
    public class UpdateTreinamentoRequest : Request
    {
        [Required(ErrorMessage = "Treinamento Inválido")]
        public Guid Id { get; set; }
        public DateTime? DataAlteracao { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "Tipo do Treinamento Inválido")]
        public ETipoTreinamento Tipo { get; set; } = ETipoTreinamento.Inicial;

        [Required(ErrorMessage = "Situação Inválida")]
        public ESituacaoTreinamento Situacao { get; set; } = ESituacaoTreinamento.Andamento;

        [Required(ErrorMessage = "Status Inválido")]
        public EAtivoInativo Status { get; set; } = EAtivoInativo.Ativo;


        [Required(ErrorMessage = "Curso Inválido")]
        public Guid CursoId { get; set; }
        [Required(ErrorMessage = "Empresa Inválida")]
        public Guid EmpresaId { get; set; }
        [Required(ErrorMessage = "Aluno Inválido")]
        public Guid AlunoId { get; set; }
        [Required(ErrorMessage = "Instrutor Inválido")]
        public Guid InstrutorId { get; set; }
    }
}
