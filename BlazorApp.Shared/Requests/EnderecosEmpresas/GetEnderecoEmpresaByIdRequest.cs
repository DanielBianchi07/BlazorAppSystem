using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp.Shared.Requests.EnderecosEmpresas
{
    public class GetEnderecoEmpresaByIdRequest : Request
    {
        // [Required(ErrorMessage = "Id Endereço Inválido")]
        // public Guid Id { get; set; }
        [Required(ErrorMessage = "Empresa Inválida")]
        public Guid EmpresaId { get; set; }
    }
}
