using BlazorApp.Shared.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp.Shared.Requests.Alunos
{
    public class CreateAlunoRequest : Request
    {
        [Required(ErrorMessage = "Nome Inválido")]
        public string Nome { get; set; } = string.Empty;
        public string Cpf { get; set; } = string.Empty;
        public string Rg { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Telefone { get; set; } = string.Empty;
        public string Assinatura { get; set; } = string.Empty;
        public DateTime? DataCriacao { get; set; } = DateTime.Now;
        [Required(ErrorMessage = "Empresa Inválida")]
        public Guid EmpresaId { get; set; }
    }
}