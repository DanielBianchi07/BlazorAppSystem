using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp.Shared.Requests
{
    public abstract class Request
    {
        public string UsuarioId { get; set; } = string.Empty;
    }
}
