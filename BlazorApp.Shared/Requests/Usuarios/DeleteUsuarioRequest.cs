﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp.Shared.Requests.Usuarios
{
    public class DeleteUsuarioRequest : Request
    {
        [Required(ErrorMessage = "Usuário Inválido")]
        public Guid Id { get; set; }
    }
}