using BlazorApp.Shared.Enums;
using System.Text.Json.Serialization;

namespace BlazorApp.Shared.Models
{
    public class Instrutor
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Nome { get; set; } = string.Empty;
        public string Cpf { get; set; } = string.Empty;
        public string Especializacao { get; set; } = string.Empty;
        public string Registro { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Telefone { get; set; } = string.Empty;
        public string Assinatura { get; set; } = string.Empty;
        public EAtivoInativo Status { get; set; } = EAtivoInativo.Ativo;
        public DateTime? DataCriacao { get; set; } = null;
        public DateTime? DataAlteracao { get; set; } = null;

        public ICollection<Treinamento> Treinamentos { get; set; }

        public string UsuarioId { get; set; }
        [JsonIgnore]
        public ICollection<Usuario> Usuarios { get; set; }
    }
}
