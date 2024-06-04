using BlazorApp.Shared.Models;
using BlazorApp.Shared.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp.Shared.Requests.Certificados
{
    public class CreateCertificadoRequest : Request
    {
        [Required(ErrorMessage = "Treinamento Inválido")]
        public Guid TreinamentoId { get; set; }
        [Required(ErrorMessage = "Código Invalido")]
        public string Codigo { get; set; } = string.Empty;
        public DateTime? DataInicioCertificado { get; set; } = null;
        public DateTime? DataCriacao { get; set; } = DateTime.Now;
        [Required(ErrorMessage = "Situação Inválida")]
        public ESituacaoCertificado Situacao { get; set; } = ESituacaoCertificado.Processando;
        [Required(ErrorMessage = "Usuário Inválido")]
        public string UsuarioId { get; set; }
    }
}
