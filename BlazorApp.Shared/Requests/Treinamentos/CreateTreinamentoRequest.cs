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

        public ETipoTreinamento Tipo { get; set; } = ETipoTreinamento.Inicial;

        public ESituacaoTreinamento Situacao { get; set; } = ESituacaoTreinamento.Andamento;

        public EAtivoInativo Status { get; set; } = EAtivoInativo.Ativo;


        public Guid CursoId { get; set; }
        public List<Guid> EmpresasId { get; set; }
        public List<Guid> AlunosId { get; set; }
        public List<Guid> InstrutoresId { get; set; }
    }
}
