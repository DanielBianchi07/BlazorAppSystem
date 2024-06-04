using BlazorApp.Shared.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp.Shared.Requests.Instrutores
{
    public class CreateInstrutorRequest : Request
    {
        [Required(ErrorMessage = "Nome Inválido")]
        public string Nome { get; set; } = string.Empty;

        [Required(ErrorMessage = "CPF Inválido")]
        public string Cpf { get; set; } = string.Empty;

        [Required(ErrorMessage = "Especialização Inválida")]
        public string Especializacao { get; set; } = string.Empty;

        [Required(ErrorMessage = "Registro Inválido")]
        public string Registro { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        [Required(ErrorMessage = "Telefone Inválido")]
        public string Telefone { get; set; } = string.Empty;

        [Required(ErrorMessage = "Assinatura Inválida")]
        public string Assinatura { get; set; } = string.Empty;

        [Required(ErrorMessage = "Status Inválido")]
        public EAtivoInativo Status { get; set; } = EAtivoInativo.Ativo;
        public DateTime DataCriacao { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "Usuario Inválido")]
        public string UsuarioId { get; set; }
    }
}