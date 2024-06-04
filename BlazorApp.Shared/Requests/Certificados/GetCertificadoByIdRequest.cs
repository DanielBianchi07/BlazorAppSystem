using BlazorApp.Shared.Models;
using BlazorApp.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BlazorApp.Shared.Requests.Certificados
{
    public class GetCertificadoByIdRequest : Request
    {
        [Required(ErrorMessage = "Treinamento Inválido")]
        public Guid TreinamentoId { get; set; }
        [Required(ErrorMessage = "Código Invalido")]
        public string Codigo { get; set; } = string.Empty;
    }
}
