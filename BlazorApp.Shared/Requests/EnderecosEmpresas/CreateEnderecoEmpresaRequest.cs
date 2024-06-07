using BlazorApp.Shared.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp.Shared.Requests.EnderecosEmpresas
{
    public class CreateEnderecoEmpresaRequest : Request
    {
        [Required(ErrorMessage = "Empresa Inválida")]
        public Guid? EmpresaId { get; set; }

        [Required(ErrorMessage = "CEP Inválido")]
        public string CEP { get; set; } = string.Empty;
        
        [Required(ErrorMessage = "Estado Inválido")]
        public string Estado { get; set; } = string.Empty;
        
        [Required(ErrorMessage = "Cidade Inválida")]
        public string Cidade { get; set; } = string.Empty;
        [Required(ErrorMessage = "Bairro Inválido")]
        public string Bairro { get; set; } = string.Empty;
        [Required(ErrorMessage = "Nome da Rua Inválido")]
        public string NomeRua { get; set; } = string.Empty;
        [Required(ErrorMessage = "Número Inválido")]
        public string Numero { get; set; } = string.Empty;
        public string? Complemento { get; set; } = string.Empty;

        [Required(ErrorMessage = "Status Inválido")]
        public EAtivoInativo Status { get; set; } = EAtivoInativo.Ativo;
    }
}
