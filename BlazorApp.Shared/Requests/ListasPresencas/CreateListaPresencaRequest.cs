using BlazorApp.Shared.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp.Shared.Requests.ListasPresencas
{
    public class CreateListaPresencaRequest : Request
    {
        [Required(ErrorMessage = "Treinamento Inválido")]
        public Guid TreinamentoId { get; set; }

        [Required(ErrorMessage = "Código Inválido")]
        public string Codigo { get; set; } = string.Empty;

        public DateTime? DataCriacao { get; set; }

        public DateTime? DataInicioTreinamento { get; set; }
        
        [Required(ErrorMessage = "Situação Inválida")]
        public ESituacaoCertificado Situacao { get; set; }

        [Required(ErrorMessage = "Usuario Inválido")]
        public string UsuarioId { get; set; }
    }
}
