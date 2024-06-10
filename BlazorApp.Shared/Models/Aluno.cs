using BlazorApp.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BlazorApp.Shared.Models
{
    public class Aluno
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string Nome { get; set; } = string.Empty;
        public string Cpf { get; set; } = string.Empty;
        public string Rg { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Telefone { get; set; } = string.Empty;
        public string Assinatura { get; set; } = string.Empty;
        public DateTime? DataCriacao { get; set; } = null;
        public DateTime? DataAlteracao { get; set; } = null;
        public EAtivoInativo Status { get; set; } = EAtivoInativo.Ativo;

        [JsonIgnore]
        public ICollection<Empresa> Empresas { get; set; }
        [JsonIgnore]
        public ICollection<Treinamento> Treinamentos { get; set; }

        public Guid CreatedBy { get; set; }
        public Guid? UpdatedBy { get; set; }
    }
}
