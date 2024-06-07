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
    public class UpdateEmpresaRequest : Request
    {
        public Guid Id { get; set; }

        public string CNPJ { get; set; } = string.Empty;

        public string RazaoSocial { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public EAtivoInativo Status { get; set; } = EAtivoInativo.Ativo;
        public DateTime? DataAlteracao { get; set; } = DateTime.Now;
        public EnderecoEmpresa Endereco { get; set; } = null!;
    }
}
