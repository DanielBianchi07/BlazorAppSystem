using BlazorApp.Shared.Enums;

namespace BlazorApp.Shared.Models
{
    public class Usuario
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Email { get; set; } = string.Empty;
        public string Nome { get; set; } = string.Empty;
        public string Senha {  get; set; } = string.Empty;
        public EAtivoInativo IsAdmin { get; set; } = EAtivoInativo.Ativo;
        public DateTime? DataCriacao { get; set; } = null;
        public DateTime? DataAlteracao { get; set; } = null;
        public EAtivoInativo Status { get; set; } = EAtivoInativo.Ativo;
    }
}
