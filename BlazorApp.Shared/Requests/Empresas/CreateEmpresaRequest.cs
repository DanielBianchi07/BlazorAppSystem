using BlazorApp.Shared.Enums;
using BlazorApp.Shared.Models;
using BlazorApp.Shared.Requests.EnderecosEmpresas;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp.Shared.Requests.Empresas
{
    public class CreateEmpresaRequest : Request
    {
        [Required(ErrorMessage = "CNPJ Inválido")]
        public string CNPJ { get; set; } = string.Empty;
        [Required(ErrorMessage = "Razão Social Inválida")]
        public string RazaoSocial { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        [Required(ErrorMessage = "Status Inválido")]
        public EAtivoInativo Status { get; set; } = EAtivoInativo.Ativo;
        public DateTime? DataCriacao { get; set; } = DateTime.Now;
        [ValidateComplexType]
        public EnderecoEmpresa Endereco { get; set; } = null!;
    }
}
